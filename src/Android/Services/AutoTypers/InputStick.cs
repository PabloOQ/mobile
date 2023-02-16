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
        List<KeyValuePair<LayoutType, string>> layouts;

        public InputStick()
        {
            // Compatible layouts and their values
            layouts = new List<KeyValuePair<LayoutType, string>>();
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.cs_CZ,      "cs-CZ"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.da_DK,      "da-DK"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.de_CH,      "de-CH"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.de_DE,      "de-DE"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.de_DE_MAC,  "de-DE-MAC" ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.el_GR,      "el-GR"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.en_GB,      "en-GB"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.en_US,      "en-US"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.en_US_DV,   "en-US-DV"  ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.en_US_INT,  "en-US-INT" ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.es_ES,      "es-ES"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.fi_FI,      "fi-FI"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.fr_CA,      "fr-CA"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.fr_CH,      "fr-CH"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.fr_BE,      "fr-BE"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.fr_FR,      "fr-FR"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.he_IL,      "he-IL"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.hr_HR,      "hr-HR"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.hu_HU,      "hu-HU"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.it_IT,      "it-IT"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.nb_NO,      "nb-NO"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.nl_NL,      "nl-NL"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.pl_PL,      "pl-PL"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.pt_BR,      "pt-BR"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.pt_PT,      "pt-PT"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.ru_RU,      "ru-RU"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.sk_SK,      "sk-SK"     ));
            layouts.Add(new KeyValuePair<LayoutType, string>(LayoutType.sv_SE,      "sv-SE"     ));
        }

        public void Type(String text, LayoutType layout, int speed)
        {
            var context = Application.Context;
            InputStickBroadcast.Type(context,text,LayoutKey(layout),speed);
        }


        private String LayoutKey(LayoutType layout) => layout switch
        {
            LayoutType.cs_CZ => "cs-CZ",
            LayoutType.da_DK => "da-DK",
            LayoutType.de_CH => "de-CH",
            LayoutType.de_DE => "de-DE",
            LayoutType.de_DE_MAC => "de-DE-MAC",
            LayoutType.el_GR => "el-GR",
            LayoutType.en_GB => "en-GB",
            LayoutType.en_US => "en-US",
            LayoutType.en_US_DV => "en-US-DV",
            LayoutType.en_US_INT => "en-US-INT",
            LayoutType.es_ES => "es-ES",
            LayoutType.fi_FI => "fi-FI",
            LayoutType.fr_CA => "fr-CA",
            LayoutType.fr_CH => "fr-CH",
            LayoutType.fr_BE => "fr-BE",
            LayoutType.fr_FR => "fr-FR",
            LayoutType.he_IL => "he-IL",
            LayoutType.hr_HR => "hr-HR",
            LayoutType.hu_HU => "hu-HU",
            LayoutType.it_IT => "it-IT",
            LayoutType.nb_NO => "nb-NO",
            LayoutType.nl_NL => "nl-NL",
            LayoutType.pl_PL => "pl-PL",
            LayoutType.pt_BR => "pt-BR",
            LayoutType.pt_PT => "pt-PT",
            LayoutType.ru_RU => "ru-RU",
            LayoutType.sk_SK => "sk-SK",
            LayoutType.sv_SE => "sv-SE",
            _ => null,
        };


        public List<LayoutType> CompatibleLayouts()
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
            layouts.Add(LayoutType.en_US_DV);
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
