namespace Example.Application.CreateHelloWorld;

public class CreateHelloWorldCommand : IRequest<CreateHelloWorldResult>
{
    public required string UserName { get; set; }
    public UserLevel Level { get; set; }
}