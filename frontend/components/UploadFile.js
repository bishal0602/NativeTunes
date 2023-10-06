import React, { useState } from "react";
import { View, Text, TouchableOpacity } from "react-native";
import * as DocumentPicker from "expo-document-picker";
import axios from "axios";

const UploadFile = () => {
  const [selectedFile, setSelectedFile] = useState(null);

  const pickDocument = async () => {
    try {
      const result = await DocumentPicker.getDocumentAsync();
      if (result.type === "success") {
        setSelectedFile(result);
      }
    } catch (error) {
      console.error("Error picking document:", error);
    }
  };

  const handleUpload = () => {
    // Implement file upload logic using Axios or your preferred method
    // Example:
    // axios.post('YOUR_UPLOAD_URL', { file: selectedFile });
  };

  return (
    <View>
      <TouchableOpacity onPress={pickDocument}>
        <Text>Select File</Text>
      </TouchableOpacity>
      {selectedFile && (
        <TouchableOpacity onPress={handleUpload}>
          <Text>Upload File</Text>
        </TouchableOpacity>
      )}
    </View>
  );
};

export default UploadFile;
