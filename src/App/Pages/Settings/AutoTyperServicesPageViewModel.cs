using System.Collections.Generic;
using System.Threading.Tasks;
using Bit.App.Resources;
using Bit.Core.Abstractions;
using Bit.Core.Enums;
using Bit.Core.Utilities;

namespace Bit.App.Pages
{
    public class AutoTyperServicesPageViewModel : BaseViewModel
    {
        private readonly IAutoTyperService _autoTyperService;

        private bool _inited;
        private AutoTyperProviderType _providerTypeSelected;
        private LayoutType _layoutTypeSelected;
        private SpeedType _speedTypeSelected;
        public List<AutoTyperProviderType> ProviderOptions { get; set; }
        public List<LayoutType> LayoutOptions { get; set; }
        public List<SpeedType> SpeedOptions { get; set; }

        public AutoTyperServicesPageViewModel()
        {
            _autoTyperService = ServiceContainer.Resolve<IAutoTyperService>("autoTyperService");
            PageTitle = AppResources.AutoTyperServices;

            var providers = new List<AutoTyperProviderType> { AutoTyperProviderType.None };
            providers.AddRange(_autoTyperService.GetCompatibleProviders());
            ProviderOptions = providers;
        }

        public AutoTyperProviderType ProviderTypeSelected
        {
            get => _providerTypeSelected;
            set
            {
                if (SetProperty(ref _providerTypeSelected, value))
                {
                    SaveAutoTyperProviderAsync().FireAndForget();
                    UpdateUIAsync().FireAndForget();
                }
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

        public bool AreSettingsVisible => ProviderTypeSelected != AutoTyperProviderType.None;

        public async Task InitAsync()
        {
            ProviderTypeSelected = await _autoTyperService.GetProviderTypeAsync();
            await UpdateUIAsync();
            _inited = true;
        }

        public async Task UpdateUIAsync()
        {
            TriggerPropertyChanged(nameof(AreSettingsVisible));
            if (ProviderTypeSelected != AutoTyperProviderType.None)
            {
                LayoutOptions = _autoTyperService.GetCompatibleLayouts(ProviderTypeSelected);
                TriggerPropertyChanged(nameof(LayoutOptions));
                SpeedOptions = _autoTyperService.GetCompatibleSpeeds(ProviderTypeSelected);
                TriggerPropertyChanged(nameof(SpeedOptions));
                LayoutTypeSelected = await _autoTyperService.GetLayoutAsync(ProviderTypeSelected);
                TriggerPropertyChanged(nameof(LayoutTypeSelected));
                SpeedTypeSelected = await _autoTyperService.GetSpeedAsync(ProviderTypeSelected);
                TriggerPropertyChanged(nameof(SpeedTypeSelected));
            }
            // FIXME visibility
        }

        private async Task SaveAutoTyperProviderAsync()
        {
            if (_inited)
            {
                await _autoTyperService.SetProviderAsync(ProviderTypeSelected);
            }
        }

        private async Task SaveLayoutAsync()
        {
            if (_inited)
            {
                await _autoTyperService.SetLayoutAsync(LayoutTypeSelected, ProviderTypeSelected);
            }
        }

        private async Task SaveSpeedAsync()
        {
            if (_inited)
            {
                await _autoTyperService.SetSpeedAsync(SpeedTypeSelected, ProviderTypeSelected);
            }
        }
    }
}
