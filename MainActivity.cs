using Android.App;
using Android.OS;
using Android.Content.PM;

namespace OpenGLTest
{
    [Activity(Label = "OpenGLTest",
              ConfigurationChanges = ConfigChanges.KeyboardHidden,
              ScreenOrientation = ScreenOrientation.SensorLandscape,
              MainLauncher = true)]
    public class MainActivity : Activity
    {
        GLRenderer view;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            view = new GLRenderer(this);
            SetContentView(view);
        }

        protected override void OnPause()
        {
            base.OnPause();
            view.Pause();
        }

        protected override void OnResume()
        {
            base.OnResume();
            view.Resume();
        }
    }
}

