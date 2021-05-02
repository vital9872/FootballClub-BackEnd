using FluentValidation;
using Football.API.ViewModels;
using Football.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Validation
{
    public class PlayerVMValidator : AbstractValidator<PlayerDto>
    {
        public PlayerVMValidator()
        {
            RuleFor(x => x.Club_Id).GreaterThan(0);
            RuleFor(x => x.Birth).NotEmpty();
            RuleFor(x => x.Position).NotNull();
            RuleFor(x => x.FirstName).Length(1, 50);
            RuleFor(x => x.LastName).Length(1, 50);
        }
    }
}
