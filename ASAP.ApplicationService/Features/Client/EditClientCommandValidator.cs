using ASAP.Domain.Model.Client;
using FluentValidation;

namespace ASAP.ApplicationService.Features.Client
{

    public class EditClientCommandValidator : AbstractValidator<EditClientModel>
    {
        public EditClientCommandValidator()
        {
            RuleFor(c => c.FirstName)
                 .NotEmpty().WithMessage("FirstName Can Not Be Empty")
                 .NotNull().WithMessage("FirstName Can Not Be Null");

            RuleFor(c => c.Email)
             .NotEmpty().WithMessage("Email Can Not Be Empty")
             .NotNull().WithMessage("Email Can Not Be Null");

            RuleFor(c => c.LastName)
             .NotEmpty().WithMessage("LastName Can Not Be Empty")
             .NotNull().WithMessage("LastName Can Not Be Null");


            RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber Can Not Be Empty")
            .NotNull().WithMessage("PhoneNumber Can Not Be Null");

            RuleFor(c => c.Reference)
           .NotEmpty().WithMessage("Reference Can Not Be Empty")
           .NotNull().WithMessage("Reference Can Not Be Null");
        }
    }
}
