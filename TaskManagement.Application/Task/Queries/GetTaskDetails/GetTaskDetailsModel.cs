using AutoMapper;
using TaskManagement.Application.Models.Identity;
using TaskManagement.Application.Task.Commands.UpdateTask;
using TaskManagement.Common.Mapping;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Application.Task.Queries.GetTaskDetails
{
    public class GetTaskDetailsModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? AttachFile { get; set; }

        public TaskLevelModel TaskLevel { get; set; } = new TaskLevelModel();
        public TaskStatusModel TaskStatus { get; set; } = new TaskStatusModel();
        public TaskPriorityModel TaskPriority { get; set; } = new TaskPriorityModel();
        public UserResponseModel? UserResponseModel { get; set; }
    }

    public class TaskLevelModel 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class TaskStatusModel 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }


    public class TaskPriorityModel 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class GetTaskMapping : Profile
    {
        public GetTaskMapping()
        {
            CreateMap<TaskEntity, GetTaskDetailsModel>()
                .ForMember(dest => dest.TaskLevel, opt => opt.MapFrom(src => src.TaskLevelEntity))
                .ForMember(dest => dest.TaskStatus, opt => opt.MapFrom(src => src.TaskStatusEntity))
                .ForMember(dest => dest.TaskPriority, opt => opt.MapFrom(src => src.TaskPriorityEntity));

            CreateMap<TaskLevelEntity, TaskLevelModel>();
            CreateMap<TaskStatusEntity, TaskStatusModel>();
            CreateMap<TaskPriorityEntity, TaskPriorityModel>();
        }
    }
}
