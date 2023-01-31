using System;
using Xamarin.Forms;

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
    }
}
