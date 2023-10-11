using AutoMapper;
using TaskManagement.Application.Task.Commands.CreateTask;
using TaskManagement.Application.Task.Commands.UpdateTask;
using TaskManagement.Application.Task.Queries.GetTaskList;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Task
            // Create Task
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

            // GetTask Details
            CreateMap<TaskEntity, GetTaskDetailsModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                .ForMember(dest => dest.AttachFile, opt => opt.MapFrom(src => src.AttachFile));

            // update task
            CreateMap<UpdateTaskModel, UpdateTaskCommand>();
            CreateMap<UpdateTaskCommand, UpdateTaskModel>();
            CreateMap<UpdateTaskCommand, TaskEntity>(); 
            #endregion

        }
    }
}
