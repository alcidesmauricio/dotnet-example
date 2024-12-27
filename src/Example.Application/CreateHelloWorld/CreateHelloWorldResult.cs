using Example.Application.Common.Mappings;

namespace Example.Application.CreateHelloWorld;

public class CreateHelloWorldResult : IMapFrom<HelloWorldResponse>
{
    public Guid Id { get; set; }
    public required string UserName { get; set; } // Usando 'required' do C# 12 para propriedades obrigatórias
    public UserLevel Level { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HelloWorldResponse, CreateHelloWorldResult>()
            .ForMember(d => d.Level, opt => opt.MapFrom(s => (UserLevel)s.Level))
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UserId));
    }
}