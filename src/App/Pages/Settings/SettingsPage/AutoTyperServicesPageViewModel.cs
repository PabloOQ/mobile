using System.Threading.Tasks;
using Bit.App.Abstractions;
using Bit.App.Resources;
using Bit.App.Services;
using Bit.Core.Abstractions;
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
        public AutoTyperServicesPageViewModel()
        {
            _deviceActionService = ServiceContainer.Resolve<IDeviceActionService>("deviceActionService");
            _stateService = ServiceContainer.Resolve<IStateService>("stateService");
            _i18nService = ServiceContainer.Resolve<II18nService>("i18nService") as MobileI18nService;
            PageTitle = AppResources.AutoTyperServices;
        }
    }
}
