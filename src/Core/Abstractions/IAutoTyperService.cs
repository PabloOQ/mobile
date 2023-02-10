using System;
using System.Collections.Generic;
using System.Text;
using Bit.Core.Enums;

namespace Bit.Core.Abstractions
{
    public interface IAutoTyperService
    {
        IAutoTyper typer { get; set; }
        void Type(String text);
        LayoutType GetLayout();
        void SetLayout(LayoutType layout);
        int GetSpeed();
        void SetSpeed(int speed);
    }
}
