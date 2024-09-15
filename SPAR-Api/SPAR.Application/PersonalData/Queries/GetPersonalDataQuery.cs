using MediatR;
using Microsoft.Extensions.Logging;
using SPAR.Application.PersonalData.Models;
using SPAR.Domain;

namespace SPAR.Application.PersonalData.Queries;

public record GetPersonalDataQuery : IRequest<PersonSökResponse>;

public class GetPersonalDataQueryHandler : IRequestHandler<GetPersonalDataQuery, PersonSökResponse>
{
    private readonly ILogger<GetPersonalDataQueryHandler> _logger;

    public GetPersonalDataQueryHandler(ILogger<GetPersonalDataQueryHandler> logger)
    {
        _logger = logger;
    }

    public async Task<PersonSökResponse> Handle(GetPersonalDataQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting personal data");
            return await Task.FromResult(PersonSökResponse.Create(
                new PersonsökningFråga(["123456"], [ItemsChoice.IdNummer]),
                AviseringPost.CreateFakes()
            ));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting personal data");
            throw;
        }
    }
}