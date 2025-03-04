import { useState } from "react";
import { Box, Button, Modal, TextField, Typography } from "@mui/material";
import axios from "../services/apiproduct";
import Cookies from "js-cookie";

function ProductModal({ open, onClose }) {
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [description,setDescription] = useState();

  const handleAddProduct = async () => {
    try {
      const token = Cookies.get("token");
      const productOwnerId = Cookies.get("productOwnerId")
      await axios.post("/Product", { name, price, description,  productOwnerId}, {
        headers: { Authorization: `Bearer ${token}` },
      });
      alert("Produto cadastrado com sucesso!");
      onClose();
    } catch (error) {
      console.error("Erro ao cadastrar produto:", error);
    }
  };

  return (
    <Modal open={open} onClose={onClose}>
      <Box sx={{ position: "absolute", top: "50%", left: "50%", transform: "translate(-50%, -50%)", width: 400, bgcolor: "white", p: 3, borderRadius: 2 }}>
        <Typography variant="h6">Novo Produto</Typography>
        <TextField label="Nome do Produto" value={name} onChange={(e) => setName(e.target.value)} fullWidth sx={{ mt: 2 }} />
        <TextField label="Descrição" value={description} onChange={(e) => setDescription(e.target.value)} fullWidth sx={{ mt: 2 }} />
        <TextField label="Preço" type="number" value={price} onChange={(e) => setPrice(e.target.value)} fullWidth sx={{ mt: 2 }} />
        <Button variant="contained" onClick={handleAddProduct} sx={{ mt: 2 }}>Cadastrar</Button>
      </Box>
    </Modal>
  );
}

export default ProductModal;
