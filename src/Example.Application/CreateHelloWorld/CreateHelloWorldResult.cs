using Example.Application.Common.Mappings;

namespace Example.Application.CreateHelloWorld;

public class CreateHelloWorldResult : IMapFrom<HelloWorldResponse>
{
    public required Guid Id { get; init; }
    public required string UserName { get; init; }
    public required UserLevel Level { get; init; }

    public static void Mapping(Profile profile)
    {
        profile.CreateMap<HelloWorldResponse, CreateHelloWorldResult>()
            .ForMember(d => d.Level, opt => opt.MapFrom(s => (UserLevel)s.Level))
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UserId));
    }
}