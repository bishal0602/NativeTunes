import React, { useState} from "react";
import { Image, View, Text, StyleSheet } from "react-native";

import { Entypo } from '@expo/vector-icons';
import { Product } from "./AppService";


interface PostProp{
    data: Product,
}

export default function Post({data}: PostProp) {
    const[isLiked, setLiked] = useState(false);
    const[likes, setLikes] = useState(data.likes);
    const handleLike = () => {
        setLiked(!isLiked);
        if(isLiked) {
            setLikes(preVal=>preVal-1);
        }
        else {
            setLikes(preVal=>preVal+1);
        }
    }
    // TODO
    return (
        <View style={styles.container}>
         
            <View style={styles.userInfo}>
            <Image
              style={styles.avatar}
              source={{uri: 'https://images.unsplash.com/photo-1511367461989-f85a21fda167?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8cHJvZmlsZXxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60'}}
            />
            <Text style={styles.username}>{"random user"}</Text>
          </View>
    
          
          <Image
            style={styles.postImage}
            source={{uri: data.imageUrl}}
          />

          <View style={{
            flexDirection: "row",
            // justifyContent: "space-between",
          }}
            >
                <Entypo style={{
                    marginLeft: 2,
                    marginTop: 2,
                }}
                name={isLiked? "heart": "heart-outlined"} 
                size={24} color="black" 
                onPress={handleLike}
                />

                <Text style={{
                    marginStart: 10,
                    marginTop: 5,
                }}>
                    {likes}
                </Text>

                <button style={{
                    borderRadius: 5,
                    padding: 5,
                    marginLeft: 200,
                    marginTop: 2,
                    
                }}>
                    Buy
                </button>
            </View>  
            
                

          <Text style={styles.caption}>{data.title}</Text>
            
            <Text style={{
                width: 300,
                paddingLeft: 10,
                paddingRight: 10,
            }}>
                {data.description}
            </Text>
        </View>
      );
}


const styles = StyleSheet.create({
    container: {
      backgroundColor: 'white',
      marginBottom: 10,
      borderWidth: 1,
      borderColor: '#ddd',
      borderRadius: 5,
    },
    userInfo: {
      flexDirection: 'row',
      alignItems: 'center',
      padding: 10,
    },
    avatar: {
      width: 40,
      height: 40,
      borderRadius: 20,
      marginRight: 10,
    },
    username: {
      fontWeight: 'bold',
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
  