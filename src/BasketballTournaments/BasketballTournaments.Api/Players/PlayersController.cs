using BasketballTournaments.Application.Players.Commands;
using BasketballTournaments.Application.Players.DTO;
using BasketballTournaments.Application.Players.Queries;
using BasketballTournaments.Application.Shared.Errors;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BasketballTournaments.Api.Players;

[Route("/api/players")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlayersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerResponse(200)]
    [SwaggerResponse(400, "Bad request")]
    public async Task<ActionResult<IEnumerable<PlayerDto>>> Get([FromQuery] GetFilteredPlayerQuery query, CancellationToken cancellationToken)
    {
        IEnumerable<PlayerDto> result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerResponse(200)]
    [SwaggerResponse(404, "Not found")]
    public async Task<ActionResult<PlayerDto>> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        GetPlayerByIdQuery query = new(id);
        Result<PlayerDto> result = await _mediator.Send(query, cancellationToken);
        if (result.HasError<ItemNotFoundError>())
        {
            return NotFound();
        }

        return Ok(result.Value);
    }

    [HttpPost]
    [SwaggerResponse(201)]
    [SwaggerResponse(400, "Bad request")]
    public async Task<ActionResult<PlayerDto>> Create([FromBody] CreatePlayerCommand command, CancellationToken cancellationToken)
    {
        Result<PlayerDto> result = await _mediator.Send(command, cancellationToken);
        if (result.HasError<InvalidArgumentError>())
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Get), result.Value);
    }
}
