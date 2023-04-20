using Bit.Core.Attributes;

namespace Bit.Core.Enums
{
    public enum AutoTyperProviderType : byte
    {
        [LocalizableEnum("Off")]
        None = 0,
        [LocalizableEnum("AutoTyperInputStick")]
        InputStick = 1,
    }
}
