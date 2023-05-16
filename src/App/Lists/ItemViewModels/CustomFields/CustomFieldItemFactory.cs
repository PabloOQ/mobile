using System;
using System.Windows.Input;
using Bit.App.Utilities;
using Bit.Core.Abstractions;
using Bit.Core.Enums;
using Bit.Core.Models.View;

namespace Bit.App.Lists.ItemViewModels.CustomFields
{
    public interface ICustomFieldItemFactory
    {
        ICustomFieldItemViewModel CreateCustomFieldItem(FieldView field,
                                                        bool isEditing,
                                                        CipherView cipher,
                                                        IPasswordPromptable passwordPromptable,
                                                        ICommand copyFieldCommand,
                                                        ICommand fieldOptionsCommand,
                                                        ICommand autoTypeFieldCommand);
    }

    public class CustomFieldItemFactory : ICustomFieldItemFactory
    {
        readonly II18nService _i18nService;
        readonly IEventService _eventService;
        readonly IAutoTyperWrapper _autoTyper;

        public CustomFieldItemFactory(II18nService i18nService, IEventService eventService, IAutoTyperWrapper autoTyper)
        {
            _i18nService = i18nService;
            _eventService = eventService;
            _autoTyper = autoTyper;
        }

        public ICustomFieldItemViewModel CreateCustomFieldItem(FieldView field,
                                                               bool isEditing,
                                                               CipherView cipher,
                                                               IPasswordPromptable passwordPromptable,
                                                               ICommand copyFieldCommand,
                                                               ICommand fieldOptionsCommand,
                                                               ICommand autoTypeFieldCommand)
        {
            switch (field.Type)
            {
                case FieldType.Text:
                    return new TextCustomFieldItemViewModel(field, isEditing, fieldOptionsCommand, copyFieldCommand, _autoTyper, autoTypeFieldCommand);
                case FieldType.Boolean:
                    return new BooleanCustomFieldItemViewModel(field, isEditing, fieldOptionsCommand);
                case FieldType.Hidden:
                    return new HiddenCustomFieldItemViewModel(field, isEditing, fieldOptionsCommand, cipher, passwordPromptable, _eventService, copyFieldCommand, _autoTyper, autoTypeFieldCommand);
                case FieldType.Linked:
                    return new LinkedCustomFieldItemViewModel(field, isEditing, fieldOptionsCommand, cipher, _i18nService);
                default:
                    throw new NotImplementedException("There is no custom field item for field type " + field.Type);
            }
        }
    }
}
