using AspireTemplate.ApiService.Database;
using FluentValidation;

namespace AspireTemplate.ApiService
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(person => person.Age)
                .InclusiveBetween(0, 120).WithMessage("Age must be between 0 and 120.");
        }
    }

   
}