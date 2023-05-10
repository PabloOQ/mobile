using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bit.App.Abstractions;
using Bit.App.Resources;
using Bit.App.Services;
using Bit.App.Utilities;
using Bit.Core.Abstractions;
using Bit.Core.Enums;
using Bit.Core.Utilities;

namespace Bit.App.Pages
{
    public class AutoTyperServicesPageViewModel : BaseViewModel
    {
        private readonly IStateService _stateService;

        private bool _inited;
        private AutoTyperProviderType _autoTyperProviderTypeSelected;
        private LayoutType _layoutTypeSelected;
        private SpeedType _speedTypeSelected;
        public List<AutoTyperProviderType> AutoTyperServiceOptions { get; set; }
        public List<LayoutType> LayoutOptions { get; set; }
        public List<SpeedType> SpeedOptions { get; set; }

        public AutoTyperServicesPageViewModel()
        {
            _stateService = ServiceContainer.Resolve<IStateService>("stateService");
            PageTitle = AppResources.AutoTyperServices;

            // Depends on the device
            AutoTyperServiceOptions = new List<AutoTyperProviderType>
            {
                AutoTyperProviderType.None,
                AutoTyperProviderType.InputStickBroadcastAndroid
            };

            UpdateLayoutsAndSpeed();
        }

        public AutoTyperProviderType AutoTyperProviderTypeSelected
        {
            get => _autoTyperProviderTypeSelected;
            set
            {
                if (SetProperty(ref _autoTyperProviderTypeSelected, value))
                {
                    SaveAutoTyperProviderAsync().FireAndForget();
                }
                UpdateLayoutsAndSpeed();
            }
        }

        public LayoutType LayoutTypeSelected
        {
            get => _layoutTypeSelected;
            set
            {
                if (SetProperty(ref _layoutTypeSelected, value))
                {
                    SaveLayoutAsync().FireAndForget();
                }
            }
        }

        public SpeedType SpeedTypeSelected
        {
            get=> _speedTypeSelected;
            set
            {
                if (SetProperty(ref _speedTypeSelected, value))
                {
                    SaveSpeedAsync().FireAndForget();
                }
            }
        }

        private void UpdateLayoutsAndSpeed()
        {
            // get from the provider
            var compatibleLayouts = System.Enum.GetValues(typeof(LayoutType)).Cast<LayoutType>().ToList();
            LayoutOptions = new List<LayoutType>(compatibleLayouts);

            SpeedOptions = new List<SpeedType>
            {
                SpeedType.Slowest,
                SpeedType.Slower,
                SpeedType.Slow,
                SpeedType.Normal,
                SpeedType.Fast,
                SpeedType.Faster,
                SpeedType.Fastest
            };
        }

        public async Task InitAsync()
        {
            var autoTyperProvider = await _stateService.GetAutoTyperProviderAsync();
            AutoTyperProviderTypeSelected = autoTyperProvider == null ?
                AutoTyperProviderType.None : (AutoTyperProviderType)autoTyperProvider;
            // get from the provider
            var compatibleLayouts = System.Enum.GetValues(typeof(LayoutType)).Cast<LayoutType>().ToList();

            var layout = await _stateService.GetAutoTyperLayoutAsync();
            LayoutTypeSelected = layout == null ?
                LayoutOptions[0] :
                compatibleLayouts.Contains((LayoutType)layout) ?
                    (LayoutType)layout :
                    LayoutOptions[0];

            var speed = await _stateService.GetAutoTyperSpeedAsync();
            SpeedTypeSelected = speed == null ?
                SpeedType.Normal :
                (SpeedType)speed;

            _inited = true;
        }

        private async Task SaveAutoTyperProviderAsync()
        {
            if (_inited)
            {
                await _stateService.SetAutoTyperProviderAsync((int?)AutoTyperProviderTypeSelected);
            }
        }

        private async Task SaveLayoutAsync()
        {
            if (_inited)
            {
                await _stateService.SetAutoTyperLayoutAsync((int?)LayoutTypeSelected);
            }
        }

        private async Task SaveSpeedAsync()
        {
            if (_inited)
            {
                await _stateService.SetAutoTyperSpeedAsync((int?)SpeedTypeSelected);
            }
        }
    }
}
