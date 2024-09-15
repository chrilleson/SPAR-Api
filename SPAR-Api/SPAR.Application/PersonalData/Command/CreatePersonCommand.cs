using MediatR;
using Microsoft.Extensions.Logging;
using SPAR.Application.PersonalData.Models;
using SPAR.Domain;

namespace SPAR.Application.PersonalData.Command;

public record CreatePersonCommand(PersonSökRequest Person) : IRequest;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
{
    private readonly ILogger<CreatePersonCommandHandler> _logger;

    public CreatePersonCommandHandler(ILogger<CreatePersonCommandHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Creating person {@Person}", request.Person);
            await Task.CompletedTask;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error creating person");
            throw;
        }
    }
}