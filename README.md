# Crashlytics.Droid

This binding provides support for Fabric Crashlytics and Firebase Crashlytics (Firebase is the preferred and easiest way to make this work).

## Description

Firebase Crashlytics does not support Xamarin.Android nor does it provides a binding project that we can use with our project.

Thanks to [Alexandre Chohfi](https://github.com/azchohfi) for the base implementation of Fabric Crashlytics.

PS:
The JAR files(extracted form the AAR files) are downloaded from [Maven](https://mvnrepository.com/artifact/com.crashlytics.sdk.android), 
Simply download the 5 AAR from maven and extract the classes.jar from each and rename them.

## Download

Not available yet.

## How to use with Fabric

You will need to create an Android project on Android Studio and follow the installation guide from [Fabric Crashlytics](https://fabric.io/kits/android/crashlytics/install)

Make sure to have the same applicationId than your Xamarin.Android project

This will create an app project on Fabric (The binding is not able to create this for you).

Next step is to include the library to your Xamarin.Android project.

Add a meta data 
``` xml
<meta-data android:name="io.fabric.ApiKey" android:value="[YOUR-API-KEY]" />
```

or the preferred way in the Assembly info for environment control

``` csharp
#if PRODUCTION
[assembly: MetaData("io.fabric.ApiKey", Value = "[YOUR-API-KEY]")]
#else
[assembly: MetaData("io.fabric.ApiKey", Value = "[YOUR-API-KEY]")]
#endif
```

Since there is nothing equivalent to the crashlytics build tool for Xamarin, is a string resource named 'com.crashlytics.android.build_id', with your build_id, equivalent to your manifest's "android:versionName", or anything you want actually.

So add this to the file named Resources\values\String.xml:

	<?xml version="1.0" encoding="utf-8"?>
	<resources>
	  <string name="com.crashlytics.android.build_id">[BUILD-ID]</string>
	</resources>


Replace the [BUILD-ID] with your build id... something like 1.0.0, for example.

You also need to add permissions to access Internet, obviously.

	<uses-permission android:name="android.permission.INTERNET" />


At last, but not least, you need to add this to your activity's OnCreate method:

	IO.Fabric.Sdk.Android.Fabric.With(this, new Com.Crashlytics.Android.Crashlytics());

## How to use with Firebase

Create a firebase project and enable Crashlytics
Documentation on the setup of firebase project and native implementation is available [here](https://firebase.google.com/docs/crashlytics/get-started).

When the setup of Firebase Crashlytics is done. Download the Google-Service.json from firebase and add it at the root of the Android App and set the build action to GoogleServiceJson.

Download the source, compile the binding project or use the nuget package.
Make sure to also add the Xamarin.Firebase.Core nuget package to the solution. You can find it [here](https://www.nuget.org/packages/Xamarin.Firebase.Core/).

Since there is nothing equivalent to the crashlytics build tool for Xamarin, is a string resource named 'com.crashlytics.android.build_id', with your build_id, equivalent to your manifest's "android:versionName", or anything you want actually.

So add this to the file named Resources\values\String.xml:

	<?xml version="1.0" encoding="utf-8"?>
	<resources>
	  <string name="com.crashlytics.android.build_id">[BUILD-ID]</string>
	</resources>


Replace the [BUILD-ID] with your build id... something like 1.0.0, for example.

You also need to add permissions to access Internet, obviously.

	<uses-permission android:name="android.permission.INTERNET" />


At last, but not least, you need to add this to your activity's OnCreate method:

	IO.Fabric.Sdk.Android.Fabric.With(this, new Com.Crashlytics.Android.Crashlytics());


It's pretty strait forward.

If you want, you can add a pre-build script to your project to get the manifest's "android:versionName" and set it right into the String.xml file, but that's up to you.

### Use with multi environment setup 

To use with multiple envrionment you can use this setup

First of a Config folder at the root of the solution, containing a Dev and Production folder.
The in the csproj you can add this lines

``` csharp
<GoogleServicesJson Include="..\Config\Dev\google-services.json" Condition="'$(AppEnvironment)'!='Production'&&'$(AppEnvironment)'!='Staging'">
    <Link>google-services.json</Link>
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
</GoogleServicesJson>
<GoogleServicesJson Include="..\Config\Staging\google-services.json" Condition="'$(AppEnvironment)'=='Staging'">
    <Link>google-services.json</Link>
	<CopyToOutputDirectory>Always</CopyToOutputDirectory>
</GoogleServicesJson>
<GoogleServicesJson Include="..\Config\Prod\google-services.json" Condition="'$(AppEnvironment)'=='Production'">
    <Link>google-services.json</Link>
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
</GoogleServicesJson>
```

## Known Issues
The Xamarin.Android project needs to target API Level 26 (Android 8.0) to properly initialize with Firebase.
When using Fabric, the project needs to be created with a native project.

