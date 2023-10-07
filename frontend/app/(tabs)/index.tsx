import { StyleSheet} from "react-native";

import { View } from "../../components/Themed";
import Welcome from "../../components/Welcome";
import { MainScreenPlayer } from "../../components/MainScreenPlayer";
import RecentlyPlayed from "../../components/RecentlyPlayed";
import { ScrollView } from "react-native-gesture-handler";
import PopularPodcasts from "../../components/PopularPodcasts";
import popularData from "../../assets/data/popularData";
import { useEffect, useState } from "react";
import { Podcast, fetchPodcasts } from "./ApiService";

export default function TabOneScreen() {
   const [podcasts, setPodcasts] = useState<Podcast[]>([]);
   const image1Source = require("../../assets/images/kumari.png");
   const image2Source = require("../../assets/images/ind2.jpg");
  useEffect(() => {
    const fetchPodcastsData = async () => {
      try {
        const data = await fetchPodcasts();
        setPodcasts(data);
      } catch (error) {
        console.error('Error fetching podcasts:', error);
      }
    };

    fetchPodcastsData();
  }, []);
  return (
    <ScrollView>
      <View style={styles.container}>
        {/* blocktitle */}
        <Welcome />

        {/* played image */}
{/* TODO */}
        <MainScreenPlayer
          title="Life As A Newar"
          albumArt={image1Source}
          time="15 mins of listening"
        ></MainScreenPlayer>
        <RecentlyPlayed
          recentlyplayedData={getRandomPodcasts(podcasts)}
        ></RecentlyPlayed>
        <PopularPodcasts podcasts={podcasts}></PopularPodcasts>
      </View>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#000",
    alignContent: "center",
  },
  titleblock: {
    justifyContent: "space-between",
    marginTop: 30,
    paddingHorizontal: 20,
    flexDirection: "row",
  },
  texttitle: {},
  titlemain: {
    // paddingHorizontal: 20,
    fontSize: 24,
    fontWeight: "600",
    color: "#FFFFFF",
  },
  titlesec: {
    paddingHorizontal: 20,
    paddingTop: 10,
    fontSize: 14,
    color: "#585858",
  },
  searchbtn: {
    height: 40,
    width: 40,
    backgroundColor: "#585858",
    borderRadius: 8,
    justifyContent: "center",
    alignItems: "center",
    margin: 5,
  },
});

function getRandomPodcasts(podcasts: Podcast[]): Podcast[] {
  const shuffledPodcasts = [...podcasts]; // Create a shallow copy of the array
  for (let i = shuffledPodcasts.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [shuffledPodcasts[i], shuffledPodcasts[j]] = [shuffledPodcasts[j], shuffledPodcasts[i]]; // Shuffle the array randomly
  }
  return shuffledPodcasts.slice(0, 2); // Return the first two elements (randomly chosen)
}