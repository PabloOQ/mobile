using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bit.Core.Enums;

namespace Bit.Core.Abstractions
{
    public interface IAutoTyperService
    {
        Task Connect();
        Task Disconnect();
        Task Type(String text);
        Task Type(String text, LayoutType layout, SpeedType speed);
        Task<List<LayoutType>> GetCompatibleLayouts();
        Task<AutoTyperProviderType> GetProviderTypeAsync();
        Task SetProviderAsync(AutoTyperProviderType type);
        Task<LayoutType> GetLayoutAsync();
        Task SetLayoutAsync(LayoutType type);
        Task<SpeedType> GetSpeedAsync();
        Task SetSpeedAsync(SpeedType speed);
    }
}
