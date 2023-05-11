using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Bit.App.Pages
{
    public partial class AutoTyperServicesPage : BaseContentPage
    {
        private readonly AutoTyperServicesPageViewModel _vm;
        private readonly SettingsPage _settingsPage;

        public AutoTyperServicesPage(SettingsPage settingsPage)
        {
            InitializeComponent();
            _vm = BindingContext as AutoTyperServicesPageViewModel;
            _vm.Page = this;
            _settingsPage = settingsPage;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _vm.InitAsync();
        }

        protected override void OnDisappearing()
        {
            _settingsPage.BuildList();
            base.OnDisappearing();
        }
    }
}
