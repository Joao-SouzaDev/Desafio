import { useState, useEffect } from "react";
import { Box, Card, CardContent, Typography,CardMedia,Container,Grid, Button } from "@mui/material";
import axios from "../services/apiproduct";
import Cookies from "js-cookie";
import ProductModal from "./ProductModal";

function MyProducts() {
  const [products, setProducts] = useState([]);
  const [ownerId, setOwnerId] = useState("");
  const [open, setOpen] = useState(false);

  useEffect(() => {
    const fetchProducts = async () => {
      const userId = Cookies.get("userId");
      try{
          const response = await axios.get(`/ProductOwner/${userId}`)
          Cookies.set("productOwnerId", response.data.id, { secure: true, sameSite: "Strict" })
          setOwnerId(response.data.id)
          console.log(ownerId)
      }catch (error) {
          console.error("Erro ao carregar produtos:", error);
      }
      
      const token = Cookies.get("token");
      try {
        const response = await axios.get(`/Product/${Cookies.get("productOwnerId")}/products`, {
          headers: { Authorization: `Bearer ${token}` },
        });
        setProducts(response.data);
      } catch (error) {
        console.error("Erro ao carregar produtos:", error);
      }
    };
    fetchProducts();
  }, []);

  return (
    <Container sx={{ mt: 1, ml: 3 }}>
    <Box>
      <Typography variant="h5" gutterBottom>Meus Produtos</Typography>
      <Button variant="contained" onClick={() => setOpen(true)} sx={{ mt: 1 }}>Adicionar Produto</Button>
      {products.map((product) => (
        <Grid item xs={12} sm={6} md={4} key={product.id}>
          <Card  sx={{ maxWidth: 200, backgroundColor: "#e8f5e9", borderRadius: 2, cursor: "pointer", mt:4 }} >
      <CardMedia 
          component="img"
          height="140"
          image={product.imageUrl}
          alt={product.name}
      />
      <CardContent>
        <Typography variant="h6" color="primary">
          {product.name}
        </Typography>
        <Typography variant="body1">Preço: R$ {product.price}</Typography>
      </CardContent>
      </Card>
    </Grid>
      ))}
    </Box>
    <ProductModal open={open} onClose={() => setOpen(false)} />
    </Container>

  );
}

export default MyProducts;
