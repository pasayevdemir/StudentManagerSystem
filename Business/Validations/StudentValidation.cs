using Entities.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class StudentValidation : AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(x => x.FirstName)
                .MinimumLength(3)
                .WithMessage("Ad 3 simvoldan az ola bilməz!")
                .MaximumLength(50)
                .WithMessage("Ad 50 simvoldan çox ola bilməz!")
                .NotEmpty()
                .WithMessage("Ad sahəsi boş ola bilməz!");

            RuleFor(x => x.LastName)
                .MinimumLength(3)
                .WithMessage("Ad 3 simvoldan az ola bilməz!")
                .MaximumLength(50)
                .WithMessage("Ad 50 simvoldan çox ola bilməz!")
                .NotEmpty()
                .WithMessage("Ad sahəsi boş ola bilməz!");
        }
    }
}
