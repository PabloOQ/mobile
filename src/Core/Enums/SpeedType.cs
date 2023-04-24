using Bit.Core.Attributes;

namespace Bit.Core.Enums
{
    public enum SpeedType : int         // characters per second  - ratio
    {
        [LocalizableEnum("Slowest")]    // 8 - 0.1
        Slowest = 0,
        [LocalizableEnum("Slower")]     // 16 - 0.2
        Slower = 2,
        [LocalizableEnum("Slow")]       // 40 - 0.5
        Slow = 3,
        [LocalizableEnum("Normal")]     // 80 - 1
        Normal = 5,
        [LocalizableEnum("Fast")]       // 120 - 1.5
        Fast = 7,
        [LocalizableEnum("Faster")]     // 180 - 2.25
        Faster = 6,
        [LocalizableEnum("Fastest")]    // 240 - 3
        Fastest = 10,                   
    }
}
