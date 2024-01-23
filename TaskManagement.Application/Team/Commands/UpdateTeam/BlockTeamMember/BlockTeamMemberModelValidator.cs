using FluentValidation;
using TaskManagement.Common.Enums;


namespace TaskManagement.Application.Team.Commands.UpdateTeam.BlockTeamMember
{
    public class BlockTeamMemberModelValidator : AbstractValidator<BlockTeamMemberModel>
    {
        public BlockTeamMemberModelValidator()
        {
            RuleFor(model => model.TeamId).NotEmpty();
            RuleFor(model => model.UserIdToBlock).NotEmpty();
            RuleFor(model => model.RequestingUserId).NotEmpty();
            RuleFor(model => model.Duration)
                .NotEmpty()
                .Must(value => Enum.IsDefined(typeof(BlockDuration), value))
                .WithMessage("Invalid block duration. Allowed values are OneDay, OneWeek, or OneMonth.");
        }
    }
}
