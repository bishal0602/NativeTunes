import React, { useEffect, useState } from 'react';
import { View, FlatList } from 'react-native';
import Post from './post';
import { Product, fetchProducts } from './AppService';


import { StyleSheet } from 'react-native';
import { EvilIcons } from '@expo/vector-icons'; 


export default function MarketplaceScreen() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetchProducts();
        setProducts(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, []);
  return (
    <View>
    <FlatList
      data={dataReceived}
      keyExtractor={(item) => item.id}
      renderItem={({ item }) => <Post data={item} />}
    />
  </View>
  )
}

