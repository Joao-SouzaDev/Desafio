import { Card, CardContent, Typography, Modal, Box, Button, TextField, Rating } from "@mui/material";
import { useState, useEffect } from "react";
import axios from "../services/apifeedback";

function ProductCard({ product }) {
  const [open, setOpen] = useState(false);
  const [feedbacks, setFeedbacks] = useState([]);
  const [newFeedback, setNewFeedback] = useState("");
  const [newRating, setNewRating] = useState(0);
  const [newEmail,setNewEmail] = useState("");

  useEffect(() => {
    if (open) {
      axios.get(`/Feedback/${product.id}/feedbacks`)
        .then(response => setFeedbacks(response.data))
        .catch(error => console.error("Erro ao buscar feedbacks:", error));
    }
  }, [open, product.ProductOwnerId]);

  const handleAddFeedback = async () => {
    if (!newFeedback.trim() || newRating === 0) return;
    try {
      const feedback = { description: newFeedback, reating: newRating, productId: product.id, email: newEmail };
      await axios.post(`/Feedback`, feedback);
      setFeedbacks([...feedbacks, feedback]);
      setNewFeedback("");
      setNewRating(0);
      setNewEmail("");
    } catch (error) {
      console.error("Erro ao adicionar feedback:", error);
    }
  };

  return (
    <>
      <Card 
        sx={{ maxWidth: 300, backgroundColor: "#e8f5e9", borderRadius: 2, cursor: "pointer" }} 
        onClick={() => setOpen(true)}
      >
        <CardContent>
          <Typography variant="h6" color="primary">
            {product.name}
          </Typography>
          <Typography variant="body1">Preço: R$ {product.price}</Typography>
        </CardContent>
      </Card>

      {/* Popup de Feedbacks */}
      <Modal open={open} onClose={() => setOpen(false)}>
        <Box
          sx={{
            position: "absolute",
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)",
            width: 400,
            bgcolor: "background.paper",
            p: 4,
            borderRadius: 2,
            boxShadow: 24,
            maxHeight: "80vh", // Define altura máxima
            overflowY: "auto" // Habilita o scroll
          }}
        >
          <Typography variant="h6" color="primary" gutterBottom>
            Feedbacks de {product.name}
          </Typography>

          <Box sx={{ maxHeight: 300, overflowY: "auto", mb: 2, p: 1, borderRadius: 1 }}>
            {feedbacks.length > 0 ? (
              feedbacks.map((f, index) => (
                <Box key={index} sx={{ mb: 2, p: 2, border: "1px solid #ddd", borderRadius: 1 }}>
                  <Rating value={f.reating} readOnly />
                  <Typography sx={{ mt: 1 }}>{f.description}</Typography>
                </Box>
              ))
            ) : (
              <Typography sx={{ mb: 2 }}>Nenhum feedback ainda.</Typography>
            )}
          </Box>

          <Typography variant="subtitle1">Adicionar Feedback:</Typography>
          <Rating
            value={newRating}
            onChange={(event, newValue) => setNewRating(newValue)}
            sx={{ mb: 2 }}
          />
          <TextField
            fullWidth
            label="Escreva seu feedback..."
            variant="outlined"
            value={newFeedback}
            onChange={(e) => setNewFeedback(e.target.value)}
            sx={{ mt: 1 }}
          />
          <TextField
            fullWidth
            label="Escreva seu Email..."
            variant="outlined"
            required
            value={newEmail}
            onChange={(e) => setNewEmail(e.target.value)}
            sx={{ mt: 1 }}
          />
          <Button 
            variant="contained" 
            color="success" 
            fullWidth 
            sx={{ mt: 2 }} 
            onClick={handleAddFeedback}
          >
            Enviar Feedback
          </Button>
        </Box>
      </Modal>
    </>
  );
}

export default ProductCard;
