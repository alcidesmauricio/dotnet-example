namespace Example.Application.CreateHelloWorld
{
    public class CreateHelloWorldCommand : IRequest<CreateHelloWorldResult>
    {
        public string UserName { get; set; } = default!;
        public UserLevel Level { get; set; }
    }
}