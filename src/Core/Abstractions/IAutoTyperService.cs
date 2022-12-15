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
        Layout GetLayout();
        void SetLayout(Layout layout);
        int GetSpeed();
        void SetSpeed(int speed);
    }
}
