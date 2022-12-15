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
    public class InputStick : IAutoTyper
    {
        public Layout layout { get; set; } = Layout.en_US;
        public int speed { get; set; } = 1;
        public void Type(String text)
        {
            var context = Application.Context;
            InputStickBroadcast.Type(context,text,"es-ES",speed);
        }

        private String LayoutString(Layout layout)
        {
            switch (layout)
            {
                case Layout.en_US: 
                    return "en-US";
                case Layout.
            }
        }
    }
}
