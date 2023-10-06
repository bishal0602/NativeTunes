import React, { useEffect, useState } from 'react';
import { View, FlatList } from 'react-native';
import Post from './post';
import { Product, fetchProducts } from './AppService';



const App = () => {
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
        data={products}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => <Post data={item} />}
      />
    </View>
  );
};

export default App;

const dataReceived = [
  {
    id: 'jdaslflasdjlk',
    imgURL: 'https://images.unsplash.com/photo-1529665253569-6d01c0eaf7b6?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1985&q=80',
    createdBy: {
        profilePicture: 'https://images.unsplash.com/photo-1511367461989-f85a21fda167?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8cHJvZmlsZXxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60',
        userName: 'Google',
    },
    createdOn: new Date("2020-07-22T13:22:10.2566789+00:00"),
    title: 'Doko',
    likes: 80,
    price: 31,
    description: 'Traditional instrument asdkhfjadksjlasdf dasfkldfsajl adsflkjadlsfjlkjadsfljkadsflkfadsjljlk ',
  },
  {
    id: 'adfjlkj',
    imgURL: 'https://images.unsplash.com/photo-1529665253569-6d01c0eaf7b6?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1985&q=80',
    createdBy: {
        profilePicture: 'https://images.unsplash.com/photo-1511367461989-f85a21fda167?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8cHJvZmlsZXxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60',
        userName: 'Google',
    },
    createdOn: new Date("2020-07-22T13:22:10.2566789+00:00"),
    title: 'Doko',
    likes: 80,
    price: 31,
    description: 'Traditional instrument asdkhfjadksjlasdf dasfkldfsajl adsflkjadlsfjlkjadsfljkadsflkfadsjljlk ',
  },
  {
    id: 'dsfaa',
    imgURL: 'https://images.unsplash.com/photo-1529665253569-6d01c0eaf7b6?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1985&q=80',
    createdBy: {
        profilePicture: 'https://images.unsplash.com/photo-1511367461989-f85a21fda167?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8cHJvZmlsZXxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60',
        userName: 'Google',
    },
    createdOn: new Date("2020-07-22T13:22:10.2566789+00:00"),
    title: 'Doko',
    likes: 80,
    price: 31,
    description: 'Traditional instrument asdkhfjadksjlasdf dasfkldfsajl adsflkjadlsfjlkjadsfljkadsflkfadsjljlk ',
  },
];