import React, { useEffect, useState } from "react";
import { View, FlatList } from "react-native";

import {Article, fetchArticles} from './AppService';
import TextPost from "../../components/library_post";



export default function LibraryScreen() {
// const [articles, setArticles] = useState<Article[]>([]);

const articles = [
  {
    id: 'djfldlasf',
    title: 'Its a long title',
    description: 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum',
    likes: 89,
    createdOn: "2022-02-02",
    createdBy: {
      id: 'dskfldks',
    }
  },
    {
      id: 'Very very long title',
      title: 'Title',
      description: 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum',
      likes: 89,
      createdOn: "2022-02-02",
      createdBy: {
        id: 'dskfldks',
      },
  }
];

  // useEffect(() => {
  //   const fetchData = async () => {
  //     try {
  //       const data = await fetchArticles();
  //       setArticles(data);
  //     } catch (error) {
  //       console.error("Error fetching data:", error);
  //     }
  //   };

  //   fetchData();
  // }, []);
  return (
    <View>
      <FlatList
        data={articles}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => <TextPost data={item} />}
      />
    </View>
  );
}
