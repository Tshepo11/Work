using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Api.Models.CustomValidation
{
    public class NotEmptyGuidAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "Value for '{0}' is required.";
        public NotEmptyGuidAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            //NotEmpty doesn't necessarily mean required
            if (value is null)
            {
                return true;
            }

            switch (value)
            {
                case Guid guid:
                    return guid != Guid.Empty;
                default:
                    return true;
            }
        }
    }
}
