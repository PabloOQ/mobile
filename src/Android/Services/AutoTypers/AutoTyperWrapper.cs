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
            if (typer != AutoTyperProviderType.None)
            {
                var layout = _autoTyperService.GetLayoutAsync(typer);
                var speed = _autoTyperService.GetSpeedAsync(typer);
                this.layout = await layout;
                this.speed = await speed;
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
