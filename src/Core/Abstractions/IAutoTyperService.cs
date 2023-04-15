using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bit.Core.Enums;

namespace Bit.Core.Abstractions
{
    public interface IAutoTyperService
    {
        Task Type(String text, LayoutType layout, int speed);
        Task<List<LayoutType>> CompatibleLayouts();
        Task<AutoTyperProviderType> GetProviderTypeAsync();
        Task SetProviderAsync(AutoTyperProviderType type);
        Task<LayoutType> GetLayoutAsync();
        Task SetLayoutAsync(LayoutType type);
        Task<int> GetSpeedAsync();
        Task SetSpeedAsync(int speed);
    }
}
