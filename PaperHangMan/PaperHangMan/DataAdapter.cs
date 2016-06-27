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
using Java.Net;
using Android.Graphics;
using Java.IO;
using Android.Graphics.Drawables;
using Android.Util;
using System.Net;
using System.IO;

namespace PaperHangMan
{
        public class DataAdapter : BaseAdapter<ListOScores>
        {
            List<ListOScores> items;

            Activity context;
            public DataAdapter(Activity context, List<ListOScores> items): base()
            {
                this.context = context;
                this.items = items;
            }
           
            public override long GetItemId (int position)
            {
                return position;
            }
            public override ListOScores this[int position]
            {
                get { return items[position]; }
            }
            public override int Count
            {
                get { return items.Count; }
            }
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var item = items[position];
                View view = convertView;
                if (view == null) // no view to re-use, create new
                    view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

                view.FindViewById<TextView>(Resource.Id.lbltitle).Text = item.HangName;
                view.FindViewById<TextView>(Resource.Id.lblScore).Text = "Score: " + item.HangScore.ToString();
                view.FindViewById<TextView>(Resource.Id.lblTotalLetters).Text = "Letters: " + item.HangLetterAmt.ToString();
                return view;
            }

        }
    }