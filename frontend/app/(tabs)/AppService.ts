import axios from "axios";

const BASE_URL = "https://nativetunes.azurewebsites.net/api";

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

export interface Podcast {
  id: string;
  title: string;
  description: string;
  language: string;
  coverImageUrl: string;
  podcastUrl: string;
  createdOn: string;
  createdBy: {
    id: string;
  };
}

export const fetchProducts = async (): Promise<Product[]> => {
  try {
    const response = await axios.get(`${BASE_URL}/marketplace/products`);
    return response.data as Product[];
  } catch (error) {
    throw error;
  }
};

export const fetchPodcastbyId = async ({id} : {id:string}): Promise<Podcast> => {
  try {
    const response = await axios.get(`$(BASE_URL)/podcast/{id}`);
    return response.data as Podcast;
  } catch (error) {
    throw error;
  }
};
