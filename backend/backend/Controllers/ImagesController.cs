using backend.Logic.Coomands;
using backend.Logic.Queries;
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

        [HttpGet("Prompt")]
        public async Task<IActionResult> GetImages(CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new GetImageComaprisionQuery(), cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetImages([FromQuery] GetFilesQuery request, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(request, cancellationToken));

        [HttpPost("before")]
        public async Task<IActionResult> PostImageBefore(IFormFile file, CancellationToken cancellationToken)
        {
            await _mediator.Send(new SaveProjection
            {
                Image = file,
                ProjectionBefore = true
            }, cancellationToken);
            return Ok();
        }

        [HttpPost("after")]
        public async Task<IActionResult> PostImageAfter(IFormFile file, CancellationToken cancellationToken)
        {
            await _mediator.Send(new SaveProjection
            {
                Image = file,
                ProjectionBefore = false
            }, cancellationToken);
            return Ok();
        }
    }
}
