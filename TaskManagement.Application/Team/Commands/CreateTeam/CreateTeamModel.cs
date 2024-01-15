using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Task.Commands.CreateTask;

namespace TaskManagement.Application.Team.Commands.CreateTeam
{
    public class CreateTeamModel
    {
        public string TeamName { get; set; } = null!;
        public string? TeamDescription { get; set; }
        public List<int>? MemberIds { get; set; }
    }

    public class CreateTeamMapping : Profile
    {
        public CreateTeamMapping()
        {
            CreateMap<CreateTeamCommand, CreateTeamModel>()
            .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.CreateTeamModel.TeamName))
            .ForMember(dest => dest.TeamDescription, opt => opt.MapFrom(src => src.CreateTeamModel.TeamDescription))
            .ForMember(dest => dest.MemberIds, opt => opt.MapFrom(src => src.CreateTeamModel.MemberIds)).ReverseMap(); 
        }
    }
}
