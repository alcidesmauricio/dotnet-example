namespace Example.Application.UnitTests.CreateHelloWorld;

public class CreateHelloWorldValidatorTests
{
    private readonly CreateHelloWorldValidator _validator = new();

    [Fact]
    public void Should_UserNameIsEmpty()
    {
        // Arrange
        var command = new CreateHelloWorldCommand
        {
            Level = UserLevel.Admin
        };

        // Act
        var result = _validator.Validate(command);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Should_IsValid()
    {
        // Arrange
        var command = new CreateHelloWorldCommand
        {
            UserName = "Test",
            Level = UserLevel.Admin
        };

        // Act
        var result = _validator.Validate(command);

        // Assert
        Assert.True(result.IsValid);
    }
}