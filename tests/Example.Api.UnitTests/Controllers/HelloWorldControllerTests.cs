namespace Example.Api.UnitTests.Controllers;

public class HelloWorldControllerTests
{
    [Fact]
    public async Task Should_Post_Hello_World_Command_To_Mediator()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var createHelloWorldResult = new CreateHelloWorldResult();
        var command = new CreateHelloWorldCommand
        {
            UserName = "test",
            Level = UserLevel.Admin
        };

        mediatorMock.Setup(x => x.Send(command, CancellationToken.None)).ReturnsAsync(createHelloWorldResult);

        var controller = new HelloWorldController(mediatorMock.Object);

        // Act
        var result = await controller.Post(command);

        // Assert
        mediatorMock.Verify(x => x.Send(command, CancellationToken.None), Times.Once);
        Assert.NotNull(result);
    }
}