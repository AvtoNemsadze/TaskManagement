using AutoMapper;
using TaskManagement.Application.Task.Commands.CreateTask;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskEntity, CreateTaskModel>();

            CreateMap<CreateTaskModel, CreateTaskCommand>()
           .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
           .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
           .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
           .ForMember(dest => dest.AttachFile, opt => opt.MapFrom(src => src.AttachFile));

            CreateMap<CreateTaskCommand, CreateTaskModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                .ForMember(dest => dest.AttachFile, opt => opt.MapFrom(src => src.AttachFile));
        }
    }
}
