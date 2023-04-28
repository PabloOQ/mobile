using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bit.App.Resources;
using Bit.Core.Abstractions;
using Bit.Core.Enums;
using Bit.Core.Models.Domain;
using Bit.Core.Services;
using Bit.Core.Utilities;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Bit.App.Pages
{
    public class GeneratorHistoryPageViewModel : BaseViewModel
    {
        private readonly IPlatformUtilsService _platformUtilsService;
        private readonly IPasswordGenerationService _passwordGenerationService;
        private readonly IClipboardService _clipboardService;
        private readonly ILogger _logger;
        private readonly IAutoTyperService _autoTyperService;
        private readonly IStateService _stateService;

        private bool _showNoData;
        private bool _autoTyperServiceEnabled;

        public GeneratorHistoryPageViewModel()
        {
            _platformUtilsService = ServiceContainer.Resolve<IPlatformUtilsService>("platformUtilsService");
            _passwordGenerationService = ServiceContainer.Resolve<IPasswordGenerationService>("passwordGenerationService");
            _clipboardService = ServiceContainer.Resolve<IClipboardService>("clipboardService");
            _logger = ServiceContainer.Resolve<ILogger>("logger");
            _autoTyperService = ServiceContainer.Resolve<IAutoTyperService>("autoTyperService");
            _stateService = ServiceContainer.Resolve<IStateService>("stateService");

            PageTitle = AppResources.PasswordHistory;
            History = new ExtendedObservableCollection<GeneratedPasswordHistory>();
            CopyCommand = new Command<GeneratedPasswordHistory>(CopyAsync);
            AutoTypeCommand = new Command<GeneratedPasswordHistory>(AutoTypeAsync);
        }

        public Command CopyCommand { get; set; }
        public Command AutoTypeCommand { get; set; }
        public ExtendedObservableCollection<GeneratedPasswordHistory> History { get; set; }

        public bool ShowNoData
        {
            get => _showNoData;
            set => SetProperty(ref _showNoData, value);
        }
        public bool ShowAutoTyperButton => _autoTyperServiceEnabled;

        public async Task InitAsync()
        {
            var history = await _passwordGenerationService.GetHistoryAsync();
            Device.BeginInvokeOnMainThread(() =>
            {
                History.ResetWithRange(history ?? new List<GeneratedPasswordHistory>());
                ShowNoData = History.Count == 0;
            });
            var autoTyperProvider = await _stateService.GetAutoTyperProviderAsync();
            _autoTyperServiceEnabled = autoTyperProvider != null &&
                (AutoTyperProviderType)Enum.ToObject(typeof(AutoTyperProviderType), autoTyperProvider) != AutoTyperProviderType.None;
        }

        public async Task ClearAsync()
        {
            History.ResetWithRange(new List<GeneratedPasswordHistory>());
            ShowNoData = true;
            await _passwordGenerationService.ClearAsync();
        }

        private async void CopyAsync(GeneratedPasswordHistory ph)
        {
            await _clipboardService.CopyTextAsync(ph.Password);
            _platformUtilsService.ShowToastForCopiedValue(AppResources.Password);
        }

        private async void AutoTypeAsync(GeneratedPasswordHistory ph)
        {
            await _autoTyperService.Type(ph.Password);
            _platformUtilsService.ShowToast("info", null, string.Format(AppResources.AutoTyperSentToTyper, AppResources.Password));
        }

        public async Task UpdateOnThemeChanged()
        {
            try
            {
                await Device.InvokeOnMainThreadAsync(() => History.ResetWithRange(new List<GeneratedPasswordHistory>()));

                await InitAsync();
            }
            catch (System.Exception ex)
            {
                _logger.Exception(ex);
            }
        }
    }
}
