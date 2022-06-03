using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Api.Models.CustomValidation
{
    public class NotNullOrEmptyCollectionAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} list must not be empty";
        public NotNullOrEmptyCollectionAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            var collection = value as ICollection;
            if (collection != null)
            {
                return collection.Count != 0;
            }

            var enumerable = value as IEnumerable;
            return enumerable != null && enumerable.GetEnumerator().MoveNext();
        }
    }
}
