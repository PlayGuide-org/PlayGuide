﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PlayGuide
{
    [Activity(Label = "home")]
    public class home : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home);
            // Create your application here
            var urbanistfont = Typeface.CreateFromAsset(Assets, "fonts/Urbanist.ttf");
            TextView tx1 = FindViewById<TextView>(Resource.Id.textView1);
            tx1.Typeface = urbanistfont;
            tx1.SetTypeface(tx1.Typeface, TypefaceStyle.Bold);

            AppCompatButton abt = FindViewById<AppCompatButton>(Resource.Id.about);
            abt.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(About));
                StartActivity(intent);
            };
        }
    }
}