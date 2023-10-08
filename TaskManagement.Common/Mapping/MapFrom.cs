using AutoMapper;

namespace TaskManagement.Common.Mapping
{
    public class MapFrom<T> : IMapFrom<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
