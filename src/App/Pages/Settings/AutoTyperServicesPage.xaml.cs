using System;
using Xamarin.Forms;

namespace Bit.App.Pages
{
    public partial class AutoTyperServicesPage : BaseContentPage
    {
        private readonly AutoTyperServicesPageViewModel _vm;

        public AutoTyperServicesPage(SettingsPage settingsPage)
        {
            InitializeComponent();
            _vm = BindingContext as AutoTyperServicesPageViewModel;
            _vm.Page = this;
            _autoTyperPicker.ItemDisplayBinding = new Binding("Value");
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _vm.InitAsync();
        }
    }
}
