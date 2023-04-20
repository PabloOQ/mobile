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
        private int _autoTyperSelectedIndex;
        private int _layoutSelectedIndex;
        public List<AutoTyperProviderType> AutoTyperServiceOptions { get; set; }
        public List<LayoutType> LayoutOptions { get; set; }

        public AutoTyperServicesPageViewModel()
        {
            _stateService = ServiceContainer.Resolve<IStateService>("stateService");
            PageTitle = AppResources.AutoTyperServices;

            AutoTyperServiceOptions = new List<AutoTyperProviderType>
            {
                AutoTyperProviderType.None,
                AutoTyperProviderType.InputStick
            };

            UpdateLayouts();
        }

        public int AutoTyperSelectedIndex
        {
            get => _autoTyperSelectedIndex;
            set
            {
                if (SetProperty(ref _autoTyperSelectedIndex, value))
                {
                    SaveAutoTyperAsync().FireAndForget();
                }
                UpdateLayouts();
            }
        }

        public int LayoutSelectedIndex
        {
            get => _layoutSelectedIndex;
            set
            {
                if (SetProperty(ref _layoutSelectedIndex, value))
                {
                    SaveLayoutAsync().FireAndForget();
                }
            }
        }

        private void UpdateLayouts()
        {
            // add all layout types
            var compatibleLayouts = System.Enum.GetValues(typeof(LayoutType));
            LayoutOptions = new List<LayoutType>(compatibleLayouts.Cast<LayoutType>().ToList());
        }

        public async Task InitAsync()
        {
            var autoTyperService = await _stateService.GetAutoTyperProviderAsync();
            AutoTyperSelectedIndex = autoTyperService == null ? 0 :
                AutoTyperServiceOptions.FindIndex(k => (int?)k == autoTyperService);

            var layout = await _stateService.GetAutoTyperLayoutAsync();
            LayoutSelectedIndex = layout == null ? 0 :
                LayoutOptions.FindIndex(k => (int?)k == layout);

            _inited = true;
        }

        private async Task SaveAutoTyperAsync()
        {
            if (_inited && AutoTyperSelectedIndex > -1)
            {
                await _stateService.SetAutoTyperProvider((int?)AutoTyperServiceOptions[AutoTyperSelectedIndex]);
            }
        }

        private async Task SaveLayoutAsync()
        {
            if (_inited && LayoutSelectedIndex > -1)
            {
                await _stateService.SetAutoTyperLayoutAsync((int?)LayoutOptions[LayoutSelectedIndex]);
            }
        }
    }
}
