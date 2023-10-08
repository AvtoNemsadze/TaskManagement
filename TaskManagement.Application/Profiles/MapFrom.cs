using AutoMapper;

namespace TaskManagement.Application.Profiles
{
    public class MapFrom<T> : IMapFrom<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
