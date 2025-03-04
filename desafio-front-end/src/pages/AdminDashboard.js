import { useState, useEffect } from "react";
import { Box, Button, Drawer, List, ListItem, ListItemText, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import MyProducts from "../components/ProductsByOwner";
import ProductFeedbacks from "../components/ProductFeedbacks";
import axios from "../services/apiproduct";
import Cookies from "js-cookie";

function AdminDashboard() {
  const [selectedTab, setSelectedTab] = useState("products");
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    const token = Cookies.get("token");
    if (!token) {
      navigate("/login");
    } else {
      setIsAuthenticated(true);
    }
  }, [navigate]);

  if (!isAuthenticated) {
    return null;
  }

  return (
    <Box sx={{ display: "flex", height: "100vh" }}>
      {/* Menu Lateral */}
      <Drawer variant="permanent" sx={{ width: 240, flexShrink: 0 }}>
        <Box sx={{ width: 240, p: 2 }}>
          <Typography variant="h6">Gerenciamento</Typography>
          <List>
            <ListItem button onClick={() => setSelectedTab("products")}>
              <ListItemText primary="Meus Produtos" />
            </ListItem>
            <ListItem button onClick={() => setSelectedTab("feedbacks")}>
              <ListItemText primary="Feedbacks Recebidos" />
            </ListItem>
          </List>
        </Box>
      </Drawer>

      {/* Conteúdo da Página */}
      <Box sx={{ flexGrow: 1, p: 3 }}>
        {selectedTab === "products" ? <MyProducts /> : <ProductFeedbacks />}
      </Box>
    </Box>
  );
}

export default AdminDashboard;
