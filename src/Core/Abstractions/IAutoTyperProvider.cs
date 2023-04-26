using System;
using System.Collections.Generic;
using System.Text;
using Bit.Core.Enums;

namespace Bit.Core.Abstractions
{
    public interface IAutoTyperProvider
    {
        void Connect();
        void Disconnect();
        void Type(String text, LayoutType layout, SpeedType speed);
        List<LayoutType> CompatibleLayouts();
        AutoTyperProviderType GetProviderType();
        int SpeedToValue(SpeedType speed);
    }
}
