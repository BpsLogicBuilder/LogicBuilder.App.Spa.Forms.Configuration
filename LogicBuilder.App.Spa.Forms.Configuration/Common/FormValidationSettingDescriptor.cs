using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class FormValidationSettingDescriptor(object? defaultValue, List<ValidatorDescriptionDescriptor>? validators)
    {
        public object? DefaultValue { get; } = defaultValue;
        public List<ValidatorDescriptionDescriptor>? Validators { get; } = validators;
    }
}