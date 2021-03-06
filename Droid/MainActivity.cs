﻿using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Application.Droid;
using ImageCircle.Forms.Plugin.Droid;
using Lottie.Forms.Droid;
using Plugin.MediaManager.Forms.Android;
using Xamarin.Forms.Platform.Android;

namespace SampleApplication
{
    [Activity(Label = "Highrise Lottie",
              Icon = "@drawable/icon",
              Theme = "@style/splashscreen",
              MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //TODO: replace with Forms.Context
        private static Context _appContext;

        public static Context AppContext
        {
            get { return _appContext; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Droid.Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Droid.Resource.Layout.tabs;

            base.Window.RequestFeature(WindowFeatures.ActionBar);
            base.SetTheme(Droid.Resource.Style.MyTheme); //set theme to Material AppCompat
            base.OnCreate(bundle);

            _appContext = this;

            global::Xamarin.Forms.Forms.Init(this, bundle);

            AnimationViewRenderer.Init();
            ImageCircleRenderer.Init();
            UserDialogs.Init(this);
            Plugin.Toasts.ToastNotification.Init(this);
            VideoViewRenderer.Init();

            LoadApplication(new App(new IocAndroidModule()));
        }
    }
}