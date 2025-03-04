import { useState } from "react";
import { Box, Button, Modal, TextField, Typography } from "@mui/material";
import axios from "../services/apiauth";

function RegisterModal({ open, onClose }) {
  const [companyName, setCompanyName] = useState("");
  const [document, setDocument] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleRegister = async () => {
    try {
      await axios.post("/auth/register", {
        companyName,
        document,
        email,
        password,
      });
      alert("Cadastro realizado com sucesso!");
      onClose();
    } catch (error) {
      console.error("Erro no cadastro:", error);
    }
  };

  return (
    <Modal open={open} onClose={onClose}>
      <Box sx={{ position: "absolute", top: "50%", left: "50%", transform: "translate(-50%, -50%)", width: 400, bgcolor: "white", p: 3, borderRadius: 2 }}>
        <Typography variant="h6">Cadastro</Typography>
        <TextField label="Nome da Empresa" value={companyName} onChange={(e) => setCompanyName(e.target.value)} fullWidth sx={{ mt: 2 }} />
        <TextField label="Documento" value={document} onChange={(e) => setDocument(e.target.value)} fullWidth sx={{ mt: 2 }} />
        <TextField label="Email" value={email} onChange={(e) => setEmail(e.target.value)} fullWidth sx={{ mt: 2 }} />
        <TextField label="Senha" type="password" value={password} onChange={(e) => setPassword(e.target.value)} fullWidth sx={{ mt: 2 }} />
        <Button variant="contained" onClick={handleRegister} sx={{ mt: 2 }}>Cadastrar</Button>
      </Box>
    </Modal>
  );
}

export default RegisterModal;
