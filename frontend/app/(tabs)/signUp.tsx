// import { Image } from "expo-image";
import React, { ReactNode, useState } from "react";
import { View, TextInput, StyleSheet, Pressable, Text} from 'react-native';
import { MaterialCommunityIcons } from '@expo/vector-icons'; 
import { AntDesign } from '@expo/vector-icons';
import { warmUpAsync } from "expo-web-browser";

export default function Sign() {

  // const [password, setPassword] = useState(''); 

  // const [showPassword, setShowPassword] = useState(false); 

  // const toggleShowPassword = () => { 
  //     setShowPassword(!showPassword); 
  // }; 

  function handleSignUp() {
    
  }
  function handleLogIn() {
    
  }

    return (
        <View style={styles.container}>
          <InputField place_holder='Username' secure={false}/>
          <InputField place_holder='Email Address' secure={false}/>
          <View>
            <InputField place_holder='Password' secure={true}/>
            {/* <MaterialCommunityIcons 
                    name={showPassword ? 'eye-off' : 'eye'} 
                    size={24} 
                    color="#aaa"
                    style={styles.icon} 
                    onPress={toggleShowPassword} 
            />  */}
          </View>
          <Pressable style={styles.button} onPress={handleSignUp}>Sign Up</Pressable>
          <hr style={styles.line} />
          <Pressable style={styles.signInButton} onPress={handleLogIn}>
            {/* <Image width={20} height={20} href={googleIcon}/> */}
        

            <AntDesign style={{
              paddingLeft: 10,
            }} name="google" size={24} color="black" />
            <Text style={{
              paddingLeft: 40,
              
            }}>
              Continue with Google
            </Text>

          </Pressable>
        </View>
    );
}
interface InputFieldProps{
  place_holder: string,
  secure: boolean,
}
function InputField({place_holder, secure}: InputFieldProps) {
  return (
    <View>
      <TextInput
          placeholder={place_holder}
          style={styles.input}
          secureTextEntry={secure}
        />
    </View>
  )
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      alignItems: 'center',
      justifyContent: 'center',
    },
    text: {
      marginTop: 10,
      color: '#fff',
    },
    button: {
      width: 300,
      fontFamily: 'Arial',
      marginTop: 10,
      marginBottom: 10,
      alignItems: 'center',
      padding: 16,
      borderRadius: 50,
      backgroundColor: '#eef5db', 
      color: '#4f6367',
    },
    input: {
      width: 600,
      maxWidth: 400,
      marginTop: 10,
      borderColor: "gray",
      borderWidth: 1,
      borderRadius: 20,
      padding: 10,
      color: "white",
    },
    icon: {
      width: 50,
      height: 50,    
    },
    signInButton: {
      flexDirection: "row",
      width: 300,
      fontFamily: 'Arial',
      marginTop: 10,
      marginBottom: 10,
      alignItems: 'center',
      padding: 16,
      borderRadius: 50,
      backgroundColor: '#eef5db', 
      color: '#4f6367',
    },
    line: {
      width: 600,
      lineHeight: 2,
    }
  },)