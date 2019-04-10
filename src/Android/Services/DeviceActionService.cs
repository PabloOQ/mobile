﻿using Bit.App.Abstractions;
using Plugin.CurrentActivity;

namespace Bit.Droid.Services
{
    public class DeviceActionService : IDeviceActionService
    {
        private Android.Widget.Toast _toast;

        public void Toast(string text, bool longDuration = false)
        {
            if(_toast != null)
            {
                _toast.Cancel();
                _toast.Dispose();
                _toast = null;
            }
            _toast = Android.Widget.Toast.MakeText(CrossCurrentActivity.Current.Activity, text,
                longDuration ? Android.Widget.ToastLength.Long : Android.Widget.ToastLength.Short);
            _toast.Show();
        }

        public bool LaunchApp(string appName)
        {
            var activity = CrossCurrentActivity.Current.Activity;
            appName = appName.Replace("androidapp://", string.Empty);
            var launchIntent = activity.PackageManager.GetLaunchIntentForPackage(appName);
            if(launchIntent != null)
            {
                activity.StartActivity(launchIntent);
            }
            return launchIntent != null;
        }
    }
}