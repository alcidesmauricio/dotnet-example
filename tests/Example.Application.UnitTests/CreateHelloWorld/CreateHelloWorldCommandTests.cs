namespace Example.Application.UnitTests.CreateHelloWorld;

public class CreateHelloWorldCommandTests
{
    [Fact]
    public void Should_Fill_All_Properties()
    {
        // Arrange
        var command = new CreateHelloWorldCommand
        {
            UserName = "test",
            Level = UserLevel.Admin
        };

        // Act & Assert
        foreach (var property in command.GetType().GetProperties())
        {
            Assert.False(property.GetValue(command) == default, $"{property.DeclaringType}.{property.Name} is default value.");
        }
    }
}