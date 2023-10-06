import { StyleSheet } from "react-native";
import { EvilIcons } from "@expo/vector-icons";

// import EditScreenInfo from '../../components/EditScreenInfo';
import { Text, View } from "./Themed";

export default function Welcome() {
  return (
    // <View style={styles.container}>
    <View style={styles.titleblock}>
      {/* blocktitle */}
      {/* tile */}
      <View style={styles.texttitle}>
        <Text style={styles.titlemain}>Welcome Back!</Text>
        <Text style={styles.titlesec}> Find today's best podcasts</Text>
      </View>
      {/* search button */}
      <View style={styles.searchbtn}>
        <EvilIcons name="search" size={24} color="white" />
      </View>
    </View>
    //   </View>
  );
}
const styles = StyleSheet.create({
  // container: {
  //   flex: 1,
  //   backgroundColor: "#111111",
  //   alignContent: 'center',
  // },
  titleblock: {
    justifyContent: "space-between",
    marginTop: 30,
    paddingHorizontal: 15,
    flexDirection: "row",
    paddingBottom: 10,
  },
  texttitle: {},
  titlemain: {
    fontSize: 24,
    fontWeight: "600",
    color: "#FFFFFF",
  },
  titlesec: {
    //   paddingHorizontal: 20,
    //   paddingTop: 10,
    fontSize: 16,
    color: "#585858",
  },
  searchbtn: {
    height: 40,
    width: 40,
    marginTop: 15,
    backgroundColor: "#585858",
    borderRadius: 8,
    justifyContent: "center",
    alignItems: "center",
    margin: 5,
  },
});
