using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Bit.Core.Abstractions;
using Com.Inputstick.Api.Broadcast;
using Bit.Core.Enums;

namespace Bit.Droid.Services.AutoTypers
{
    public class InputStickBroadcastAndroid : IAutoTyperProvider
    {
        public void Connect()
        {
            InputStickBroadcast.RequestConnection(Application.Context);
        }

        public void Disconnect()
        {
            InputStickBroadcast.ReleaseConnection(Application.Context);
        }

        public void Type(String text, LayoutType layout, SpeedType speed)
        {
            InputStickBroadcast.Type(Application.Context,
                text,
                _layouts.ContainsKey(layout) ? _layouts[layout] : _layouts[0], // Should not happen, this is a fallback
                SpeedToValue(speed));
        }

        // Layouts
        public static List<LayoutType> GetCompatibleLayouts() => _layouts.Keys.ToList();

        private static readonly Dictionary<LayoutType, string> _layouts = new Dictionary<LayoutType, string>()
        {
            {LayoutType.cs_CZ,      "cs-CZ"},
            {LayoutType.da_DK,      "da-DK"},
            {LayoutType.de_CH,      "de-CH"},
            {LayoutType.de_DE,      "de-DE"},
            {LayoutType.de_DE_MAC,  "de-DE-MAC"},
            {LayoutType.el_GR,      "el-GR"},
            {LayoutType.en_GB,      "en-GB"},
            {LayoutType.en_US,      "en-US"},
            {LayoutType.en_US_DV,   "en-US-DV"},
            {LayoutType.en_US_INT,  "en-US-INT"},
            {LayoutType.es_ES,      "es-ES"},
            {LayoutType.fi_FI,      "fi-FI"},
            {LayoutType.fr_CA,      "fr-CA"},
            {LayoutType.fr_CH,      "fr-CH"},
            {LayoutType.fr_BE,      "fr-BE"},
            {LayoutType.fr_FR,      "fr-FR"},
            {LayoutType.he_IL,      "he-IL"},
            {LayoutType.hr_HR,      "hr-HR"},
            {LayoutType.hu_HU,      "hu-HU"},
            {LayoutType.it_IT,      "it-IT"},
            {LayoutType.nb_NO,      "nb-NO"},
            {LayoutType.nl_NL,      "nl-NL"},
            {LayoutType.pl_PL,      "pl-PL"},
            {LayoutType.pt_BR,      "pt-BR"},
            {LayoutType.pt_PT,      "pt-PT"},
            {LayoutType.ru_RU,      "ru-RU"},
            {LayoutType.sk_SK,      "sk-SK"},
            {LayoutType.sv_SE,      "sv-SE"}
        };

        // Speeds
        public static List<SpeedType> GetCompatibleSpeeds() => _speeds;

        private static readonly List<SpeedType> _speeds = new List<SpeedType>()
        {
            SpeedType.Slowest,
            SpeedType.Slower,
            SpeedType.Slow,
            SpeedType.Normal,
            SpeedType.Fast,
        };
        private static int SpeedToValue(SpeedType speed)
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

                case SpeedType.Fastest: // Not supported, default to Fast
                case SpeedType.Faster:  // Not supported, default to Fast
                case SpeedType.Fast:
                    return 1;
            }
        }
    }
}
