using ASAP.Domain.Contracts;
using ASAP.Domain.Model.Client;
using FluentValidation;

namespace ASAP.ApplicationService.Features.Client
{

    public class GetPagedClientsQueryValidator : AbstractValidator<PagationFilter>
    {
        public GetPagedClientsQueryValidator() 
        {
            RuleFor(c => c.SortField)
                 .NotEmpty().WithMessage("SortField Can Not Be Empty")
                 .NotNull().WithMessage("SortField Can Not Be Null");

        }
    }
}
