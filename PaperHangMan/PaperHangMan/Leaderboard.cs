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

using PaperHangMan;

namespace PaperHangMan
{
    [Activity(Label = "Leaderboard", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Leaderboard : Activity
    {

        ListView listLeaderboard;
        Button btnReturn;

        List<ListOScores> Leaderboardlist;

        DatabaseManager objDb;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LeaderboardDesign);

            listLeaderboard = FindViewById<ListView>(Resource.Id.listView1);
            btnReturn = FindViewById<Button>(Resource.Id.btnReturn);

            objDb = new DatabaseManager();
            Leaderboardlist = objDb.ViewLeaderboard();

            listLeaderboard.Adapter = new DataAdapter(this, Leaderboardlist);

            btnReturn.Click += BtnReturn_Click;

        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}