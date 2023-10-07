import { Pressable, StyleSheet } from "react-native";
import { EvilIcons } from "@expo/vector-icons";
import { Link } from 'expo-router';

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
      <Link href="/signup" asChild>
        <Pressable>
          <View style={styles.searchbtn}>
            <EvilIcons name="user" size={35} color="white" />
          </View>
        </Pressable>
      </Link>
    </View>
    //   </View>
  );
}
const styles = StyleSheet.create({
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
    backgroundColor: "#585858",
    height: 40,
    width: 40,
    marginTop: 15,
    borderRadius: 8,
    justifyContent: "center",
    alignItems: "center",
    margin: 5,
  },
});
