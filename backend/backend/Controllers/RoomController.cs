using backend.Controllers.Requests;
using backend.Logic.Coomands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateRoomRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new CreateRoomCommand
            {
                Name = request.Name
            }, cancellationToken));
        }
    }
}
