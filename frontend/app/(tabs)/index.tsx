import { StyleSheet} from "react-native";

import { View } from "../../components/Themed";
import Welcome from "../../components/Welcome";
import { MainScreenPlayer } from "../../components/MainScreenPlayer";
import RecentlyPlayed from "../../components/RecentlyPlayed";
import { ScrollView } from "react-native-gesture-handler";
import recentlyplayedData from "../../assets/data/recentlyplayed";
import PopularData from "../../components/PopularData";
import popularData from "../../assets/data/popularData";
import Upload from "../upload";

export default function TabOneScreen() {
  const image1Source = require("../../assets/images/kumari.png");
  const image2Source = require("../../assets/images/ind2.jpg");
  return (
    // <ScrollView>
    //   <View style={styles.container}>
    //     {/* blocktitle */}
    //     <Welcome />

    //     {/* played image */}

    //     <MainScreenPlayer
    //       title="Life As A Newar"
    //       albumArt={image1Source}
    //       time="15 mins of listening"
    //     ></MainScreenPlayer>
    //     <RecentlyPlayed
    //       recentlyplayedData={recentlyplayedData}
    //     ></RecentlyPlayed>
    //     <PopularData popularData={popularData}></PopularData>
    //   </View>
    // </ScrollView>
    <Upload />
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
