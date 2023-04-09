using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;

namespace PlayGuide
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Load Urbanist Font
            var urbanistfont = Typeface.CreateFromAsset(Assets, "fonts/Urbanist.ttf");

            TextView txt = FindViewById<TextView>(Resource.Id.nht);
            TextView tx2 = FindViewById<TextView>(Resource.Id.textView1);
            txt.PaintFlags |= PaintFlags.UnderlineText;
            txt.Typeface = urbanistfont;
            tx2.Typeface = urbanistfont;
            tx2.SetTypeface(tx2.Typeface, TypefaceStyle.Bold);

            txt.Click += (sender, e) =>
            {
                //This should Open up a browser
                Intent browserIntent = new Intent(Intent.ActionView, Uri.Parse("https://github.com/PlayGuide-org/PlayGuide/blob/main/Documentation/README.md"));
                StartActivity(browserIntent);
            };
            AppCompatButton btn1 = FindViewById<AppCompatButton>(Resource.Id.appCompatButton1);
            AppCompatButton btn2 = FindViewById<AppCompatButton>(Resource.Id.appCompatButton2);
            btn1.Typeface = urbanistfont;
            btn2.Typeface = urbanistfont;

            btn2.Click += (sender, args) =>
            {
                Process.KillProcess(Process.MyPid());
            };
            btn1.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(home));
                StartActivity(intent);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}