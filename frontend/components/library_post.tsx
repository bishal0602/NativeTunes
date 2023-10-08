import React, { useState } from "react";
import { Image, View, Text, StyleSheet, Pressable } from "react-native";

import { Entypo } from "@expo/vector-icons";
import { Article } from "../app/(tabs)/ApiService";


interface ArticleProp {
  data: Article;
}

export default function TextPost({ data }: ArticleProp) {
  const [isLiked, setLiked] = useState(false);
  const [likes, setLikes] = useState(data.likes);
  const [isExpanded, setExpanded] = useState(false);
  const handleLike = () => {
    setLiked(!isLiked);
    if (isLiked) {
      setLikes((preVal) => preVal - 1);
    } else {
      setLikes((preVal) => preVal + 1);
    }
  };

  const expandCard = () => {
    setExpanded(!isExpanded);
  }
// TODO: update user
  return (
    <View style={styles.container}>
      
      <Text style={styles.caption}>{data.title}</Text>
      <View
      style={{
        borderBottomColor: 'black',
        borderBottomWidth: StyleSheet.hairlineWidth,
        width: 390,
        alignSelf: "center",
      }}
      />
      <Pressable onPress={expandCard}>
      <Text numberOfLines={isExpanded? 1000 : 4}
        style={{
          paddingTop: 8,
          width: 375,
          paddingLeft: 10,
          paddingRight: 10,

        }}
      >
        {data.description}
      </Text>
      </Pressable>

      <View
        style={{
          flexDirection: "row",
          // justifyContent: "space-between",
        }}
      >
        <View style={styles.userInfo}>
        <Image
          style={styles.avatar}
          source={{ uri: "https://www.computerhope.com/jargon/g/guest-user.png"}}
        />
        <Text style={styles.username}>Anonymous</Text>
      </View>
        <Entypo
          style={{
            marginLeft: 160,
            paddingTop: 10,
          }}
          name={isLiked ? "heart" : "heart-outlined"}
          size={24}
          color="black"
          onPress={handleLike}
        />

        <Text
          style={{
            marginStart: 10,
            paddingTop: 12,
          }}
        >
          {likes}
        </Text>
      
      </View>
      <View>
        <Text style={{
          paddingLeft: 50,
          marginVertical: 0,
        }}>
          {data.createdOn.toLocaleDateString()}
        </Text>
      </View>
      
  </View>
  );
}

const styles = StyleSheet.create({
  container: {
    alignSelf: "center",
    width: 375,
    backgroundColor: "white",
    marginTop: 5,
    marginBottom: 5,
    borderWidth: 1,
    borderColor: "#ddd",
    borderRadius: 5,
  },
  userInfo: {
    flexDirection: "row",
    alignItems: "center",
    paddingTop: 10,
  },
  avatar: {
    marginLeft: 10,
    width: 30,
    height: 30,
    borderRadius: 20,
    marginRight: 10,
  },
  username: {
    fontWeight: "bold",
    fontSize: 16,
  },
  postImage: {
    width: 410,
    //   height: 300,
    aspectRatio: 1,
    //   borderRadius: 10,
  },
  caption: {
    padding: 10,
    fontSize: 20,
    fontWeight: "bold",
  },
});

