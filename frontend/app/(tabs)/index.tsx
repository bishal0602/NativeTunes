import { StyleSheet,Image } from 'react-native';
import { EvilIcons } from '@expo/vector-icons'; 
import playedData from "../../assets/data/played";


// import EditScreenInfo from '../../components/EditScreenInfo';
import { Text, View } from '../../components/Themed';
import Welcome from '../../components/Welcome';
import { MainScreenPlayer } from '../../components/MainScreenPlayer';
import { RecentlyPlayed } from '../../components/RecentlyPlayed';
import { ScrollView } from 'react-native-gesture-handler';

export default function TabOneScreen() {
  const image1Source=require('../../assets/images/kumari.png');
  const image2Source=require('../../assets/images/ind2.jpg');
  return (
    <ScrollView>
       <View style={styles.container}>
      {/* blocktitle */}
     <Welcome/>


      {/* played image */}
      
      <MainScreenPlayer title='Life As A Newar' albumArt={image1Source} time='15 mins of listening'></MainScreenPlayer>
      <RecentlyPlayed title='How to win in life Podcast Episode 4(Newari)' albumArt={image2Source} time='15 mins of listening'></RecentlyPlayed>


    </View>
    </ScrollView>
   
  );
}








const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#111111",
    alignContent: 'center',
  },
  titleblock: {
    justifyContent: 'space-between',
    marginTop:30,
    paddingHorizontal: 20,
    flexDirection: 'row',
  },
  texttitle :{},
  titlemain :{
    // paddingHorizontal: 20,
    fontSize:24,
    fontWeight: '600',
    color: "#FFFFFF"
  },
  titlesec:{
    paddingHorizontal: 20,
    paddingTop: 10,
    fontSize:14,
    color :"#585858",
  },
  searchbtn:{
    height:40,
    width: 40,
    backgroundColor: '#585858',
    borderRadius:8,
    justifyContent:'center',
    alignItems:'center',
    margin:5
  },
  
});
