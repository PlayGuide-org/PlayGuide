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

            //Load App font
            var urbanistfont = Typeface.CreateFromAsset(Assets, "fonts/Urbanist.ttf");
            //Load up Design Variables
            TextView tx1 = FindViewById<TextView>(Resource.Id.textView1);
            TextView tx2 = FindViewById<TextView>(Resource.Id.textView2); 
            TextView tx3 = FindViewById<TextView>(Resource.Id.textView3);
            TextView tx4 = FindViewById<TextView>(Resource.Id.textView4);
            TextView tx5 = FindViewById<TextView>(Resource.Id.textView5);
            TextView tx6 = FindViewById<TextView>(Resource.Id.textView6);
            TextView tx7 = FindViewById<TextView>(Resource.Id.end);
            TextView tx8 = FindViewById<TextView>(Resource.Id.textView8);
            //App Title
            tx1.Typeface = urbanistfont;
            tx1.SetTypeface(tx1.Typeface, TypefaceStyle.Bold);
            //MLBB Title
            tx2.Typeface = urbanistfont;
            tx2.SetTypeface(tx2.Typeface, TypefaceStyle.Bold);
            //CODM title
            tx3.Typeface = urbanistfont;
            tx3.SetTypeface(tx3.Typeface, TypefaceStyle.Bold);
            //CODM Description
            tx4.Typeface = urbanistfont;
            //L4D Title
            tx5.Typeface = urbanistfont;
            tx5.SetTypeface(tx5.Typeface, TypefaceStyle.Bold);
            //L4D Description
            tx6.Typeface = urbanistfont;
            //end
            tx7.Typeface = urbanistfont;
            //MLBB Description
            tx8.Typeface = urbanistfont;

            //Logic for opening next page
            //About Page
            AppCompatButton abt = FindViewById<AppCompatButton>(Resource.Id.about);
            abt.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(About));
                StartActivity(intent);
            };
            //Mobile Legends Page
            AppCompatButton mlb = FindViewById<AppCompatButton>(Resource.Id.appCompatButton3);
            mlb.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(Mlb));
                StartActivity(intent);
            };
            //Call of duty Mobile Page
            AppCompatButton cod = FindViewById<AppCompatButton>(Resource.Id.appCompatButton4);
            cod.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(Cod));
                StartActivity(intent);
            };
            //Left 4 Dead Page
            AppCompatButton ld = FindViewById<AppCompatButton>(Resource.Id.appCompatButton5);
            ld.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(Ld));
                StartActivity(intent);
            };
        }
    }
}