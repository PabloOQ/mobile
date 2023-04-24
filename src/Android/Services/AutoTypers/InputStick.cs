using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Bit.Core.Abstractions;
using Com.Inputstick.Api.Broadcast;
using Bit.Core.Enums;

namespace Bit.Droid.Services.AutoTypers
{
    public class InputStick : IAutoTyperProvider
    {
        private Dictionary<LayoutType, string> layouts;

        public void Prepare()
        {
            InputStickBroadcast.RequestConnection(Application.Context);
        }

        public void Type(String text, LayoutType layout, SpeedType speed)
        {
            InitializeLayouts();
            InputStickBroadcast.Type(Application.Context, text, layouts[layout], SpeedToValue(speed));
        }

        public List<LayoutType> CompatibleLayouts()
        {
            InitializeLayouts();
            return layouts.Keys.ToList();
        }
        
        private void InitializeLayouts()
        {
            if (layouts == null)
            {
                // Compatible layouts and their values, cannot be repeated
                layouts = new Dictionary<LayoutType, string>();
                layouts.Add(LayoutType.cs_CZ, "cs-CZ");
                layouts.Add(LayoutType.da_DK, "da-DK");
                layouts.Add(LayoutType.de_CH, "de-CH");
                layouts.Add(LayoutType.de_DE, "de-DE");
                layouts.Add(LayoutType.de_DE_MAC, "de-DE-MAC");
                layouts.Add(LayoutType.el_GR, "el-GR");
                layouts.Add(LayoutType.en_GB, "en-GB");
                layouts.Add(LayoutType.en_US, "en-US");
                layouts.Add(LayoutType.en_US_DV, "en-US-DV");
                layouts.Add(LayoutType.en_US_INT, "en-US-INT");
                layouts.Add(LayoutType.es_ES, "es-ES");
                layouts.Add(LayoutType.fi_FI, "fi-FI");
                layouts.Add(LayoutType.fr_CA, "fr-CA");
                layouts.Add(LayoutType.fr_CH, "fr-CH");
                layouts.Add(LayoutType.fr_BE, "fr-BE");
                layouts.Add(LayoutType.fr_FR, "fr-FR");
                layouts.Add(LayoutType.he_IL, "he-IL");
                layouts.Add(LayoutType.hr_HR, "hr-HR");
                layouts.Add(LayoutType.hu_HU, "hu-HU");
                layouts.Add(LayoutType.it_IT, "it-IT");
                layouts.Add(LayoutType.nb_NO, "nb-NO");
                layouts.Add(LayoutType.nl_NL, "nl-NL");
                layouts.Add(LayoutType.pl_PL, "pl-PL");
                layouts.Add(LayoutType.pt_BR, "pt-BR");
                layouts.Add(LayoutType.pt_PT, "pt-PT");
                layouts.Add(LayoutType.ru_RU, "ru-RU");
                layouts.Add(LayoutType.sk_SK, "sk-SK");
                layouts.Add(LayoutType.sv_SE, "sv-SE");
            }
        }
        public int SpeedToValue(SpeedType speed)
        {
            switch (speed)
            {
                case SpeedType.Slowest:
                    return 15;
                case SpeedType.Slower:
                    return 8;
                case SpeedType.Slow:
                    return 3;

                case SpeedType.Normal:
                default:
                    return 2;

                case SpeedType.Fastest: // Not supported
                case SpeedType.Faster:  // Not supported
                case SpeedType.Fast:
                    return 1;
            }
        }

        public AutoTyperProviderType GetProviderType()
        {
            return AutoTyperProviderType.InputStick;
        }
    }
}
