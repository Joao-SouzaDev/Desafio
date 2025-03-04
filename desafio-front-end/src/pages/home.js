import { useEffect, useState } from "react";
import axios from "../services/apiproduct";
import ProductCard from "../components/ProductCard";
import { Container, Grid, Typography, TextField, AppBar, Toolbar, Button } from "@mui/material";
import { Link } from "react-router-dom";
import Cookies from "js-cookie";
import { useNavigate } from "react-router-dom";
function Home() {
    const [products, setProducts] = useState([]);
    const [search, setSearch] = useState("");
    const navigate = useNavigate();
    useEffect(() => {
      axios.get("/Product")
        .then(response => setProducts(response.data))
        .catch(error => console.error(error));
    }, []);
  
    const filteredProducts = products.filter(product =>
      product.name.toLowerCase().includes(search.toLowerCase())
    );
    const handleLoginClick = () => {
      const token = Cookies.get("token");
      if (token) {
        navigate("/productmng");
      } else {
        navigate("/login");
      }
    };
    return (
      <>
        <AppBar position="static" sx={{ backgroundColor: "#2e7d32" }}>
          <Toolbar>
            <Typography variant="h6" sx={{ flexGrow: 1 }}>
              Catálogo de Produtos
            </Typography>
            <Button color="inherit" onClick={handleLoginClick}>
              Login Empresa
            </Button>
          </Toolbar>
        </AppBar>
  
        <Container sx={{ mt: 4 }}>
          <TextField
            fullWidth
            label="Buscar produto..."
            variant="outlined"
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            sx={{ mb: 4 }}
          />
  
          <Grid container spacing={3}>
            {filteredProducts.map(product => (
              <Grid item xs={12} sm={6} md={4} key={product.id}>
                <ProductCard product={product} />
              </Grid>
            ))}
          </Grid>
        </Container>
      </>
    );
  }
  
  export default Home;