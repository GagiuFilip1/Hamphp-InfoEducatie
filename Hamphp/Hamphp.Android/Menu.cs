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
            Label = "Hamph",
            AlwaysRetainTaskState = true,
            Icon = "@drawable/icon",
            Theme = "@android:style/Theme.NoTitleBar",
            ScreenOrientation = ScreenOrientation.Portrait,
            LaunchMode = LaunchMode.SingleInstance,
            MainLauncher = true)
           // ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)
        ]

    public class Menu : Activity
    {
        public string a = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Bridge);
            Button Play = FindViewById<Button>(Resource.Id.playbutton);
            Play.Click += delegate {
                Intent intent = new Intent(this, typeof(MainActivity));
                this.StartActivity(intent);
                this.Finish();
            };
            Button Setings = FindViewById<Button>(Resource.Id.setingsbutton);
            Setings.Click += delegate
            {
                try
                {
                    Intent intent = new Intent(this, typeof(SensorHandler));
                    this.StartActivity(intent);
                    this.Finish();
                }
                catch (Exception ex) {
                    Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();

                }
            };
        }

    }
}