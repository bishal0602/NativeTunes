import React from "react";
import { View, Text, StyleSheet } from "react-native";
import {
  MaterialCommunityIcons,
  Ionicons,
  FontAwesome,
} from "@expo/vector-icons";

const Task = (props) => {
  return (
    <View style={styles.main}>
      <View style={styles.item}>
        <View style={styles.itemLeft}>
          <MaterialCommunityIcons
            name="pencil-box-multiple-outline"
            size={24}
            color="black"
          />
          <Text style={styles.itemText}>{props.text}</Text>
        </View>
        <View style={styles.like}>
          <FontAwesome
            name="heart-o"
            size={24}
            color="black"
            style={{ marginRight: 5 }}
          />

          <Ionicons name="chatbox-outline" size={24} color="black" />
        </View>
      </View>
      <View style={styles.cmnt}></View>
    </View>
  );
};
const styles = StyleSheet.create({
  main: {
    flexDirection: "column",
    // borderColor: 'red',
    // borderWidth: 10
  },
  item: {
    backgroundColor: "#fff",

    padding: 15,
    borderRadius: 10,
    flexDirection: "column",
    alignItems: "flex-start",
    marginBottom: 20,
    justifyContent: "space-between",
  },
  itemLeft: {
    // borderColor: 'red',
    // borderWidth:3,
    flexDirection: "row",
    alignItems: "center",
    // flexWrap: 'wrap'
  },
  itemText: {
    paddingLeft: 10,
    fontSize: 15,
  },
  like: {
    marginTop: 7,
    flexDirection: "row",
    justifyContent: "flex-end",
  },
});
export default Task;
