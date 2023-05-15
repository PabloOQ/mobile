using System.Collections.Generic;

using Bit.Core.Abstractions;
using Bit.Core.Enums;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bit.Droid.Services.AutoTypers
{
    // FIXME extract from android
    internal class AutoTyperService : IAutoTyperService
    {
        private readonly IStateService _stateService;
        private IAutoTyperWrapper typer;

        public AutoTyperService(IStateService stateService)
        {
            _stateService = stateService;
        }

        public IAutoTyperWrapper GetTyperWrapper()
        {
            return typer;
        }

        public async Task InitAsync()
        {
            typer ??= new AutoTyperWrapper(await GetProviderTypeAsync(), this);
            await typer.LoadAsync();
        }

        // Getters and setters
        public async Task<AutoTyperProviderType> GetProviderTypeAsync()
        {
            var provider = (AutoTyperProviderType?) await _stateService.GetAutoTyperProviderAsync();
            return provider ?? AutoTyperProviderType.None;
        }
        public async Task SetProviderAsync(AutoTyperProviderType type)
        {
            await _stateService.SetAutoTyperProviderAsync((int)type);
            await GetTyperWrapper().LoadAsync();
        }

        public async Task<LayoutType> GetLayoutAsync(AutoTyperProviderType type)
        {
            // FIXME default using culture
            var defaultLayout = LayoutType.cs_CZ;
            var layout = (LayoutType?) await _stateService.GetAutoTyperLayoutAsync() ?? defaultLayout;
            var compatibleLayouts = GetCompatibleLayouts(type);
            return Validate(layout, compatibleLayouts, defaultLayout);
        }

        public async Task SetLayoutAsync(LayoutType layout, AutoTyperProviderType type)
        {
            await _stateService.SetAutoTyperLayoutAsync((int)layout);
        }

        public async Task<SpeedType> GetSpeedAsync(AutoTyperProviderType type)
        {
            var defaultSpeed = SpeedType.Normal;
            var speed = (SpeedType?) await _stateService.GetAutoTyperSpeedAsync() ?? defaultSpeed;
            var compatibleSpeeds = GetCompatibleSpeeds(type);
            return Validate(speed, compatibleSpeeds, defaultSpeed);
        }

        public async Task SetSpeedAsync(SpeedType speed, AutoTyperProviderType type)
        {
            await _stateService.SetAutoTyperSpeedAsync((int)speed);
        }

        // Compatibility

        public List<AutoTyperProviderType> GetCompatibleProviders() => Device.RuntimePlatform switch
        {
            Device.Android => new List<AutoTyperProviderType> { AutoTyperProviderType.InputStickBroadcastAndroid },
            Device.iOS => new List<AutoTyperProviderType>(),
            _ => new List<AutoTyperProviderType>(),
        };

        public List<LayoutType> GetCompatibleLayouts(AutoTyperProviderType type) => type switch
        {
            AutoTyperProviderType.InputStickBroadcastAndroid => InputStickBroadcastAndroid.GetCompatibleLayouts(),
            AutoTyperProviderType.None => new List<LayoutType>(),
            _ => new List<LayoutType>(),
        };

        public List<SpeedType> GetCompatibleSpeeds(AutoTyperProviderType type) => type switch
        {
            AutoTyperProviderType.InputStickBroadcastAndroid => InputStickBroadcastAndroid.GetCompatibleSpeeds(),
            AutoTyperProviderType.None => new List<SpeedType>(),
            _ => new List<SpeedType>(),
        };

        public IAutoTyperProvider CreateTyper(AutoTyperProviderType? type) => type switch
        {
            AutoTyperProviderType.None => null,
            AutoTyperProviderType.InputStickBroadcastAndroid => new InputStickBroadcastAndroid(),
            _ => null,
        };

        public AutoTyperProviderType ProviderType(IAutoTyperProvider? provider) => provider switch
        {
            InputStickBroadcastAndroid _ => AutoTyperProviderType.InputStickBroadcastAndroid,
            null => AutoTyperProviderType.None,
            _ => AutoTyperProviderType.None,
        };

        // Helpers

        /**
         * Checks if the element is in the list
         * If not, it defaults to def
         * If def is not in the list, it defaults to the first element of the list  
         */
        private static T Validate<T>(T element, List<T> list, T def)
        {
            return FindOrDefault(FindOrDefault(element, list, def), list, list[0]);
        }

        /**
         * Checks if the element is in the list
         * If not, it defaults to def
         */
        private static T FindOrDefault<T>(T element, List<T> list, T def)
        {
            return list.Contains(element) ? element : def;
        }
    }
}
