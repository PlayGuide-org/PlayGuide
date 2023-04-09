using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using System.Net.Http;
using Newtonsoft.Json;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Android.Content.PM;
using Exception = System.Exception;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android;

namespace PlayGuide
{
    [Activity(Label = "About")]
    public class About : Activity
    {
        private const string ReleasesUrl = "https://api.github.com/repos/PlayGuide-org/PlayGuide/releases/latest";

        private const int RequestCodeStoragePermission = 100;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.about);

            //Load Urbanist Font
            var urbanistfont = Typeface.CreateFromAsset(Assets, "fonts/Urbanist.ttf");
            // Create your application here
            TextView tx1 = FindViewById<TextView>(Resource.Id.textView1);
            TextView tx2 = FindViewById<TextView>(Resource.Id.textView2);
            TextView tx3 = FindViewById<TextView>(Resource.Id.textView3);
            TextView tx4 = FindViewById<TextView>(Resource.Id.textView4);
            TextView tx5 = FindViewById<TextView>(Resource.Id.textView5);
            TextView tx6 = FindViewById<TextView>(Resource.Id.textView6);
            TextView tx7 = FindViewById<TextView>(Resource.Id.textView7);
            TextView tx8 = FindViewById<TextView>(Resource.Id.textView8);

            //About Text
            tx1.Typeface = urbanistfont;
            tx1.SetTypeface(tx1.Typeface, TypefaceStyle.Bold);
            //PlayGuide Text
            tx2.Typeface = urbanistfont;
            tx2.SetTypeface(tx2.Typeface, TypefaceStyle.Bold);
            //Description text
            tx3.Typeface = urbanistfont;
            //Version Text
            tx4.Typeface = urbanistfont;
            //
            tx5.Typeface = urbanistfont;
            tx5.SetTypeface(tx5.Typeface, TypefaceStyle.Bold);
            string versionName = PackageManager.GetPackageInfo(PackageName, 0).VersionName;
            tx5.Text = versionName;
            //Codename Text
            tx6.Typeface = urbanistfont;
            //
            tx7.Typeface = urbanistfont;
            tx7.SetTypeface(tx7.Typeface, TypefaceStyle.Bold);

            //Buttons
            AppCompatButton btn = FindViewById<AppCompatButton>(Resource.Id.btn);
            AppCompatButton btn1 = FindViewById<AppCompatButton>(Resource.Id.appCompatButton1);
            var checkUpdatesButton = FindViewById<AppCompatButton>(Resource.Id.appCompatButton2);
            AppCompatButton btn3 = FindViewById<AppCompatButton>(Resource.Id.appCompatButton3);
            checkUpdatesButton.Click += CheckForUpdatesButton_Click;

            btn1.Typeface = urbanistfont;
            btn1.SetTypeface(btn1.Typeface, TypefaceStyle.Bold);
            checkUpdatesButton.Typeface = urbanistfont;
            checkUpdatesButton.SetTypeface(checkUpdatesButton.Typeface, TypefaceStyle.Bold);

            btn.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(home));
                StartActivity(intent);
            };

            //Check Repo
            btn1.Click += (sender, args) =>
            {
                //This should Open up a browser
                Intent browserIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://github.com/PlayGuide-org/PlayGuide"));
                browserIntent.SetFlags(ActivityFlags.NewTask);
                StartActivity(browserIntent);
            };

            //Open new Issues
            btn3.Click += (sender, args) =>
            {
                //This should Open up a browser
                Intent browserIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://github.com/PlayGuide-org/PlayGuide/issues/new"));
                browserIntent.SetFlags(ActivityFlags.NewTask);
                StartActivity(browserIntent);
            };
        }
        // Button Update

        private async Task<JObject> GetLatestReleaseAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(ReleasesUrl);
                    response.EnsureSuccessStatusCode();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(responseContent);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exception
                return null;
            }
            catch (JsonReaderException ex)
            {
                // Handle JSON reader exception
                return null;
            }
        }

        private async void CheckForUpdatesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == Permission.Granted)
                {
                    var latestRelease = await GetLatestReleaseAsync();

                    if (latestRelease != null)
                    {
                        var currentVersion = PackageManager.GetPackageInfo(PackageName, 0).VersionName;
                        var latestVersion = latestRelease.Value<string>("tag_name").TrimStart('v');

                        if (currentVersion != latestVersion)
                        {
                            var releasesUrl = latestRelease.Value<string>("html_url");
                            ShowUpdatePopup(releasesUrl);
                        }
                        else
                        {
                            Toast.MakeText(this, "You are using the latest version", ToastLength.Short).Show();
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Unable to check for updates", ToastLength.Short).Show();
                    }
                }
                else
                {
                    ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.WriteExternalStorage }, RequestCodeStoragePermission);
                }
            }catch (Exception ex){
                Toast.MakeText(this, $"Error Checking updates: {ex.Message}", ToastLength.Long).Show();
            }
        }
         


        private void ShowUpdatePopup(string releasesUrl)
        {
            var builder = new AlertDialog.Builder(this);
            builder.SetMessage("A new update is available");
            builder.SetPositiveButton("Download", (s, e) =>
            {
                var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(releasesUrl));
                StartActivity(intent);
            });
            builder.SetNegativeButton("Cancel", (s, e) => { });
            var dialog = builder.Create();
            dialog.Show();
        }

            public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == RequestCodeStoragePermission)
            {
                if (grantResults[0] == Android.Content.PM.Permission.Granted)
                {
                    var checkUpdatesButton = FindViewById<Button>(Resource.Id.appCompatButton2);
                    checkUpdatesButton.PerformClick();
                }
                else
                {
                    Toast.MakeText(this, "Cannot check for updates without storage permission", ToastLength.Short).Show();
                }
            }
        }
    }
}
            