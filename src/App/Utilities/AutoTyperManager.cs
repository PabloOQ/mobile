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
        public static string LayoutText(LayoutType layout) => layout switch
        {
            LayoutType.cs_CZ        => AppResources.AutoTyperLayoutCSCZ,
            LayoutType.da_DK        => AppResources.AutoTyperLayoutDADK,
            LayoutType.de_CH        => AppResources.AutoTyperLayoutDECH,
            LayoutType.de_DE        => AppResources.AutoTyperLayoutDEDE,
            LayoutType.de_DE_MAC    => AppResources.AutoTyperLayoutDEDEMAC,
            LayoutType.el_GR        => AppResources.AutoTyperLayoutELGR,
            LayoutType.en_GB        => AppResources.AutoTyperLayoutENGB,
            LayoutType.en_US        => AppResources.AutoTyperLayoutENUS,
            LayoutType.en_US_DV     => AppResources.AutoTyperLayoutENUSDV,
            LayoutType.en_US_INT    => AppResources.AutoTyperLayoutENUSINT,
            LayoutType.es_ES        => AppResources.AutoTyperLayoutESES,
            LayoutType.fi_FI        => AppResources.AutoTyperLayoutFIFI,
            LayoutType.fr_CA        => AppResources.AutoTyperLayoutFRCA,
            LayoutType.fr_CH        => AppResources.AutoTyperLayoutFRCH,
            LayoutType.fr_BE        => AppResources.AutoTyperLayoutFRBE,
            LayoutType.fr_FR        => AppResources.AutoTyperLayoutFRFR,
            LayoutType.he_IL        => AppResources.AutoTyperLayoutHEIL,
            LayoutType.hr_HR        => AppResources.AutoTyperLayoutHRHR,
            LayoutType.hu_HU        => AppResources.AutoTyperLayoutHUHU,
            LayoutType.it_IT        => AppResources.AutoTyperLayoutITIT,
            LayoutType.nb_NO        => AppResources.AutoTyperLayoutNBNO,
            LayoutType.nl_NL        => AppResources.AutoTyperLayoutNLNL,
            LayoutType.pl_PL        => AppResources.AutoTyperLayoutPLPL,
            LayoutType.pt_BR        => AppResources.AutoTyperLayoutPTBR,
            LayoutType.pt_PT        => AppResources.AutoTyperLayoutPTPT,
            LayoutType.ru_RU        => AppResources.AutoTyperLayoutRURU,
            LayoutType.sk_SK        => AppResources.AutoTyperLayoutSKSK,
            LayoutType.sv_SE        => AppResources.AutoTyperLayoutSVSE,
            _ => null,
        };
    }
}
