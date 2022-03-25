using myArchery.Persistance.Models;

namespace myArchery.Classes
{
    public class Validation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;

            if (user.Password == null)
                return new ValidationResult("Password ist verpflichtend");
            else
            {
                return ValidationResult.Success;
            }

            
        }
    }
}
