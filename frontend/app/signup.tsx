// import { Image } from "expo-image";
import React, { ReactNode, useState } from "react";
import {
  View,
  TextInput,
  StyleSheet,
  Pressable,
  Text,
  SafeAreaView,
} from "react-native";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import { AntDesign } from "@expo/vector-icons";
import { warmUpAsync } from "expo-web-browser";
import Font from "../constants/Font";
import {
  GoogleSignin,
  statusCodes,
} from "@react-native-google-signin/google-signin";

const JWT_URL = "/api/login/google";

export default function SignUp() {
  // const [password, setPassword] = useState('');

  // const [showPassword, setShowPassword] = useState(false);

  // const toggleShowPassword = () => {
  //     setShowPassword(!showPassword);
  // };

  const [userInfo, setUserInfo] = useState({});

  function handleSignUp() {
    const vaa = 0;
  }
  async function sendToBackend({ id_token }: { id_token: string }) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", JWT_URL);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onload = function () {
      console.log("Signed in as: " + xhr.responseText);
    };
    xhr.send("idtoken=" + id_token);
  }
  async function handleSignInWIthGoogle() {
    try {
      await GoogleSignin.hasPlayServices();
      const userInfo = await GoogleSignin.signIn();
      setUserInfo(userInfo);
      var id_token = userInfo.idToken as string;
      sendToBackend({ id_token });
    } catch (error) {
      console.log(error);
      // if (error.code === statusCodes.SIGN_IN_CANCELLED) {
      //   // user cancelled the login flow
      // } else if (error!.code === statusCodes.IN_PROGRESS) {
      //   // operation (e.g. sign in) is in progress already
      // } else if (error.code === statusCodes.PLAY_SERVICES_NOT_AVAILABLE) {
      //   // play services not available or outdated
      // } else {
      //   // some other error happened
      // }
    }
  }

  return (
    <SafeAreaView style={styles.container}>
      <InputField place_holder="Username" secure={false} />
      <InputField place_holder="Email Address" secure={false} />
      <View>
        <InputField place_holder="Password" secure={true} />
        {/* <MaterialCommunityIcons 
                    name={showPassword ? 'eye-off' : 'eye'} 
                    size={24} 
                    color="#aaa"
                    style={styles.icon} 
                    onPress={toggleShowPassword} 
            />  */}
      </View>
      <Pressable
        style={styles.button}
        onPress={() => {
          handleSignUp();
        }}
      >
        <Text>Sign Up</Text>
      </Pressable>
      <Text numberOfLines={1} />
      <Pressable
        style={styles.signInButton}
        onPress={() => {
          handleSignInWIthGoogle();
        }}
      >
        {/* <Image width={20} height={20} href={googleIcon}/> */}

        <AntDesign
          style={{
            paddingLeft: 10,
          }}
          name="google"
          size={24}
          color="black"
        />
        <Text
          style={{
            paddingLeft: 40,
          }}
        >
          Continue with Google
        </Text>
      </Pressable>
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
    width: 300,
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
    fontFamily: Font.regular,
    marginTop: 10,
    marginBottom: 10,
    alignItems: "center",
    padding: 16,
    borderRadius: 50,
    backgroundColor: "#eef5db",
    color: "#4f6367",
  },
  line: {
    width: 600,
    lineHeight: 2,
  },
});
