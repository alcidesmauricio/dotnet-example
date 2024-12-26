namespace Example.Application.Common.Mappings;

public interface IMapFrom<T>
{
    static abstract void Mapping(Profile profile);

    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}