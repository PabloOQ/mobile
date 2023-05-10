using System.Threading.Tasks;

namespace Bit.Core.Abstractions
{
    public interface IAutoTyperWrapper
    {
        Task LoadAsync();
        void Connect();
        void Disconnect();
        void Type(string text);
        bool IsEnabled();
    }
}
