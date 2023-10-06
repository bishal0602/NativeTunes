import axios from 'axios';

const BASE_URL = 'https://nativetunes.azurewebsites.net/api/marketplace/products';

export interface Product {
  id: string;
  title: string;
  description: string;
  price: number;
  likes: number;
  imageUrl: string;
  createdOn: string;
  createdBy: {
    id: string;
  };
}

export const fetchProducts = async (): Promise<Product[]> => {
  try {
    const response = await axios.get(BASE_URL);
    return response.data as Product[];
  } catch (error) {
    throw error;
  }
};
