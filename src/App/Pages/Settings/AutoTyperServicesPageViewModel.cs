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
        private readonly IStateService _stateService;

        private bool _inited;
        private int _autoTyperSelectedIndex;
        private int _layoutSelectedIndex;
        public List<KeyValuePair<AutoTyperProviderType?, string>> AutoTyperServiceOptions { get; set; }
        public List<KeyValuePair<LayoutType?, string>> LayoutOptions { get; set; }

        public AutoTyperServicesPageViewModel()
        {
            _stateService = ServiceContainer.Resolve<IStateService>("stateService");
            PageTitle = AppResources.AutoTyperServices;

            AutoTyperServiceOptions = new List<KeyValuePair<AutoTyperProviderType?, string>>
            {
                new KeyValuePair<AutoTyperProviderType?, string>(AutoTyperProviderType.None, AppResources.Off),
                new KeyValuePair<AutoTyperProviderType?, string>(AutoTyperProviderType.InputStick, AppResources.AutoTyperInputStick),
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
            LayoutOptions = new List<KeyValuePair<LayoutType?, string>>();
            var compatibleLayouts = System.Enum.GetValues(typeof(LayoutType));
            foreach (LayoutType layout in compatibleLayouts)
            {
                LayoutOptions.Add(new KeyValuePair<LayoutType?, string>(layout, AutoTyperManager.LayoutText(layout)));
            }
        }

        public async Task InitAsync()
        {
            var autoTyperService = await _stateService.GetAutoTyperProviderAsync();
            AutoTyperSelectedIndex = autoTyperService == null ? 0 :
                AutoTyperServiceOptions.FindIndex(k => (int?)k.Key == autoTyperService);

            var layout = await _stateService.GetAutoTyperLayoutAsync();
            LayoutSelectedIndex = layout == null ? 0 :
                LayoutOptions.FindIndex(k => (int?)k.Key == layout);

            _inited = true;
        }

        private async Task SaveAutoTyperAsync()
        {
            if (_inited && AutoTyperSelectedIndex > -1)
            {
                await _stateService.SetAutoTyperProvider((int?)AutoTyperServiceOptions[AutoTyperSelectedIndex].Key);
            }
        }

        private async Task SaveLayoutAsync()
        {
            if (_inited && LayoutSelectedIndex > -1)
            {
                await _stateService.SetAutoTyperLayoutAsync((int?)LayoutOptions[LayoutSelectedIndex].Key);
            }
        }
    }
}
