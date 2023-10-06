import React, { useState } from "react";
import { Image, View, Text, StyleSheet, Pressable } from "react-native";

import { Entypo } from "@expo/vector-icons";

export interface Data {
  id: string;
  imgURL: string;
  createdBy: {
    profilePicture: string;
    userName: string;
  };
  createdOn: Date;
  title: string;
  likes: number;
  price: number;
  description: string;
}

interface PostProp {
  data: Data;
}

export default function Post({ data }: PostProp) {
  const [isLiked, setLiked] = useState(false);
  const [likes, setLikes] = useState(data.likes);
  const handleLike = () => {
    setLiked(!isLiked);
    if (isLiked) {
      setLikes((preVal) => preVal - 1);
    } else {
      setLikes((preVal) => preVal + 1);
    }
  };

  return (
    <View style={styles.container}>
      <View style={styles.userInfo}>
        <Image
          style={styles.avatar}
          source={{ uri: data.createdBy.profilePicture }}
        />
        <Text style={styles.username}>{data.createdBy.userName}</Text>
      </View>

      <Image style={styles.postImage} source={{ uri: data.imgURL }} />

      <View
        style={{
          flexDirection: "row",
          // justifyContent: "space-between",
        }}
      >
        <Entypo
          style={{
            marginLeft: 2,
            marginTop: 2,
          }}
          name={isLiked ? "heart" : "heart-outlined"}
          size={24}
          color="black"
          onPress={handleLike}
        />

        <Text
          style={{
            marginStart: 10,
            marginTop: 5,
          }}
        >
          {likes}
        </Text>

        <Pressable
          style={{
            borderRadius: 5,
            padding: 5,
            marginLeft: 200,
            marginTop: 2,
          }}
        >
          <Text>Buy</Text>
        </Pressable>
      </View>

      <Text style={styles.caption}>{data.title}</Text>

      <Text
        style={{
          width: 300,
          paddingLeft: 10,
          paddingRight: 10,
        }}
      >
        {data.description}
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: "white",
    marginBottom: 10,
    borderWidth: 1,
    borderColor: "#ddd",
    borderRadius: 5,
  },
  userInfo: {
    flexDirection: "row",
    alignItems: "center",
    padding: 10,
  },
  avatar: {
    width: 40,
    height: 40,
    borderRadius: 20,
    marginRight: 10,
  },
  username: {
    fontWeight: "bold",
    fontSize: 16,
  },
  postImage: {
    width: 300,
    //   height: 300,
    aspectRatio: 1,
    //   borderRadius: 10,
  },
  caption: {
    padding: 10,
    fontWeight: "bold",
  },
});
