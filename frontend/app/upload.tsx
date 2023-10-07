import React, { useState, useEffect } from "react";
import {TouchableOpacity} from "react-native";
import RNFS from "react-native-fs"
import {
  View,
  TextInput,
  StyleSheet,
  Pressable,
  Text,
  SafeAreaView,
  Alert
} from "react-native";
import { AntDesign } from "@expo/vector-icons";
import Font from "../constants/Font";
import DocumentPicker from 'react-native-document-picker';
import axios from "axios";

export default function Upload() {
  const [audioData, setAudioData] = useState('');
  const [imgData, setImageData] = useState('');
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const pickAudio = async () => {
    try {
      const result = await DocumentPicker.pick({
        type: [DocumentPicker.types.audio],
      });

      // Read the audio file
      const audioFile = await RNFS.readFile(result.uri, 'base64');
      setAudioData(audioFile);
    } catch (error) {
      if (DocumentPicker.isCancel(error)) {
        // User cancelled the picker
      } else {
        console.error('Error picking audio:', error);
      }
    }
  };

  const pickImage = async () => {
    try {
      const result = await DocumentPicker.pick({
        type: [DocumentPicker.types.images],
      });

      // Read the audio file
      const imgData = await RNFS.readFile(result.uri, 'base64');
      setImageData(imgData);
    } catch (error) {
      if (DocumentPicker.isCancel(error)) {
        // User cancelled the picker
      } else {
        console.error('Error picking audio:', error);
      }
    }
  };

  // const [isFormComplete, setFormComplete] = useState(false)
  // const [selectedAudio, setSelectedAudioFile] = useState<DocumentPicker.DocumentPickerResult | null>(null);
  // const [selectedCover, setSelectedCover] = useState<DocumentPicker.DocumentPickerResult | null>(null);

    // State variables to store form inputs,  
    // errors, and form validity 
    // const [name, setName] = useState(''); 
    // const [email, setEmail] = useState(''); 
    // const [password, setPassword] = useState(''); 
    // const [errors, setErrors] = useState({}); 
    // const [isFormValid, setIsFormValid] = useState(false); 
  
    // useEffect(() => { 
  
    //     // Trigger form validation when name,  
    //     // email, or password changes 
    //     validateForm(); 
    // }, [name, email, password]); 
  
    // const validateForm = () => { 
    //     let errors = {}; 
  
    //     // Validate name field 
    //     if (!name) { 
    //         errors.name = 'Name is required.'; 
    //     } 
  
    //     // Validate email field 
    //     if (!email) { 
    //         errors.email = 'Email is required.'; 
    //     } else if (!/\S+@\S+\.\S+/.test(email)) { 
    //         errors.email = 'Email is invalid.'; 
    //     } 
  
    //     // Validate password field 
    //     if (!password) { 
    //         errors.password = 'Password is required.'; 
    //     } else if (password.length < 6) { 
    //         errors.password = 'Password must be at least 6 characters.'; 
    //     } 
  
    //     // Set the errors and update form validity 
    //     setErrors(errors); 
    //     setIsFormValid(Object.keys(errors).length === 0); 
    // }; 
  
    // const handleSubmit = () => { 
    //     if (isFormValid) { 
  
    //         // Form is valid, perform the submission logic 
    //         console.log('Form submitted successfully!'); 
    //     } else { 
              
    //         // Form is invalid, display error messages 
    //         console.log('Form has errors. Please correct them.'); 
    //     } 
    // }; 

    // useEffect(() => {
      
    // }, [])

  

  const handleUpload = () => {

  }

  return (
    <SafeAreaView style={styles.container}>
      <Text style={{
        color: 'white',
        fontSize: 30,
      }}>
        Upload Podcast
      </Text>
      <View
      style={{
        borderBottomColor: 'white',
        borderBottomWidth: StyleSheet.hairlineWidth,
        width: 390,
        alignSelf: "center",
      }}
      />
      <InputField place_holder="UserName" secure={false} />
      <InputField place_holder="Email" secure={false} />
      <InputField place_holder="Password" secure={true} />
        <TouchableOpacity
          style={styles.button}
          onPress={pickAudio}
        >
          <Text>Select audio</Text>
        </TouchableOpacity>
      
      <View>

        <TouchableOpacity
          style={styles.button}
          onPress={picCover}
        >
          <Text>Select cover</Text>
        </TouchableOpacity>
      </View>
      <View
      style={{
        borderBottomColor: 'white',
        borderBottomWidth: StyleSheet.hairlineWidth,
        width: 390,
        alignSelf: "center",
      }}
      />
      <TouchableOpacity
          style={styles.button}
          onPress={handleUpload}
        >
          <Text>Upload</Text>
        </TouchableOpacity>
    </SafeAreaView>
    );
}

interface InputFieldProps {
  place_holder: string;
  secure: boolean;
}
function InputField({ place_holder, secure }: InputFieldProps) {
  return (
    <View>
      <TextInput
        placeholder={place_holder}
        style={styles.input}
        secureTextEntry={secure}
        placeholderTextColor="white"
        multiline
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: "center",
    justifyContent: "center",
  },
  text: {
    marginTop: 10,
    color: "#fff",
  },
  button: {
    width: 120,
    fontFamily: Font.regular,
    marginTop: 10,
    marginBottom: 10,
    alignItems: "center",
    padding: 16,
    borderRadius: 50,
    backgroundColor: "#eef5db",
    color: "#4f6367",
  },
  input: {
    width: 400,
    maxWidth: 300,
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

  line: {
    width: 600,
    lineHeight: 2,
  },
  error: { 
    color: 'red', 
    fontSize: 20, 
    marginBottom: 12, 
}, 
});
