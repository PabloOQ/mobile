using System.Windows.Input;
using Bit.Core.Abstractions;
using Bit.Core.Models.View;
using Xamarin.Forms;

namespace Bit.App.Lists.ItemViewModels.CustomFields
{
    public class TextCustomFieldItemViewModel : BaseCustomFieldItemViewModel
    {
        private IAutoTyperWrapper _autoTyper;
        public TextCustomFieldItemViewModel(FieldView field,
                                            bool isEditing,
                                            ICommand fieldOptionsCommand,
                                            ICommand copyFieldCommand,
                                            IAutoTyperWrapper autoTyper,
                                            ICommand autoTypeFieldCommand)
            : base(field, isEditing, fieldOptionsCommand)
        {
            _autoTyper = autoTyper;

            CopyFieldCommand = new Command(() => copyFieldCommand?.Execute(Field));
            AutoTypeFieldCommand = new Command(() => autoTypeFieldCommand?.Execute(Field));
        }
        public override bool ShowAutoTyperButton => _autoTyper != null && _autoTyper.IsEnabled() && !_isEditing && !string.IsNullOrWhiteSpace(Field.Value);
        public override bool ShowCopyButton => !_isEditing && !string.IsNullOrWhiteSpace(Field.Value);

        public ICommand AutoTypeFieldCommand { get; }
        public ICommand CopyFieldCommand { get; }
    }
}
