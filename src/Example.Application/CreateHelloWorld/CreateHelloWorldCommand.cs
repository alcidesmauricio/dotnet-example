namespace Example.Application.CreateHelloWorld;

public record CreateHelloWorldCommand(string UserName, UserLevel Level) : IRequest<CreateHelloWorldResult>;