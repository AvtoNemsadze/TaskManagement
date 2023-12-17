using AutoMapper;
using TaskManagement.Application.Task.Commands.UpdateTask;
using TaskManagement.Common.Mapping;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Application.Task.Queries.GetTaskDetails
{
    public class GetTaskDetailsModel : MapFrom<TaskEntity>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string? AttachFile { get; set; }

        public TaskLevelModel TaskLevel { get; set; } = null!;
        public TaskStatusModel TaskStatus { get; set; } = null!;
    }


    public class GetTaskMapping : Profile
    {
        public GetTaskMapping()
        {
            CreateMap<TaskEntity, GetTaskDetailsModel>()
                .ForMember(dest => dest.TaskLevel, opt => opt.MapFrom(src => src.TaskLevelEntity))
                .ForMember(dest => dest.TaskStatus, opt => opt.MapFrom(src => src.TaskStatusEntity));

            CreateMap<TaskLevelEntity, TaskLevelModel>();
            CreateMap<TaskStatusEntity, TaskStatusModel>();
        }
    }

    public class TaskLevelModel : MapFrom<TaskLevelEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public new static void Mapping(Profile profile)
        {
            profile.CreateMap<TaskLevelEntity, TaskLevelModel>()
                .ForMember(o => o.Id, r => r.MapFrom(o => o.Id))
                .ForMember(o => o.Name, r => r.MapFrom(o => o.Name));
        }
    }

    public class TaskStatusModel : MapFrom<TaskStatusEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public new static void Mapping(Profile profile)
        {
            profile.CreateMap<TaskStatusEntity, TaskStatusModel>()
                .ForMember(o => o.Id, r => r.MapFrom(o => o.Id))
                .ForMember(o => o.Name, r => r.MapFrom(o => o.Name));
        }
    }
}
