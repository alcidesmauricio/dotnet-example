using Example.Infrastructure.Services;

namespace Example.Infrastructure.UnitTests.Services;

public class HelloWorldServiceTests
{
    private readonly HelloWorldService _helloWorldService;

    public HelloWorldServiceTests()
    {
        _helloWorldService = new HelloWorldService();
    }

    [Fact]
    public async Task Should_Create_Returns_Ok()
    {
        // Arrange
        string userName = "test";
        int userLevel = (int)UserLevel.Admin;

        // Act
        var result = await _helloWorldService.Create(userName, userLevel);

        // Assert
        Assert.IsType<Guid>(result.UserId);
    }
}