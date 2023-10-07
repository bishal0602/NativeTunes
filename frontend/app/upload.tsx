import React, { useState } from "react";
import {TouchableOpacity } from "react-native";
import {
  View,
  TextInput,
  StyleSheet,
  Pressable,
  Text,
  SafeAreaView,
} from "react-native";
import { AntDesign } from "@expo/vector-icons";
import Font from "../constants/Font";
import * as DocumentPicker from "expo-document-picker";

export default function Upload() {
  const [isFormComplete, setFormComplete] = useState(Array(5).fill(0))
  const [selectedAudioFile, setSelectedAudioFile] = useState<DocumentPicker.DocumentPickerResult | null>(null);
  const [selectedCover, setSelectedCover] = useState<DocumentPicker.DocumentPickerResult | null>(null);

  const pickDocument = async () => {
    try {
      const result = await DocumentPicker.getDocumentAsync();
      if (result.type  === "success") {
        setSelectedAudioFile(result);
      }
    } catch (error) {
      console.error("Error picking document:", error);
    }
  };

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
      <InputField place_holder="Title" secure={false} />
      <InputField place_holder="Description" secure={false} />
      <InputField place_holder="Language" secure={false} />
        <TouchableOpacity
          style={styles.button}
          onPress={pickDocument}
        >
          <Text>Select audio</Text>
        </TouchableOpacity>
      
      <View>

        <TouchableOpacity
          style={styles.button}
          onPress={pickDocument}
        >
          <Text>Select cover</Text>
        </TouchableOpacity>
      </View>
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
});
