using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PurduePasta;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
    ScreenOrientation = ScreenOrientation.Portrait,
    Exported = true)]
public class MainActivity : MauiAppCompatActivity
{
}
