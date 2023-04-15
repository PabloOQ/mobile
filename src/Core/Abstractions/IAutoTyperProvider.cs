using System;
using System.Collections.Generic;
using System.Text;
using Bit.Core.Enums;

namespace Bit.Core.Abstractions
{
    public interface IAutoTyperProvider
    {
        void Type(String text, LayoutType layout, int speed);
        List<LayoutType> CompatibleLayouts();
        AutoTyperProviderType GetProviderType();
    }
}
