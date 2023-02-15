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
            InputStickBroadcast.Type(context,text,GetLayoutKey(layout),speed);
        }

        private String GetLayoutKey(LayoutType layout)
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

        public List<LayoutType> GetCompatibleLayouts()
        {
            var layouts = new List<LayoutType>();

            layouts.Add(LayoutType.cs_CZ);
            layouts.Add(LayoutType.da_DK);
            layouts.Add(LayoutType.de_CH);
            layouts.Add(LayoutType.de_DE);
            layouts.Add(LayoutType.de_DE_MAC);
            layouts.Add(LayoutType.el_GR);
            layouts.Add(LayoutType.en_GB);
            layouts.Add(LayoutType.en_US);
            layouts.Add(LayoutType.en_US);
            layouts.Add(LayoutType.en_US_INT);
            layouts.Add(LayoutType.es_ES);
            layouts.Add(LayoutType.fi_FI);
            layouts.Add(LayoutType.fr_BE);
            layouts.Add(LayoutType.fr_CA);
            layouts.Add(LayoutType.fr_CH);
            layouts.Add(LayoutType.fr_FR);
            layouts.Add(LayoutType.he_IL);
            layouts.Add(LayoutType.hr_HR);
            layouts.Add(LayoutType.hu_HU);
            layouts.Add(LayoutType.it_IT);
            layouts.Add(LayoutType.nb_NO);
            layouts.Add(LayoutType.nl_NL);
            layouts.Add(LayoutType.pl_PL);
            layouts.Add(LayoutType.pt_BR);
            layouts.Add(LayoutType.pt_PT);
            layouts.Add(LayoutType.ru_RU);
            layouts.Add(LayoutType.sk_SK);
            layouts.Add(LayoutType.sv_SE);

            return layouts;
        }
    }
}
