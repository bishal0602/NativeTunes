import React, { useEffect, useState } from "react";
import { View, FlatList } from "react-native";

import {Article, fetchArticles} from './ApiService';
import TextPost from "../../components/library_post";



export default function LibraryScreen() {
// const [articles, setArticles] = useState<Article[]>([]);

const articles = [
  {
    id: 'djfldlasf',
    title: 'The last of the Kusunda',
    description: 'The Kusunda are one of the two last remaining hunter-gatherer societies left in Nepal, the other being the nomadic Raute. The 2011 Census showed that there were only 273 Kusunda individuals remaining, and there are probably even fewer today.     The Kusunda language is not related to any other language group in South Asia, and has only one native speaker still alive: Kamala Khatri Sen in Dang district. Decades of social exclusion has nearly obliterated this ethnic group. One of the earliest mentions of Kusunda comes from Brian Houghton Hodgson, the British Resident to Nepal in 1833, who extensively documented Nepal\'s human and natural diversity. \'Amid the dense forests of the central region of Nepal, to the westward of the great valley, dwell, in scanty numbers and nearly in a state of nature, two broken tribes having no apparent affinity with the civilized races of the country, and seeming like the fragments of an earlier population,’ Hodgson wrote of the Kusunda and Chepang.',
    likes: 89,
    createdOn: new Date("2023-10-06T14:44:04.7655807"),
    createdBy: {
      id: 'dskfldks',
    }
  },
    {
      id: 'Very very long title',
      title: 'Preserve Mother Tongues',
      description: 'Lingua franca refers to a common language between speakers whose mother tongues  are different. In Nepali,  it is also known as \'Samparka Bhasha\'. In the context of Nepal, Nepali is spoken as the main lingua franca in most parts of the country. Going back to history, Nepali became the national language of Nepal after a royal proclamation by late king Mahendra referring to a slogan of \'One nation, One language\'.Nepali language belongs to one of the biggest language family. Nepali is an Indo-Iranian (Indic) language. Sanskrit is known as the root  of Nepali language but  the Sanskrit language is now considered  a dead language.  We don\'t hear anybody communicating in Sanskrit. Religious texts  like Vedas and Tripitaka  which used to be written in native  Sanskrit and Pali respectively are now translated into Nepali. In the current period,  textbooks are only available in Nepali or English. \ Nepali language serves  as an official language in education, administration, media, publication and governmental offices. Article 7 of the constitution has recognised Nepali as the coutnry\'s official language. According to the first census of Nepal which was held in 1959, 44 mother tongues were recorded but 2011 census recoded 123 languages. Around 129 languages are spoken in Nepal. Among them, many  languages and dialects are on the verge of disappearing due to having only few speakers left. Nepali being  a lingua franca, indigenous languages like Rana Tharu, Dura, Kusunda, Yamphu and Tillung and many other languages like them are on the verge of extinction. ',
      likes: 89,
      createdOn: new Date("2023-10-06T14:44:04.7655807"),
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
