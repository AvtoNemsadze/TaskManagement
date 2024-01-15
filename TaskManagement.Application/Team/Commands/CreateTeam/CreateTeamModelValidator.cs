using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Team.Commands.CreateTeam
{
    public class CreateTeamModelValidator : AbstractValidator<CreateTeamModel>
    {
        public CreateTeamModelValidator()
        {
            RuleFor(model => model.TeamName)
                .NotEmpty().WithMessage("TeamName is required.")
                .MaximumLength(50).WithMessage("TeamName must not exceed 50 characters.");

            RuleFor(model => model.TeamDescription)
                .MaximumLength(200).WithMessage("TeamDescription must not exceed 200 characters.");

            RuleFor(model => model.MemberIds)
                .Must(BeAValidListOfMemberIds).WithMessage("MemberIds must be a valid list of user IDs.");
        }

        private bool BeAValidListOfMemberIds(List<int>? memberIds)
        {
            // You can implement custom validation logic here
            // For example, check if the list is not null and contains valid user IDs
            return memberIds != null && memberIds.All(id => id > 0);
        }
    }
}
