import {StyleSheet} from 'react-native';
import { Text, View } from './Themed';


export function MainScreenPlayer({albumArt, title, time}: {albumArt: string, title:string, time: string}){
    return <View style={styles.container}>
        <Text>{albumArt}</Text>
        <Text>{title}</Text>
        <Text>{time}</Text>        
    </View>
}

const styles = StyleSheet.create({
    container:{
        flex: 1,


    },
})