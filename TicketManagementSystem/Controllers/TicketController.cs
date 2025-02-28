using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Application.Commands;
using TicketManagementSystem.Application.Queries;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Controllers
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var id = await _mediator.Send(command);
                return Ok(new { TicketId = id });
            }
            catch (Exception ex) {
                return BadRequest(new { Message = "Faild To Create Ticket" });
            }
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<GetTicketsQueryResponse>>> GetTickets()
        {
            try
            {
                var tickets = await _mediator.Send(new GetTicketsQuery());
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Faild To Get Data " });
            }
        }

        [HttpPost("handle/{ticketId}")]
        public async Task<IActionResult> HandleTicket(Guid ticketId)
        {
            try
            {
                var result = await _mediator.Send(new MarkTicketAsHandledCommand { TicketId = ticketId });

                if (!result) return NotFound(new { Message = "Ticket not found" });

                return Ok(new { Message = "Ticket marked as handled" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Faild To Handle Ricket " });


            }
        }
        }
    }
