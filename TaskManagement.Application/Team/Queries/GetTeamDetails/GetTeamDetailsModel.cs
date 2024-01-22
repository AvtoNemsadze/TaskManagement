using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Models.Identity;
using TaskManagement.Application.Task.Queries.GetTaskDetails;
using TaskManagement.Domain.Entities.Task;
using TaskManagement.Domain.Entities.Team;

namespace TaskManagement.Application.Team.Queries.GetTeamDetails
{
    public class GetTeamDetailsModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }  
        public UserResponseModel? UserResponse { get; set; }
    }

    public class GetTeamMapping : Profile
    {
        public GetTeamMapping()
        {
            CreateMap<TeamEntity, GetTeamDetailsModel>()
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
