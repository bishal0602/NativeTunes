import { StyleSheet } from 'react-native';
import { EvilIcons } from '@expo/vector-icons'; 


// import EditScreenInfo from '../../components/EditScreenInfo';
import { Text, View } from '../../components/Themed';
import Welcome from '../../components/Welcome';


export default function MarketplaceScreen() {
  return (
    <View style={styles.container}>
      <Welcome/>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#111111",
    alignContent: 'center',
  },
})