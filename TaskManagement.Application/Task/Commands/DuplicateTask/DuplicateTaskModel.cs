using AutoMapper;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Application.Task.Commands.DuplicateTask
{
    public class DuplicateTaskModel : TaskEntity
    {
    }
    
    public class DuplicateTaskMapping : Profile
    {
        public DuplicateTaskMapping()
        {
            CreateMap<TaskEntity, DuplicateTaskModel>().ReverseMap()
                 .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
