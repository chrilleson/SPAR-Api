using MediatR;
using Microsoft.AspNetCore.Mvc;
using SPAR.Application.PersonalData.Command;
using SPAR.Application.PersonalData.Models;
using SPAR.Application.PersonalData.Queries;

namespace SPAR.Api.Controllers;

[ApiController]
[Route("personal-data")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<PersonSökResponse> Get() => await _mediator.Send(new GetPersonalDataQuery());

    [HttpPost]
    public async Task Post(PersonSökRequest personRequest) => await _mediator.Send(new CreatePersonCommand(personRequest));
}