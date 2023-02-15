using System;
using System.Collections.Generic;
using System.Text;
using Bit.App.Resources;
using Bit.Core.Enums;
using Xamarin.Forms;

namespace Bit.App.Utilities
{
    public static class AutoTyperManager
    {
        public static string GetLayoutString(LayoutType layout)
        {
            switch (layout)
            {
                case LayoutType.cs_CZ:
                    return AppResources.AutoTyperLayoutCSCZ;
                case LayoutType.da_DK:
                    return AppResources.AutoTyperLayoutDADK;
                case LayoutType.de_CH:
                    return AppResources.AutoTyperLayoutDECH;
                case LayoutType.de_DE:
                    return AppResources.AutoTyperLayoutDEDE;
                case LayoutType.de_DE_MAC:
                    return AppResources.AutoTyperLayoutDEDEMAC;
                case LayoutType.el_GR:
                    return AppResources.AutoTyperLayoutELGR;
                case LayoutType.en_GB:
                    return AppResources.AutoTyperLayoutENGB;
                case LayoutType.en_US:
                    return AppResources.AutoTyperLayoutENUS;
                case LayoutType.en_US_DV:
                    return AppResources.AutoTyperLayoutENUSDV;
                case LayoutType.en_US_INT:
                    return AppResources.AutoTyperLayoutENUSINT;
                case LayoutType.es_ES:
                    return AppResources.AutoTyperLayoutESES;
                case LayoutType.fi_FI:
                    return AppResources.AutoTyperLayoutFIFI;
                case LayoutType.fr_BE:
                    return AppResources.AutoTyperLayoutFRBE;
                case LayoutType.fr_CA:
                    return AppResources.AutoTyperLayoutFRCA;
                case LayoutType.fr_CH:
                    return AppResources.AutoTyperLayoutFRCH;
                case LayoutType.fr_FR:
                    return AppResources.AutoTyperLayoutFRFR;
                case LayoutType.he_IL:
                    return AppResources.AutoTyperLayoutHEIL;
                case LayoutType.hr_HR:
                    return AppResources.AutoTyperLayoutHRHR;
                case LayoutType.hu_HU:
                    return AppResources.AutoTyperLayoutHUHU;
                case LayoutType.it_IT:
                    return AppResources.AutoTyperLayoutITIT;
                case LayoutType.nb_NO:
                    return AppResources.AutoTyperLayoutNBNO;
                case LayoutType.nl_NL:
                    return AppResources.AutoTyperLayoutNLNL;
                case LayoutType.pl_PL:
                    return AppResources.AutoTyperLayoutPLPL;
                case LayoutType.pt_BR:
                    return AppResources.AutoTyperLayoutPTBR;
                case LayoutType.pt_PT:
                    return AppResources.AutoTyperLayoutPTPT;
                case LayoutType.ru_RU:
                    return AppResources.AutoTyperLayoutRURU;
                case LayoutType.sk_SK:
                    return AppResources.AutoTyperLayoutSKSK;
                case LayoutType.sv_SE:
                    return AppResources.AutoTyperLayoutSVSE;
                default:
                    return null;
            }
        }
    }
}
