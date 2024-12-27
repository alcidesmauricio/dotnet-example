using Example.Application.CreateHelloWorld;
using Example.Domain.Enums;
using Xunit;

namespace Example.Application.UnitTests.CreateHelloWorld;

public class CreateHelloWorldResultTests
{
    [Fact]
    public void Should_Fill_All_Properties()
    {
        // Arrange
        var result = new CreateHelloWorldResult
        {
            Id = Guid.NewGuid(),
            UserName = "test",
            Level = UserLevel.Admin
        };

        // Act & Assert
        foreach (var property in result.GetType().GetProperties())
        {
            Assert.False(property.GetValue(result) == default, $"{property.DeclaringType}.{property.Name} is default value.");
        }
    }
}