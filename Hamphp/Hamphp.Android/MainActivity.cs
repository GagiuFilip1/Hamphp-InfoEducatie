using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Hamphp.Android;
using Android.Hardware;
using CocosSharp;

namespace Hamphp.Android
{
	[Activity(
		Label = "BouncingGame.Android",
		AlwaysRetainTaskState = true,
		Icon = "@drawable/icon",
		Theme = "@android:style/Theme.NoTitleBar",
		ScreenOrientation = ScreenOrientation.Portrait,
		LaunchMode = LaunchMode.SingleInstance,
		MainLauncher = false,
		ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)
	]

	public class MainActivity : Activity , ISensorEventListener
	{
		static object _syncLock = new object();
		SensorManager _sensorManager;
		TextView _sensorTextView;
		public string x;
		public string y;
		public string z;
		public void OnAccuracyChanged (Sensor sensor, SensorStatus accuracy)
		{
		//	throw new NotImplementedException ();
		}

		public void OnSensorChanged (SensorEvent e)
		{
			x = string.Format("{0:f}", e.Values[0]);
			y = string.Format("y={0:f}", e.Values[1]);
			z = string.Format("z={0:f}", e.Values[2]);
			GetAxes.a =  string.Format("{0:f}", e.Values[0]);
			GetAxes.b = string.Format("{0:f}", e.Values[1]);
			GetAxes.c = string.Format("z={0:f}", e.Values[2]);
			//Console.WriteLine (y);
		//	_sensorTextView.Text = GetAxes.X () + " " + GetAxes.Y() + " " + GetAxes.Z ();

		}

		protected override void OnResume()
		{

			base.OnResume();
			_sensorManager.RegisterListener(this,
				_sensorManager.GetDefaultSensor(SensorType.Accelerometer),
				SensorDelay.Ui);
		}
	
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			_sensorManager = (SensorManager)GetSystemService(Context.SensorService);
			_sensorTextView = FindViewById<TextView>(Resource.Id.accelerometer_text);
           
			CCGameView gameView = (CCGameView)FindViewById (Resource.Id.GameView);
			gameView.ViewCreated += LoadGame;
		}
		public static class GetAxes
		{
			
			public static string a = "" ,b = "" , c= "";

			public static string X()
			{
				return a;
			}
			public static string Y()
			{

				return b ;
			}
			public static string Z()
			{

				return c ;
			}

		}
		void LoadGame (object sender, EventArgs e)
		{
			CCGameView gameView = sender as CCGameView;

			if (gameView != null) {
				var contentSearchPaths = new List<string> () { "Fonts", "Sounds" };
				CCSizeI viewSize = gameView.ViewSize;

				int width = 900;
				int height = 1260;

				// Set world dimensions
				gameView.DesignResolution = new CCSizeI (width, height);

				// Determine whether to use the high or low def versions of our images
				// Make sure the default texel to content size ratio is set correctly
				// Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
				if (width < viewSize.Width) {
					contentSearchPaths.Add ("Images/Hd");
					CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
				} else {
					contentSearchPaths.Add ("Images/Ld");
					CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
				}

				gameView.ContentManager.SearchPaths = contentSearchPaths;

				CCScene gameScene = new CCScene (gameView);
				gameScene.AddLayer (new GameLayer ());
				gameView.RunWithScene (gameScene);
			}
		}
	}
}


