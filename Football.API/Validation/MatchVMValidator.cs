using FluentValidation;
using Football.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Validation
{
    public class MatchVMValidator: AbstractValidator<MatchDto>
    {
        public MatchVMValidator()
        {
            RuleFor(x => x.ClubEnemyName).Length(1, 50);
            RuleFor(x => x.Team1Goals).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Team2Goals).GreaterThanOrEqualTo(0);
            RuleFor(x => x.StartDate).NotEmpty();
        }
    }
}
