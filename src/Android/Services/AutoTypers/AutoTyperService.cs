using System;
using System.Collections.Generic;
using System.Linq;

using Bit.Core.Abstractions;
using Bit.Core.Enums;
using System.Threading.Tasks;
using Bit.App.Resources;

namespace Bit.Droid.Services.AutoTypers
{
    // FIXME extract from android
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
            await Connect();
            // Check layout
            if (!(await GetCompatibleLayouts()).Contains(layout))
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
            AutoTyperProviderType.InputStickBroadcastAndroid => new InputStickBroadcastAndroid(),
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
            var layout = await GetLayoutAsync();
            var compatibleLayouts = await GetCompatibleLayouts();
            var defaultLayout = LayoutType.cs_CZ;
            // Checks if the layout is in the list of compatible layouts
            // If not, it defaults to defaultLayout
            // If defaultLayout is not in the list, it defaults to the in the list
            // FIXME default using culture
            return layout == null ?
                FindOrDefault(defaultLayout, compatibleLayouts, compatibleLayouts[0]) :
                FindOrDefault(FindOrDefault((LayoutType)layout, compatibleLayouts, defaultLayout), compatibleLayouts, compatibleLayouts[0]);
        }

        public async Task SetLayoutAsync(LayoutType type)
        {
            await _stateService.SetAutoTyperLayoutAsync((int) type);
        }

        public async Task<SpeedType> GetSpeedAsync()
        {
            var speed = await GetSpeedAsync();
            var compatibleSpeeds = await GetCompatibleSpeeds();
            var defaultSpeed = SpeedType.Normal;
            // Checks if the speed is in the list of compatible layouts
            // If not, it defaults to defaultSpeed
            // If defaultSpeed is not in the list, it defaults to the in the list
            return speed == null ?
                FindOrDefault(defaultSpeed, compatibleSpeeds, compatibleSpeeds[0]) :
                FindOrDefault(FindOrDefault((SpeedType)speed, compatibleSpeeds, defaultSpeed), compatibleSpeeds, compatibleSpeeds[0]);
        }

        public async Task SetSpeedAsync(SpeedType speed)
        {
            await _stateService.SetAutoTyperSpeedAsync((int)speed);
        }

        public async Task<List<LayoutType>> GetCompatibleLayouts()
        {
            if (typer == null)
            {
                await InitializeTyper();
            }
            return typer != null ?
                typer.GetCompatibleLayouts() :
                new List<LayoutType>();
        }

        public async Task<List<SpeedType>> GetCompatibleSpeeds()
        {
            if (typer == null)
            {
                await InitializeTyper();
            }
            return typer != null ?
                typer.GetCompatibleSpeeds() :
                new List<SpeedType>();
        }

        // Helpers

        private static T FindOrDefault<T>(T element, List<T> list, T def)
        {
            return list.Contains(element) ? element : def;
        }
    }
}
