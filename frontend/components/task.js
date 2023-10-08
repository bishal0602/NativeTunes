import React, {useState} from "react";
import { View, Text, StyleSheet, FlatList } from "react-native";
import {
  MaterialCommunityIcons,
  Ionicons,
  FontAwesome,
} from "@expo/vector-icons";

// let comments = [
//   {
//     id: 'asdfljk',
//     content: 'Hello Namaste',
//   },
//   {
//     id: 'akl',
//     content: 'Hello Namaste',
//   },
//   {
//     id: 'lkkl',
//     content: 'Hello Namaste',
//   },
// ]

const commentsData = [
  { id: '1', text: 'There is a beginner friendly book called \'Nepali Ranjana Lipi\'' },
  { id: '2', text: 'Why don\'t you visit websie \'www.ctl.edu.np\' for some survey'},
  { id: '3', text: 'If you are comfortable, why not visit Jumla with me to know about the language more.' },
];

const renderItem = ({ item }) => {
  return (
    <View style={{ padding: 10 }}>
      <View style={{
        flexDirection: "row",
      }}>
        <Text style={{
          fontWeight: "bold",
        }}>{`User${item.id}`}</Text>
        <Text style={{
          paddingLeft: 10,
          width: 300,
        }}>{item.text}</Text>
      </View>
    </View>
  );
};

const Task = (props) => {
  const [isVisible, setIsVisible] = useState(false);
  const toggleComment = () => {
    setIsVisible(!isVisible);
  }
  return (
    <View style={styles.main}>
      <View style={styles.item}>
        <View style={styles.itemLeft}>
          <MaterialCommunityIcons
            name="pencil-box-multiple-outline"
            size={24}
            color="black"
          />
          <Text style={{
            paddingLeft: 10,
            fontWeight: "bold",
          }}>Anonymous</Text>
        </View>
        <Text style={styles.itemText}>{props.text}</Text>
        <View style={styles.like}>
          <FontAwesome
            name="heart-o"
            size={24}
            color="black"
            style={{ marginRight: 5 }}
          />

          <Ionicons name="chatbox-outline" size={24} color="black" onPress={toggleComment} />
        </View>
      </View>
      <View style={styles.cmnt}></View>
      {isVisible && <View style={styles.visibleView}>
          {/* <Text style={styles.visibleText}>This is a visible View!</Text> */}
          <FlatList
           data={commentsData}
           renderItem={renderItem}
           keyExtractor={(item) => item.id}
           />
        </View>}
    </View>
  );
};
const styles = StyleSheet.create({
  main: {
    flexDirection: "column",
    borderRadius: 0,
    // borderColor: 'red',
    // borderWidth: 10
    marginBottom: 5,
  },
  item: {
    backgroundColor: "#fff",

    padding: 15,
    borderRadius: 0,
    flexDirection: "column",
    alignItems: "flex-start",
    marginBottom: 0,
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
  visibleView: {
    backgroundColor: 'white',
    padding: 5,
    // marginTop: 20,
    borderRadius: 0,
  },
});
export default Task;
