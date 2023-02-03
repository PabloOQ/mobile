using System.Collections.Generic;
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
        private readonly IDeviceActionService _deviceActionService;
        private readonly IStateService _stateService;
        private readonly MobileI18nService _i18nService;

        private bool _autoTyperServiceToggled;
        private bool _inited;
        private int _autoTyperSelectedIndex;
        public List<KeyValuePair<AutoTyperServiceType?, string>> AutoTyperServiceOptions { get; set; }

        public AutoTyperServicesPageViewModel()
        {
            _deviceActionService = ServiceContainer.Resolve<IDeviceActionService>("deviceActionService");
            _stateService = ServiceContainer.Resolve<IStateService>("stateService");
            _i18nService = ServiceContainer.Resolve<II18nService>("i18nService") as MobileI18nService;
            PageTitle = AppResources.AutoTyperServices;

            AutoTyperServiceOptions = new List<KeyValuePair<AutoTyperServiceType?, string>>
            {
                new KeyValuePair<AutoTyperServiceType?, string>(AutoTyperServiceType.None, AppResources.Off),
                new KeyValuePair<AutoTyperServiceType?, string>(AutoTyperServiceType.InputStick, AppResources.AutoTyperInputStick),
            };
        }

        public int AutoTyperSelectedIndex
        {
            get => _autoTyperSelectedIndex;
            set
            {
               if (SetProperty(ref _autoTyperSelectedIndex, value)
                   )
                {
                    SaveAutoTyperAsync().FireAndForget();
                }
            }
        }

        public async Task InitAsync()
        {
            var autoTyperService = await _stateService.GetAutoTyperServiceAsync();
            AutoTyperSelectedIndex = autoTyperService == null ? 0 :
                AutoTyperServiceOptions.FindIndex(k => (int?)k.Key == autoTyperService);
            _inited = true;
        }

        private async Task SaveAutoTyperAsync()
        {
            if (_inited && AutoTyperSelectedIndex > -1)
            {
                await _stateService.SetAutoTyperService((int?)AutoTyperServiceOptions[AutoTyperSelectedIndex].Key);
            }
        }
    }
}
