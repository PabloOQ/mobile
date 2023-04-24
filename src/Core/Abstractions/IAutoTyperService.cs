using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bit.Core.Enums;

namespace Bit.Core.Abstractions
{
    public interface IAutoTyperService
    {
        Task Prepare();
        Task Type(String text);
        Task Type(String text, LayoutType layout, SpeedType speed);
        Task<List<LayoutType>> CompatibleLayouts();
        Task<AutoTyperProviderType> GetProviderTypeAsync();
        Task SetProviderAsync(AutoTyperProviderType type);
        Task<LayoutType> GetLayoutAsync();
        Task SetLayoutAsync(LayoutType type);
        Task<SpeedType> GetSpeedAsync();
        Task SetSpeedAsync(int speed);
    }
}
