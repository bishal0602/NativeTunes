import { StyleSheet,Image } from 'react-native';
import { EvilIcons } from '@expo/vector-icons'; 
import playedData from "../../assets/data/played";


// import EditScreenInfo from '../../components/EditScreenInfo';
import { Text, View } from '../../components/Themed';

export default function TabOneScreen() {
  return (
    <View style={styles.container}>
      {/* blocktitle */}
      <View style={styles.titleblock}>
        {/* tile */}
        <View style={styles.texttitle}>
          <Text style={styles.titlemain}>Welcome Back!</Text>
          <Text style ={styles.titlesec}> Find today's best podcasts</Text>
        </View>
        {/* search button */}
        <View style={styles.searchbtn}>
        <EvilIcons name="search" size={24} color="white"  />
        </View>
      </View>
      {/* played image */}
      <View style={styles.played}>
      </View>



    </View>
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
    paddingHorizontal: 20,
    fontSize:24,
    fontWeight: 'semi-bold',
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
