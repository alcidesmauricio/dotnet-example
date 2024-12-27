using Example.Domain.Interfaces.Services;

namespace Example.Application.UnitTests.CreateHelloWorld;

public class CreateHelloWorldHandlerTests
{
    private readonly Mock<ILogger<CreateHelloWorldHandler>> _logger;
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IHelloWorldService> _helloWorldService;

    public CreateHelloWorldHandlerTests()
    {
        _logger = new Mock<ILogger<CreateHelloWorldHandler>>();
        _mapper = new Mock<IMapper>();
        _helloWorldService = new Mock<IHelloWorldService>();
    }

    [Fact]
    public async Task Should_Create_Hello_World_Success()
    {
        // Arrange
        var command = new CreateHelloWorldCommand
        {
            UserName = "test",
            Level = UserLevel.Admin
        };

        var response = new HelloWorldResponse
        {
            UserId = Guid.NewGuid(),
            Level = (int)command.Level,
            UserName = command.UserName
        };

        var createHelloWorldResult = new CreateHelloWorldResult
        {
            Id = response.UserId,
            Level = (UserLevel)response.Level,
            UserName = response.UserName
        };

        var handler = new CreateHelloWorldHandler(_logger.Object,
                                                    _mapper.Object,
                                                    _helloWorldService.Object);

        _helloWorldService.Setup(x => x.Create(command.UserName, (int)command.Level))
                            .ReturnsAsync(response);

        _mapper.Setup(x => x.Map<CreateHelloWorldResult>(It.IsAny<object>())).Returns(createHelloWorldResult);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.NotNull(result);
        _helloWorldService.VerifyAll();
    }

    [Fact]
    public async Task Should_Create_Hello_World_Throw_Exception()
    {
        // Arrange
        var command = new CreateHelloWorldCommand
        {
            UserName = "test",
            Level = UserLevel.Admin
        };

        var handler = new CreateHelloWorldHandler(_logger.Object,
                                                    _mapper.Object,
                                                    _helloWorldService.Object);

        _helloWorldService.Setup(x => x.Create(command.UserName, (int)command.Level))
                            .ThrowsAsync(new Exception());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, default));
    }
}