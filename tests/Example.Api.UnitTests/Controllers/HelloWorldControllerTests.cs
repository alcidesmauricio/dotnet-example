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

        // Act
        var controller = new HelloWorldController(mediatorMock.Object);
        var result = await controller.Post(command);

        // Assert
        mediatorMock.VerifyAll();
        Assert.NotNull(result);
    }
}