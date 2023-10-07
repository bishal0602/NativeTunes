import React, { useState } from "react";
import { Image, View, Text, StyleSheet, Pressable } from "react-native";

import { Entypo } from "@expo/vector-icons";
import { Product } from "../app/(tabs)/ApiService";


interface PostProp {
  data: Product;
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
// TODO: update user
  return (
    <View style={styles.container}>
      <View style={styles.userInfo}>
        <Image
          style={styles.avatar}
          source={{ uri: data.createdBy? data.createdBy.profilePicture : "https://fh-sites.imgix.net/sites/3119/2019/08/30165753/IMG_9940-scaled.jpg?auto=compress%2Cformat&w=1000&h=1000&fit=max"}}
        />
        <Text style={styles.username}>{data.createdBy ? `${data.createdBy.firstName} ${data.createdBy.lastName}`: "Ramu Chamling"} </Text>
      </View>

      <Image style={styles.postImage} source={{ uri: data.imageUrl }} />

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
            backgroundColor: '#ED6A5A',
            alignItems: 'center',
            width: 50,
            borderRadius: 5,
            padding: 5,
            marginLeft: 312,
            marginTop: 2,
            cursor: 'pointer',
          }}
        >
          <Text style={{
            color: 'white',
          }}>Buy</Text>
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
    width: 410,
    //   height: 300,
    aspectRatio: 1,
    //   borderRadius: 10,
  },
  caption: {
    padding: 10,
    fontWeight: "bold",
  },
});
