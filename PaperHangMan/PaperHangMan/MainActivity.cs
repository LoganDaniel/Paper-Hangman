using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace PaperHangMan
{
    [Activity(Label = "PaperHangMan", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        Typeface tf = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/orangeJuice.ttf");
        TextView lblTitle;
        Button btnSingleLoad;
        Button btnMultiLoad;
        Button btnLeaderboard;
        Button btnQuit;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //Define 
            lblTitle = FindViewById<TextView>(Resource.Id.lblTitle);
            btnSingleLoad = FindViewById<Button>(Resource.Id.btnSingle);
            btnMultiLoad = FindViewById<Button>(Resource.Id.btnMulti);
            btnLeaderboard = FindViewById<Button>(Resource.Id.btnLeaderboard);
            btnQuit = FindViewById<Button>(Resource.Id.btnQuit);

            //Add custom font
            lblTitle.SetTypeface(tf, TypefaceStyle.Normal);
            btnSingleLoad.SetTypeface(tf, TypefaceStyle.Normal);
            btnMultiLoad.SetTypeface(tf, TypefaceStyle.Normal);
            btnLeaderboard.SetTypeface(tf, TypefaceStyle.Normal);
            btnQuit.SetTypeface(tf, TypefaceStyle.Normal);

            //Button click events
            btnSingleLoad.Click += BtnSingleLoad_Click;
            btnMultiLoad.Click += BtnMultiLoad_Click;
            btnLeaderboard.Click += BtnLeaderboard_Click;
            btnQuit.Click += BtnQuit_Click;


        }

        private void BtnSingleLoad_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HangmanGameCode));
        }

        private void BtnMultiLoad_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HangmanMulti));
        }

        private void BtnLeaderboard_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Leaderboard));
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(0);
            Java.Lang.JavaSystem.Exit(0);
        }
    }
}

