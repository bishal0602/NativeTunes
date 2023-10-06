import React,{useState} from 'react';
import { AntDesign,Feather } from '@expo/vector-icons';
import { KeyboardAvoidingView,TextInput, Platform, StyleSheet, TouchableOpacity, Keyboard } from 'react-native';
import Task from '../../components/task';

// import EditScreenInfo from '../../components/EditScreenInfo';
import { Text, View } from '../../components/Themed';

export default function ForumScreen() {
    const [task, setTask]=useState();
const [taskItems, setTaskItems]=useState([]);

const handleAddTask =()=> {
  Keyboard.dismiss()
  setTaskItems([...taskItems,task])
  setTask(null);
}



  return (
    
    <View style={styles.container}>
      
      
      <View style={styles.taskWrapper}>
        <Text style={styles.sectionTitle}>Ask your question</Text>
        
        <View style={styles.items}>
          {/* tasks wil go */}
          {
            taskItems.map((item,index)=>{
              return <Task key={index} text = {item} />
            }
            )}
          {/* <Task text="first task"/>
          <Task text="second task"/> */}
        </View>
      </View>

      {/* second input view */}
    <KeyboardAvoidingView
    behavior={Platform.OS=== "ios"? "padding": "height"}
    style={styles.writeTaskWrapper}>
    <TextInput style={styles.input}placeholder={'Ask a question'} value= {task} onChangeText={text => setTask(text)}/>
    <TouchableOpacity onPress={() => handleAddTask()}>
      <View style={styles.addWrapper}>
      <Feather name="send" size={24} color="black" />
      {/* <AntDesign name="plus" size={24} color="black" style={styles.addText}/> */}
      </View>
    </TouchableOpacity>

</KeyboardAvoidingView>


    </View>
  );
}









const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
  title: {
    fontSize: 20,
    fontWeight: 'bold',
  },
  separator: {
    marginVertical: 30,
    height: 1,
    width: '80%',
  },
});
