import { useState } from "react";
import axios from "../services/apiauth";
import { TextField, Button, Box, Typography, Container } from "@mui/material";
import Cookies from "js-cookie";
import { useNavigate } from "react-router-dom";

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();
  
    const handleLogin = async (e) => {
      e.preventDefault();
      try {
        const response = await axios.post("/Auth/login", { email, password });
        Cookies.set("token", response.data.token, { secure: true, sameSite: "Strict" });
        Cookies.set("userId", response.data.userId,{ secure: true, sameSite: "Strict" })
        navigate("/productmng");
      } catch (error) {
        console.error("Erro ao fazer login", error);
      }
    };
  
    return (
      <Container maxWidth="xs">
        <Box
          sx={{
            mt: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            padding: 4,
            borderRadius: 2,
            boxShadow: 3,
            backgroundColor: "#f1f8e9",
          }}
        >
          <Typography variant="h5" color="primary" gutterBottom>
            Login
          </Typography>
          <form onSubmit={handleLogin} style={{ width: "100%" }}>
            <TextField
              fullWidth
              label="Email"
              variant="outlined"
              margin="normal"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <TextField
              fullWidth
              label="Senha"
              type="password"
              variant="outlined"
              margin="normal"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
            <Button fullWidth variant="contained" color="success" type="submit" sx={{ mt: 2 }}>
              Entrar
            </Button>
          </form>
        </Box>
      </Container>
    );
  }
  
  export default Login;
