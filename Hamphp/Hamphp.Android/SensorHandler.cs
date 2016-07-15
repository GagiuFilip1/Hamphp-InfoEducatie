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

namespace Hamphp.Android
{
    [Activity(
    Label = "BouncingGame.Android",
    AlwaysRetainTaskState = true,
    Icon = "@drawable/icon",
    Theme = "@android:style/Theme.NoTitleBar",
    ScreenOrientation = ScreenOrientation.Portrait,
    LaunchMode = LaunchMode.SingleInstance)
]
    public class SensorHandler : Activity
    {    
        protected override void OnCreate(Bundle bundle)
        {
            
            
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.Settings);

                ImageButton Back = FindViewById<ImageButton>(Resource.Id.BackBut);
                SeekBar seekBar = FindViewById<SeekBar>(Resource.Id.SensorBar);


               
                Back.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(Menu));
                    this.StartActivity(intent);
                    this.Finish();
                };

            try
            {
                float a;
                seekBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
                {
                    if (e.FromUser)
                    {
                        a = e.Progress;
                        if (a < 50)
                        {
                            SensorManage.x = (50-a) * 0.08f + 10;
                        }
                        if (a > 50)
                        {
                            SensorManage.x = 10 - (a-50) * 0.08f;
                        }
                        if (a == 50)
                        {
                            SensorManage.x = 10;
                        }
                    }
                };
            }
            catch { }
            
            }
        public static class SensorManage
        {
            public static float x;
            public static float SV()
            {
                return x;
            }
        }
    }

}