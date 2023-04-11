using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayGuide
{
    [Activity(Label = "Mlb")]
    public class Mlb : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mlb);
            // Create your application here

            //Return Btn
            AppCompatButton ret = FindViewById<AppCompatButton>(Resource.Id.btn);
            ret.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(Ld));
                StartActivity(intent);
            };
        }
    }
}