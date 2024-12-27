using Example.Domain.Interfaces.Services;

namespace Example.Application.CreateHelloWorld;

public class CreateHelloWorldHandler : IRequestHandler<CreateHelloWorldCommand, CreateHelloWorldResult>
{
    private readonly ILogger<CreateHelloWorldHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IHelloWorldService _helloWorldService;

    public CreateHelloWorldHandler(ILogger<CreateHelloWorldHandler> logger,
                                    IMapper mapper,
                                    IHelloWorldService helloWorldService) =>
        (_logger, _mapper, _helloWorldService) = (logger, mapper, helloWorldService);

    public async Task<CreateHelloWorldResult> Handle(CreateHelloWorldCommand request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Init Handle");

        var response = await _helloWorldService.Create(request.UserName, (int)request.Level);
        return _mapper.Map<CreateHelloWorldResult>(response);
    }
}