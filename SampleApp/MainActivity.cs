using Android.App;
using Android.Widget;
using Android.OS;
using IO.Fabric.Sdk.Android;
using Com.Crashlytics.Android;

namespace SampleApp
{
	[Activity(Label = "SampleApp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Init Crashlytics
			Fabric.With(this, new Crashlytics());

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			// Test a crash
			button.Click += delegate { Crashlytics.Instance.Crash(); };
		}
	}
}

