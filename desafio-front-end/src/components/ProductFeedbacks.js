import { useState, useEffect } from "react";
import { Box, Card, CardContent, Typography, Button, TextField, Rating,Container } from "@mui/material";
import axios from "../services/apifeedback";
import Cookies from "js-cookie";

function ProductFeedbacks() {
  const [feedbacks, setFeedbacks] = useState([]);
  const [responses, setResponses] = useState({});

  useEffect(() => {
    const fetchFeedbacks = async () => {
      const token = Cookies.get("token");
      try {
        const response = await axios.get("/Feedback", {
          headers: { Authorization: `Bearer ${token}` },
        });
        setFeedbacks(response.data);
      } catch (error) {
        console.error("Erro ao carregar feedbacks:", error);
      }
    };

    fetchFeedbacks();
  }, []);

  const handleResponseChange = (feedbackId, value) => {
    setResponses({ ...responses, [feedbackId]: value });
  };

  const handleSubmitResponse = async (feedbackId) => {
    const token = Cookies.get("token");
    if (!responses[feedbackId]) return;
    try {
      const answer = {feedbackId: feedbackId,description: responses[feedbackId], productOwnerId:Cookies.get("productOwnerId") }
      await axios.post(
        "/answer",
        answer
      );
      setResponses({ ...responses, [feedbackId]: "" });
    } catch (error) {
      console.error("Erro ao responder feedback:", error);
    }
  };

  return (
    <Container sx={{ mt: 1 }}>
      <Box>
        <Typography variant="h5" gutterBottom>Feedbacks Recebidos</Typography>
        {feedbacks.map((feedback) => (
          <Card key={feedback.id} sx={{ mb: 2, p: 2 }}>
            <CardContent>
              <Rating value={feedback.reating} readOnly />
              <Typography>{feedback.description}</Typography>
              <TextField
                fullWidth
                label="Responder Feedback"
                value={responses[feedback.id] || ""}
                onChange={(e) => handleResponseChange(feedback.id, e.target.value)}
                sx={{ mt: 2 }}
              />
              <Button
                variant="contained"
                color="primary"
                sx={{ mt: 1 }}
                onClick={() => handleSubmitResponse(feedback.id)}
              >
                Enviar Resposta
              </Button>
            </CardContent>
          </Card>
        ))}
      </Box>
    </Container>
  );
}

export default ProductFeedbacks;
