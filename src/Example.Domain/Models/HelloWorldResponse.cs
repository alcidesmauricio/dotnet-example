namespace Example.Domain.Models;

public class HelloWorldResponse
{
    public required Guid UserId { get; set; }
    public required string UserName { get; set; }
    public int Level { get; set; }
}