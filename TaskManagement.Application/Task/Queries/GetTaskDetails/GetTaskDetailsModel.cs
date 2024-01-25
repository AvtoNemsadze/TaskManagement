using AutoMapper;
using TaskManagement.Application.Models.Identity;
using TaskManagement.Domain.Entities.Comment;
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
        public List<CommentModel> Comments { get; set; } = new List<CommentModel>();
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

    public class CommentModel
    {
        public int CommentId { get; set; }
        public string Commentext { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }

    public class GetTaskMapping : Profile
    {
        public GetTaskMapping()
        {
            CreateMap<TaskEntity, GetTaskDetailsModel>()
                .ForMember(dest => dest.TaskLevel, opt => opt.MapFrom(src => src.TaskLevelEntity))
                .ForMember(dest => dest.TaskStatus, opt => opt.MapFrom(src => src.TaskStatusEntity))
                .ForMember(dest => dest.TaskPriority, opt => opt.MapFrom(src => src.TaskPriorityEntity))
                
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => (src.Comments ?? new List<CommentEntity>())
                    .OrderByDescending(comment => comment.CreatedAt)
                    .Select(comment => new CommentModel
                    {
                        CommentId = comment.Id,
                        Commentext = comment.Comment,
                        CreatedAt = comment.CreatedAt,
                    }).ToList()));

            CreateMap<TaskLevelEntity, TaskLevelModel>();
            CreateMap<TaskStatusEntity, TaskStatusModel>();
            CreateMap<TaskPriorityEntity, TaskPriorityModel>();
        }
    }
}
