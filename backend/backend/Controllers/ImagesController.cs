using backend.Logic.Coomands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
            => Ok();

        [HttpPost]
        public async Task<IActionResult> PostImage(IFormFile file, CancellationToken cancellationToken)
        {
            await _mediator.Send(new Save2DProjectionCommand
            {
                Image = file
            }, cancellationToken);
            return Ok();
        }
    }
}
