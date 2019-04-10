﻿namespace Bit.App.Abstractions
{
    public interface IDeviceActionService
    {
        void Toast(string text, bool longDuration = false);
        bool LaunchApp(string appName);
    }
}