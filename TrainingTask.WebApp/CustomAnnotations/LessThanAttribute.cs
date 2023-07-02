
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TrainingTask.WebApp.CustomAnnotations
{
    public class LessThanAttribute:ValidationAttribute
    {
        public string OtherPropertyName { get; } 
        public LessThanAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var first = value as dynamic;
            var second = validationContext.ObjectInstance.GetType().GetProperty(OtherPropertyName).GetValue(validationContext.ObjectInstance) as dynamic;

            if (first <= second)
                return ValidationResult.Success;

            var errorMessage = $"{validationContext.DisplayName} Must Be Less Than Or Equal To {OtherPropertyName}";
            return new ValidationResult(ErrorMessage ?? errorMessage);
        }
    }
}
