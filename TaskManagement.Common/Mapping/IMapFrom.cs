using AutoMapper;

namespace TaskManagement.Common.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}