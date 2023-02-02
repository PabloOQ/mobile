using System;
using System.Collections.Generic;
using System.Text;
using Bit.Core.Enums;

namespace Bit.Core.Abstractions
{
    public interface IAutoTyper
    {
        LayoutType layout { get; set; }
        int speed { get; set; }
        void Type(String text);
    }
}
