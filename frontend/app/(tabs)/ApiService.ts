import axios from "axios";

const BASE_URL = "https://nativetunes.azurewebsites.net/api";

export interface Product {
  id: string;
  title: string;
  description: string;
  price: number;
  likes: number;
  imageUrl: string;
  createdOn: Date;
  createdBy? :User;
}

export interface Article {
  id: string;
  title: string;
  description: string;
  likes: number;
  createdOn: Date;
  createdBy?: User;
}
export interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  profilePicture: string;
}
export interface Podcast {
  id: string;
  title: string;
  description?: string;
  language: string;
  coverImageUrl: string;
  podcastUrl: string;
  createdOn: string;
  createdBy?:User ;
}

//TODO : correct BASEURL
export const fetchArticles = async (): Promise<Article[]> => {
  try {
    const response = await axios.get(`${BASE_URL}/library/articles`);
    return response.data as Article[];
  } catch (error) {
    throw error;
  }
};

export const fetchProducts = async (): Promise<Product[]> => {
  try {
    const response = await axios.get(`${BASE_URL}/marketplace/products`);
    return response.data as Product[];
  } catch (error) {
    throw error;
  }
};

export const fetchPodcastbyId = async ({
  id,
}: {
  id: string;
}): Promise<Podcast> => {
  try {
    const response = await axios.get(`${BASE_URL}/podcasts/${id}`);
    return response.data as Podcast;
  } catch (error) {
    throw error;
  }
};
export const fetchPodcasts = async (): Promise<Podcast[]> => {
  try {
    const response = await axios.get(`${BASE_URL}/podcasts/`);
    return response.data as Podcast[];
  } catch (error) {
    throw error;
  }
};