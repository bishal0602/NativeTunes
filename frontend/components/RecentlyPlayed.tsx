import { StyleSheet, Image, ImageBackground, FlatList } from "react-native";
import { Text, View } from "./Themed";
import { ImageSourcePropType } from "react-native";
import { EvilIcons } from "@expo/vector-icons";

export default function RecentlyPlayed({
  recentlyplayedData,
}: {
  recentlyplayedData: {};
}) {
  const renderRecentlyPlayedItem = ({
    item,
  }: {
    item: {
      id: string;
      image: ImageSourcePropType;
      title: string;
      time: string;
    };
  }) => {
    return (
      <View style={styles.mixcontainer}>
        <Image source={item.image} style={styles.img} />
        <View style={styles.textBox}>
          <Text style={styles.title}>{item.title}</Text>
          <View style={styles.time}>
            <EvilIcons
              name="clock"
              size={15}
              color="white"
              style={styles.clock}
            />
            <Text style={styles.imgtime}>{item.time}</Text>
          </View>
          {/* <Text style={styles.sub}>{time}</Text> */}
        </View>
      </View>
    );
  };

  // function RecentlyPlayed({albumArt, title, time}: {albumArt: ImageSourcePropType, title:string, time: string}){
  return (
    <View style={styles.recentlyPlayedcontainer}>
      <Text style={styles.recenttext}>Recently Played</Text>
      <View style={styles.recentlyPlayedlistWrapper}>
        <FlatList
          data={recentlyplayedData}
          renderItem={renderRecentlyPlayedItem}
          keyExtractor={(item) => item.id}
          vertical={true}
        />
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  recentlyPlayedcontainer: {
    flexDirection: "column",

    margin: 10,
  },
  recenttext: {},
  mixcontainer: {
    flexDirection: "row",
    marginTop: 10,
  },
  img: {
    width: 100,
    height: 100,
    // borderColor: 'red',
    // borderWidth: 10,
    marginRight: 10,
    borderRadius: 10,
  },
  textBox: {
    flex: 1,
    flexWrap: "wrap",
    width: "80%",
    flexDirection: "column",
    height: 100,
  },
  title: {
    width: "100%",
    // wordWrap: 'break-word',
  },
  sub: {},
  time: {
    backgroundColor: "rgba(0,0,0,0.0)",
    flexDirection: "row",
  },
  clock: {
    marginRight: 5,
    marginTop: 4,
  },
  imgtime: {
    color: "#F5F5F5",
    // font:10,
    opacity: 0.7,
  },
  recentlyPlayedlistWrapper: {},
});
