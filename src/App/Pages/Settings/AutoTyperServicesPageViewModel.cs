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
        public List<AutoTyperProviderType> AutoTyperServiceOptions { get; set; }
        public List<LayoutType> LayoutOptions { get; set; }

        public AutoTyperServicesPageViewModel()
        {
            _stateService = ServiceContainer.Resolve<IStateService>("stateService");
            PageTitle = AppResources.AutoTyperServices;

            // Depends on the device
            AutoTyperServiceOptions = new List<AutoTyperProviderType>
            {
                AutoTyperProviderType.None,
                AutoTyperProviderType.InputStick
            };

            UpdateLayouts();
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
                UpdateLayouts();
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

        private void UpdateLayouts()
        {
            // get from the provider
            var compatibleLayouts = System.Enum.GetValues(typeof(LayoutType)).Cast<LayoutType>().ToList();
            LayoutOptions = new List<LayoutType>(compatibleLayouts);
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

            _inited = true;
        }

        private async Task SaveAutoTyperProviderAsync()
        {
            if (_inited)
            {
                await _stateService.SetAutoTyperProvider((int?)AutoTyperProviderTypeSelected);
            }
        }

        private async Task SaveLayoutAsync()
        {
            if (_inited)
            {
                await _stateService.SetAutoTyperLayoutAsync((int?)LayoutTypeSelected);
            }
        }
    }
}
