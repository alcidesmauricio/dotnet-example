namespace Example.Application.Common.Mappings;

public interface IMapFrom<T>
{
    static abstract void Mapping(Profile profile);
}