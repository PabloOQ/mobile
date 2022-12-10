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

namespace Bit.Droid.Services.AutoTypers
{
    public class InputStick : IAutoTyperService
    {
        public void DirectType(String text)
        {
            var context = Application.Context;
            InputStickBroadcast.Type(context,text,"es-ES");
        }
    }
}
