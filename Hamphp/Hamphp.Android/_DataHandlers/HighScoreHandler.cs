using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace HamphpAndroid
{
    [Activity       
        (Label = "BouncingGame.Android",
        AlwaysRetainTaskState = true,
        Icon = "@drawable/icon",
        Theme = "@android:style/Theme.NoTitleBar",
        ScreenOrientation = ScreenOrientation.Portrait,
        LaunchMode = LaunchMode.SingleInstance,
        MainLauncher = false,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)]
    public class HighScoreHandler : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HighScoreTable);
            
            ListView LevelView;
            TextView TextV = FindViewById<TextView>(Resource.Id.textV);
            LevelView = FindViewById<ListView>(Resource.Id.LevelsView);
            List<string> Levels = new List<string>();
            List<string> LevelMetadata = new List<string>();
            string Data = "Level";string MetaData = "";

            TextV.Text = "\n";

            for (int i = 1; i <= 5; i++)
                {
              
                    Data = Data + i.ToString();
                    Levels.Add(Data);
                    Data = "Level";
                }


            ISharedPreferences pref = Application.Context.GetSharedPreferences("LevelData", FileCreationMode.Private);
            foreach (string info in Levels)
            {
              
                    MetaData = pref.GetString(info, String.Empty);
                
                    if (MetaData != String.Empty)
                    {
                    TextV.Text =TextV.Text + MetaData + "\n";           
                    }
                    else
                    {
                        
                    }
              

            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,LevelMetadata);

            TextV.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Menu));
                this.StartActivity(intent);
                this.Finish();
            };
        }
    }
}