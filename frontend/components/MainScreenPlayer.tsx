import {StyleSheet, Image} from 'react-native';
import { Text, View } from './Themed';
import { ImageSourcePropType } from 'react-native';



export function MainScreenPlayer({albumArt, title, time}: {albumArt: ImageSourcePropType, title:string, time: string}){
    return <View style={styles.container}>
        <Image source={albumArt} />
        <Text>{title}</Text>
        <Text>{time}</Text>        
    </View>
}

const styles = StyleSheet.create({
    container:{
        flex: 1,


    },
})