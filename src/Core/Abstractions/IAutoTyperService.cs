using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bit.Core.Enums;

namespace Bit.Core.Abstractions
{
    public interface IAutoTyperService
    {
        Task<IAutoTyperWrapper> GetTyperWrapper();

        Task<AutoTyperProviderType> GetProviderTypeAsync();
        Task SetProviderAsync(AutoTyperProviderType type);
        Task<LayoutType> GetLayoutAsync(AutoTyperProviderType type);
        Task SetLayoutAsync(LayoutType layout, AutoTyperProviderType type);
        Task<SpeedType> GetSpeedAsync(AutoTyperProviderType type);
        Task SetSpeedAsync(SpeedType speed, AutoTyperProviderType type);

        List<AutoTyperProviderType> GetCompatibleProviders();
        List<LayoutType> GetCompatibleLayouts(AutoTyperProviderType type);
        List<SpeedType> GetCompatibleSpeeds(AutoTyperProviderType type);

        IAutoTyperProvider CreateTyper(AutoTyperProviderType? type);
        AutoTyperProviderType ProviderType(IAutoTyperProvider? provider);

    }
}
