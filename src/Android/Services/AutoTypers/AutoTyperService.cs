using System;
using System.Collections.Generic;
using System.Linq;

using Bit.Core.Abstractions;
using Bit.Core.Enums;
using System.Threading.Tasks;
using Bit.App.Resources;

namespace Bit.Droid.Services.AutoTypers
{
    internal class AutoTyperService : IAutoTyperService
    {
        private readonly IStateService _stateService;
        private IAutoTyperProvider typer;

        public async Task Connect()
        {
            if (typer == null)
            {
                await InitializeTyper();
            }
            typer.Connect();
        }

        public async Task Disconnect()
        {
            if (typer != null)
            {
                typer.Disconnect();
            }
        }

        public AutoTyperService(IStateService stateService)
        {
            _stateService = stateService;
        }

        // Type
        public async Task Type(string text)
        {
            await Type(text, await GetLayoutAsync(), await GetSpeedAsync());
        }

        public async Task Type(string text, LayoutType layout, SpeedType speed)
        {
            // Check layout
            if (!(await CompatibleLayouts()).Contains(layout))
            {
                throw new ArgumentException("Layout not supported");
            }
            typer.Type(text, layout, speed);
        }

        // Typer
        private async Task InitializeTyper()
        {
            AutoTyperProviderType typer = (AutoTyperProviderType) await _stateService.GetAutoTyperProviderAsync();
            // Warn user if no auto typer is selected ?
            // Maybe show a toast?
            this.typer = TyperService(typer);
        }

        private IAutoTyperProvider TyperService(AutoTyperProviderType? type) => type switch
        {
            AutoTyperProviderType.None => null,
            AutoTyperProviderType.InputStick => new InputStick(),
            _ => null,
        };

        public async Task<bool> IsEnabledAsync()
        {
            return await GetProviderTypeAsync() != AutoTyperProviderType.None;
        }

        // Getters and setters
        public async Task<AutoTyperProviderType> GetProviderTypeAsync()
        {
            if (typer == null)
            {
                await InitializeTyper();
            }
            return typer == null ? AutoTyperProviderType.None : typer.GetProviderType();
        }

        public async Task SetProviderAsync(AutoTyperProviderType type)
        {
            await _stateService.SetAutoTyperProvider((int) type);
        }

        public async Task<LayoutType> GetLayoutAsync()
        {
            LayoutType layout;
            var storedLayout = await _stateService.GetAutoTyperLayoutAsync();
            var compatibleLayouts = await CompatibleLayouts();
            if (storedLayout == null || !compatibleLayouts.Contains((LayoutType)storedLayout))
            {
                // FIXME choose default layout depending on language
                layout = compatibleLayouts.First();
            }
            else
            {
                layout = (LayoutType)storedLayout;
            }
            return layout;
        }

        public async Task SetLayoutAsync(LayoutType type)
        {
            await _stateService.SetAutoTyperLayoutAsync((int) type);
        }

        public async Task<SpeedType> GetSpeedAsync()
        {
            SpeedType speed;
            var storedSpeed = await _stateService.GetAutoTyperSpeedAsync();
            if (storedSpeed == null)
            {
                speed = SpeedType.Normal;
            }
            else
            {
                speed = (SpeedType)storedSpeed;
            }
            return speed;
        }

        public async Task SetSpeedAsync(int speed)
        {
            await _stateService.SetAutoTyperSpeedAsync((int)speed);
        }

        public async Task<List<LayoutType>> CompatibleLayouts()
        {
            if (typer == null)
            {
                await InitializeTyper();
                if (typer == null)
                    return null;
            }
            return typer.CompatibleLayouts();
        }

        // Helpers
        public static string LayoutText(LayoutType layout) => layout switch
        {
            LayoutType.cs_CZ =>     AppResources.AutoTyperLayoutCSCZ,
            LayoutType.da_DK =>     AppResources.AutoTyperLayoutDADK,
            LayoutType.de_CH =>     AppResources.AutoTyperLayoutDECH,
            LayoutType.de_DE =>     AppResources.AutoTyperLayoutDEDE,
            LayoutType.de_DE_MAC => AppResources.AutoTyperLayoutDEDEMAC,
            LayoutType.el_GR =>     AppResources.AutoTyperLayoutELGR,
            LayoutType.en_GB =>     AppResources.AutoTyperLayoutENGB,
            LayoutType.en_US =>     AppResources.AutoTyperLayoutENUS,
            LayoutType.en_US_DV =>  AppResources.AutoTyperLayoutENUSDV,
            LayoutType.en_US_INT => AppResources.AutoTyperLayoutENUSINT,
            LayoutType.es_ES =>     AppResources.AutoTyperLayoutESES,
            LayoutType.fi_FI =>     AppResources.AutoTyperLayoutFIFI,
            LayoutType.fr_CA =>     AppResources.AutoTyperLayoutFRCA,
            LayoutType.fr_CH =>     AppResources.AutoTyperLayoutFRCH,
            LayoutType.fr_BE =>     AppResources.AutoTyperLayoutFRBE,
            LayoutType.fr_FR =>     AppResources.AutoTyperLayoutFRFR,
            LayoutType.he_IL =>     AppResources.AutoTyperLayoutHEIL,
            LayoutType.hr_HR =>     AppResources.AutoTyperLayoutHRHR,
            LayoutType.hu_HU =>     AppResources.AutoTyperLayoutHUHU,
            LayoutType.it_IT =>     AppResources.AutoTyperLayoutITIT,
            LayoutType.nb_NO =>     AppResources.AutoTyperLayoutNBNO,
            LayoutType.nl_NL =>     AppResources.AutoTyperLayoutNLNL,
            LayoutType.pl_PL =>     AppResources.AutoTyperLayoutPLPL,
            LayoutType.pt_BR =>     AppResources.AutoTyperLayoutPTBR,
            LayoutType.pt_PT =>     AppResources.AutoTyperLayoutPTPT,
            LayoutType.ru_RU =>     AppResources.AutoTyperLayoutRURU,
            LayoutType.sk_SK =>     AppResources.AutoTyperLayoutSKSK,
            LayoutType.sv_SE =>     AppResources.AutoTyperLayoutSVSE,
            _ => null,
        };
    }
}
