using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }
        public IFormFile? File { get; set; }
    }

    public class CreateTaskMapping : Profile 
    {
        public CreateTaskMapping() 
        {
            CreateMap<CreateTaskCommand, CreateTaskModel>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.CreateTaskModel.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CreateTaskModel.Description))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.CreateTaskModel.DueDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.CreateTaskModel.Priority))
            .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.CreateTaskModel.File)).ReverseMap();
        }
    }
}
