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
                case Layout.fr_BE:
                    return "fr-BE";
                case Layout.hr_HR:
                    return "hr-HR";
                case Layout.cs_CZ:
                    return "cs-CZ";
                case Layout.da_DK:
                    return "da-DK";
                case Layout.nl_NL:
                    return "nl-NL";
                case Layout.de_CH:
                    return "de-CH";
                case Layout.de_DE:
                    return "de-DE";
                case Layout.de_DE_MAC:
                    return "de-DE-MAC";
                case Layout.el_GR:
                    return "el-GR";
                case Layout.en_US_DV:
                    return "en-US-DV";
                case Layout.en_GB:
                    return "en-GB";
                case Layout.en_US:
                    return "en-US";
                case Layout.en_US_INT:
                    return "en-US-INT";
                case Layout.es_ES:
                    return "es-ES";
                case Layout.fi_FI:
                    return "fi-FI";
                case Layout.fr_CA:
                    return "fr-CA";
                case Layout.fr_CH:
                    return "fr-CH";
                case Layout.fr_FR:
                    return "fr-FR";
                case Layout.he_IL:
                    return "he-IL";
                case Layout.hu_HU:
                    return "hu-HU";
                case Layout.it_IT:
                    return "it-IT";
                case Layout.nb_NO:
                    return "nb-NO";
                case Layout.pl_PL:
                    return "pl-PL";
                case Layout.pt_BR:
                    return "pt-BR";
                case Layout.pt_PT:
                    return "pt-PT";
                case Layout.ru_RU:
                    return "ru-RU";
                case Layout.sk_SK:
                    return "sk-SK";
                case Layout.sv_SE:
                    return "sv-SE";
                default:
                    return null;
            }
        }
    }
}
