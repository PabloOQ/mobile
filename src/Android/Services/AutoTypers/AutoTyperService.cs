using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bit.Core.Abstractions;
using Com.Inputstick.Api.Broadcast;
using Bit.Core.Enums;

namespace Bit.Droid.Services.AutoTypers
{
    internal class AutoTyperService : IAutoTyperService
    {
        public IAutoTyper typer { get; set; }

        public AutoTyperService()
        {
            typer = new InputStick();
        }

        public void Type(string text)
        {
            typer.Type(text);
        }

        public Layout GetLayout() => typer.layout;
        public void SetLayout(Layout layout) => typer.layout = layout;
        public int GetSpeed() => typer.speed;
        public void SetSpeed(int speed) => typer.speed = speed;
    }
}
