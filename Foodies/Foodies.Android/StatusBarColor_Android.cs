using Android.OS;
using Foodies.Droid;
using Foodies.Views.VisualEffects;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarColor_Android))]

namespace Foodies.Droid
{ 
    public class StatusBarColor_Android : IStatusBarColor
    {
        public void MakeMe(string color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var c = MainActivity.context as FormsAppCompatActivity;
                c?.RunOnUiThread(() => c.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor(color)));
            }
        }
    }
}