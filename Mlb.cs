using Android.App;
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

namespace PlayGuide
{
    [Activity(Label = "Mlb")]
    public class Mlb : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mlb);

            //Load App Font
            var urbanistfont = Typeface.CreateFromAsset(Assets, "fonts/Urbanist.ttf");

            TextView tx1 = FindViewById<TextView>(Resource.Id.textView1);
            TextView tx2 = FindViewById<TextView>(Resource.Id.textView2);
            TextView tx3 = FindViewById<TextView>(Resource.Id.textView3);
            TextView tx4 = FindViewById<TextView>(Resource.Id.guide);
            TextView tx5 = FindViewById<TextView>(Resource.Id.src);
            TextView tx6 = FindViewById<TextView>(Resource.Id.datsrc);
            //App Title
            tx1.Typeface = urbanistfont;
            tx1.SetTypeface(tx1.Typeface, TypefaceStyle.Bold);
            //Game Title
            tx2.Typeface = urbanistfont;
            tx2.SetTypeface(tx2.Typeface, TypefaceStyle.Bold);
            //Game Description
            tx3.Typeface = urbanistfont;
            //Guide
            tx4.Typeface = urbanistfont;
            tx4.SetTypeface(tx4.Typeface, TypefaceStyle.Bold);
            //Source
            tx5.Typeface = urbanistfont;
            tx6.Typeface = urbanistfont;
            tx6.SetTypeface(tx6.Typeface, TypefaceStyle.Bold);

            //Return Btn
            AppCompatButton ret = FindViewById<AppCompatButton>(Resource.Id.btn);
            ret.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(home));
                StartActivity(intent);
            };
        }
    }
}