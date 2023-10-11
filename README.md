# Native Tunes

### Listen in your Language

<br>

Introducing "Native Tunes" a revolutionary storytelling platform app designed to preserve indigenous languages and cultures through audio storytelling. Creators can easily upload their stories in audio format, ensuring the oral traditions and unique linguistic nuances of their indigenous communities are safeguarded for future generations.

The app goes beyond storytelling; it features an integrated marketplace where users can sell artifacts from their cultures, promoting economic empowerment and sustainable preservation. This marketplace serves as a hub for users to showcase and celebrate their heritage, offering a diverse range of cultural artifacts for enthusiasts to discover and purchase.

To foster community engagement and creative discussions, NativeTunes provides a dedicated forum where users can interact, exchange ideas, and explore various storytelling techniques. This space encourages collaboration, enabling individuals to connect with fellow enthusiasts, learn from one another, and enhance their storytelling skills while fostering a deeper appreciation for indigenous languages and cultures.

Nativetunes is more than a platform; it's a movement that empowers indigenous communities to share their rich heritage, embrace their unique identities, and contribute to the global tapestry of cultural diversity. Join us in preserving the heartbeat of indigenous languages and cultures, one story at a time.

## Contributors 👨‍💻

```
Krishant Timilsina          (@krishtimil)
Apil Chaudhary              (@tryo-apil)
Bindu Paudel                (@bigya01)
Bishal Panta                (@bishal0602)
```

## Tech Stack Used

The project used .NET for backend and React Native for frontend. Backend is exposed at a Azure point.

View OpenAPI specification [here](./backend/swagger.json).

<!-- <br>
<center><img src="agrify/assets/screens/language_crop.png" width="500" />
<br> -->

## Screenshots

<p float="left">
  <img src="readme_assets/screens/screen1.jpg" width="100" /> 
  <img src="readme_assets/screens/screen2.jpg" width="100" />
  <img src="readme_assets/screens/screen3.png" width="100" />
  <img src="readme_assets/screens/screen4.png" width="100" />

</p>
</center>

## 🔨 Build

### 📋 Requirements

To setup and use the project you will need to have the following tools installed:

- [NodeJs & npm](https://nodejs.org/en)
- [dotnet](https://dotnet.microsoft.com/en-us/download)

### ⬇️ Installation

Clone the repository

```bash
$ git clone https://github.com/krishtimil/native.git
```

## Frontend

Change the working directory to the newly cloned repository:

```bash
$ cd nativetunes/frontend
```

Run `npm install` to install the dependencies :

```bash
$ npm install
```

Start and natively compile the project using expo:

```bash
$ npx expo run:android
```

or for ios :

```bash
$ npx expo run:ios
```

## Backend

Update `appsettings.json` file

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "JwtSettings": {
    "Secret": "[JWT Secret]",
    "ExpirationTimeInMinutes": "[JWT Expiration Time]",
    "Issuer": "NativeTunes.API",
    "Audience": "NativeTunes.App"
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DatabaseConnectionString": "[Database Connection String]"
  },
  "AzureBlobService": {
    "StorageAccount": "[Azure Storage Account]",
    "Key": "[Azure Storage Key]"
  }
}
```
