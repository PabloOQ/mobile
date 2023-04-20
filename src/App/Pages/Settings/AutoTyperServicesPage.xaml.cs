using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Bit.App.Pages
{
    public partial class AutoTyperServicesPage : BaseContentPage
    {
        private readonly AutoTyperServicesPageViewModel _vm;

        public AutoTyperServicesPage()
        {
            InitializeComponent();
            _vm = BindingContext as AutoTyperServicesPageViewModel;
            _vm.Page = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _vm.InitAsync();
        }
    }
}
