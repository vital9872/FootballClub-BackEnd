using FluentValidation;
using Football.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Validation
{
    public class ContractVMValidator: AbstractValidator<ContractDto>
    {
        public ContractVMValidator()
        {
            RuleFor(x => x.Premium).LessThanOrEqualTo(100);
            RuleFor(x => x.Salary).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.SignedDate).NotEmpty();
            RuleFor(x => x.ExpireDate).NotEmpty()
                .GreaterThan(x => x.SignedDate).WithMessage("Expire date must after signed date");
        }
    }
}
