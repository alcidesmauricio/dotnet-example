namespace Example.Application.UnitTests.Common.Mappings;

public class MappingProfileTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingProfileTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Fact]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Theory]
    [InlineData(typeof(HelloWorldResponse), typeof(CreateHelloWorldResult))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);
        _mapper.Map(instance, source, destination);
    }

    private static object GetInstanceOf(Type type) =>
        type.GetConstructor(Type.EmptyTypes) != null
            ? Activator.CreateInstance(type)!
            : FormatterServices.GetUninitializedObject(type);
}