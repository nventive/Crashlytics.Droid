# Crashlytics.Droid

Firebase Crashlytics binding project for Android

## Description

Firebase Crashlytics does not support Xamarin.Android nor does it provides a binding project that we can use with our project.

Thanks to [Alexandre Chohfi](https://github.com/azchohfi) for the base implementation of Fabric Crashlytics.

PS:
The JAR files(extracted form the AAR files) are downloaded from [Maven](https://mvnrepository.com/artifact/com.crashlytics.sdk.android), 
Simply download the 5 AAR from maven and extract the classes.jar from each and rename them.

## Download

Not available yet.

## How to use

Create a firebase project and enable Crashlytics
Documentation on the setup of firebase project and native implementation is available [here](https://firebase.google.com/docs/crashlytics/get-started).

When the setup of Firebase Crashlytics is done. Download the Google-Service.json from firebase and add it at the root of the Android App and set the build action to GoogleServiceJson.

Download the source, compile the binding project or use the nuget package.
Make sure to also add the Xamarin.Firebase.Core nuget package to the solution. You can find it [here](https://www.nuget.org/packages/Xamarin.Firebase.Core/)

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

