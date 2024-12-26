namespace Example.Application.Common.Mappings;

public interface IMapFrom<T>
{
    static void Mapping(Profile profile) => profile.CreateMap(typeof(T), typeof(T).DeclaringType);
}