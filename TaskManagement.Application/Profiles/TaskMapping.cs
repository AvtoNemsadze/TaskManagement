using AutoMapper;
using TaskManagement.Application.Task.Commands.CreateTask;
using TaskManagement.Application.Task.Commands.UpdateTask;
using TaskManagement.Application.Task.Queries.GetTaskList;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Profiles
{
    public class TaskMapping : Profile
    {
        public TaskMapping()
        {
            #region Task
            // create task
            CreateMap<CreateTaskModel, CreateTaskCommand>()
                .ConstructUsing(src => new CreateTaskCommand
                {
                    CreateTaskModel = new CreateTaskModel
                    {
                        Title = src.Title,
                        Description = src.Description,
                        DueDate = src.DueDate,
                        Priority = src.Priority,
                        File = src.File
                    }
                });

            CreateMap<CreateTaskCommand, CreateTaskModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.CreateTaskModel.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CreateTaskModel.Description))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.CreateTaskModel.DueDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.CreateTaskModel.Priority))
                .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.CreateTaskModel.File));


            // GetTask Details
            CreateMap<TaskEntity, GetTaskDetailsModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));

            // update task
            CreateMap<UpdateTaskModel, UpdateTaskCommand>();
            CreateMap<UpdateTaskCommand, UpdateTaskModel>();
            CreateMap<UpdateTaskModel, TaskEntity>();
            #endregion

        }
    }
}
