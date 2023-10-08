using AutoMapper;

namespace TaskManagement.Application.Profiles
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
