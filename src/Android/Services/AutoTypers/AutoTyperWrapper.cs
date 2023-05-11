using System.Collections.Generic;
using System.Threading.Tasks;
using Bit.Core.Abstractions;
using Bit.Core.Enums;

namespace Bit.Droid.Services.AutoTypers
{
    internal class AutoTyperWrapper : IAutoTyperWrapper
    {
        private readonly IAutoTyperService _autoTyperService;

        private IAutoTyperProvider typer;
        private LayoutType layout;
        private SpeedType speed;

        public AutoTyperWrapper(AutoTyperProviderType typerProviderType, IAutoTyperService autoTyperService)
        {
            _autoTyperService = autoTyperService;
            typer = autoTyperService.CreateTyper(typerProviderType);
        }

        public async Task LoadAsync()
        {
            var typer = await _autoTyperService.GetProviderTypeAsync();
            this.typer = _autoTyperService.CreateTyper(typer);
            if (typer != AutoTyperProviderType.None)
            {
                layout = await _autoTyperService.GetLayoutAsync(typer);
                speed = await _autoTyperService.GetSpeedAsync(typer);
            }
        }

        public bool IsEnabled()
        {
            return !(typer is null);
        }

        // Provider
        public void Connect()
        {
            typer.Connect();
        }
        public void Disconnect()
        {
            typer.Disconnect();
        }

        public void Type(string text)
        {
            typer.Type(text, layout, speed);
        }

    }
}
