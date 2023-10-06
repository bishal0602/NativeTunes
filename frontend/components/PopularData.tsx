import {StyleSheet, Image,ImageBackground, FlatList} from 'react-native';
import { Text, View } from './Themed';
import { ImageSourcePropType } from 'react-native';
import { EvilIcons } from '@expo/vector-icons';
import popularData from '../assets/data/populardata';



export default function PopularData ({popularData} : {popularData : {}}) {
    const renderPopularDataItem=({item}: {item : { id: string, image: ImageSourcePropType, title:string}}) =>{
        return(
            <View style={styles.mixcontainer}>
                <Image source={item.image} style={styles.img}/>
                <Text style={styles.title}>{item.title}</Text>
            </View>
            
        )
    }




// function RecentlyPlayed({albumArt, title, time}: {albumArt: ImageSourcePropType, title:string, time: string}){
    return (
        <View style={styles.PopularDatacontainer}>
            <Text style={styles.PopularDatatext}>Popular Podcasts</Text>
            <View style={styles.recentlyPlayedlistWrapper}>
                <FlatList 
                data={popularData}
                renderItem={renderPopularDataItem}
                keyExtractor={item => item.id}
                horizontal={true}
                style={styles.recentlyPlayedlist}
                />

            </View>
        </View>
    )
};
        
    



const styles = StyleSheet.create({
    PopularDatacontainer:{
        flexDirection: 'column', 
        margin: 10,
    },
    PopularDatatext:{},
    mixcontainer:{
        width: 200,
        height: 250,
        flexDirection:'column',
        marginTop:10,
        marginHorizontal:7
    },
    recentlyPlayedlist:{
        flexDirection: "row",
    },
    img:{
        width:200,
        height: 200,
        // borderColor: 'red',
        // borderWidth: 10,
        marginRight:10,
        borderRadius: 10,
    },
    textBox:{
        flex:1,
        flexWrap: 'wrap',
        width:'80%',
        flexDirection:'column',
        height:100

    },
    title:{
        // wordWrap: 'break-word',
    },
    sub:{},
    time:{
        backgroundColor: 'rgba(0,0,0,0.0)', 
        flexDirection:'row',
      },
      clock:{
        marginRight:5,
        marginTop:4,
      },
    imgtime:{
        color:'#F5F5F5',
        font:10,
        opacity:0.7,
    },
    recentlyPlayedlistWrapper:{},

    
 })
