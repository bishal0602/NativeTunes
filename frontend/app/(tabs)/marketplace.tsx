import React, { useEffect, useState } from "react";
import { View, FlatList } from "react-native";
import Post from "../../components/marketplace_post";
import { Product, fetchProducts } from "./AppService";

export default function MarketplaceScreen() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetchProducts();
        setProducts(data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, []);
  return (
    <View>
      <FlatList
        data={products}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => <Post data={item} />}
      />
    </View>
  );
}
