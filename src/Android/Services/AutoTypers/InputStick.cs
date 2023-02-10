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
        public LayoutType layout { get; set; } = LayoutType.en_US;
        public int speed { get; set; } = 1;
        public void Type(String text)
        {
            var context = Application.Context;
            InputStickBroadcast.Type(context,text,"es-ES",speed);
        }

        private String LayoutString(LayoutType layout)
        {
            switch (layout)
            {
                case LayoutType.fr_BE:
                    return "fr-BE";
                case LayoutType.hr_HR:
                    return "hr-HR";
                case LayoutType.cs_CZ:
                    return "cs-CZ";
                case LayoutType.da_DK:
                    return "da-DK";
                case LayoutType.nl_NL:
                    return "nl-NL";
                case LayoutType.de_CH:
                    return "de-CH";
                case LayoutType.de_DE:
                    return "de-DE";
                case LayoutType.de_DE_MAC:
                    return "de-DE-MAC";
                case LayoutType.el_GR:
                    return "el-GR";
                case LayoutType.en_US_DV:
                    return "en-US-DV";
                case LayoutType.en_GB:
                    return "en-GB";
                case LayoutType.en_US:
                    return "en-US";
                case LayoutType.en_US_INT:
                    return "en-US-INT";
                case LayoutType.es_ES:
                    return "es-ES";
                case LayoutType.fi_FI:
                    return "fi-FI";
                case LayoutType.fr_CA:
                    return "fr-CA";
                case LayoutType.fr_CH:
                    return "fr-CH";
                case LayoutType.fr_FR:
                    return "fr-FR";
                case LayoutType.he_IL:
                    return "he-IL";
                case LayoutType.hu_HU:
                    return "hu-HU";
                case LayoutType.it_IT:
                    return "it-IT";
                case LayoutType.nb_NO:
                    return "nb-NO";
                case LayoutType.pl_PL:
                    return "pl-PL";
                case LayoutType.pt_BR:
                    return "pt-BR";
                case LayoutType.pt_PT:
                    return "pt-PT";
                case LayoutType.ru_RU:
                    return "ru-RU";
                case LayoutType.sk_SK:
                    return "sk-SK";
                case LayoutType.sv_SE:
                    return "sv-SE";
                default:
                    return null;
            }
        }
    }
}
