import {StyleSheet, Image,ImageBackground} from 'react-native';
import { Text, View } from './Themed';
import { ImageSourcePropType } from 'react-native';
import { EvilIcons } from '@expo/vector-icons';




export function MainScreenPlayer({albumArt, title, time}: {albumArt: ImageSourcePropType, title:string, time: string}){
    return <View style={styles.mainScreencontainer}>
        <ImageBackground 
        source={albumArt} style={styles.backgroundImage} borderRadius={15}  >
        <View style={styles.imagetxt} >
            <Text style={styles.imgtitle}>{title}</Text>
            <View style={styles.time}>
                <EvilIcons name="clock" size={15} color="white" style={styles.clock}/>
                <Text style={styles.imgtime}>{time}</Text> 
            </View>
        </View>   
            </ImageBackground>

    
    </View>
}



const styles = StyleSheet.create({ 
    mainScreencontainer:{
        height: 200,
        margin:10,


    },
    backgroundImage: {
        
        flex: 1,
        justifyContent: 'flex-end',
        alignItems: 'center',
        width:'100%',
        borderRadius:10,
      },
    imagetxt:{
        // borderColor:'red',
        // borderWidth:10,
        backgroundColor: 'rgba(0,0,0,0.4)', 
        borderRadius: 15,
        width:'90%',
        height: 60,
        marginStart:20,
        marginBottom: 10,
        padding:10,

         
    },
    imgtitle: {
        fontSize: 18,
        color: '#FFFFFF',
        fontStyle: 'italic',
      },
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

 });

