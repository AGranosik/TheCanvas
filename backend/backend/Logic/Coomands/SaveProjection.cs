using backend.Logic.Common;
using MediatR;

namespace backend.Logic.Coomands
{
    public class SaveProjection : IRequest
    {
        public IFormFile Image { get; set; }
        public bool ProjectionBefore { get; set; }
    }

    public class Save2DProjectionCommandHandler : IRequestHandler<SaveProjection>
    {
        private readonly ISessionResolver _sessionResolver;

        public Save2DProjectionCommandHandler(ISessionResolver sessionResolver)
        {
            _sessionResolver = sessionResolver;
        }

        public async Task Handle(SaveProjection request, CancellationToken cancellationToken)
        {
            if (request == null || request.Image == null || request.Image.Length == 0)
                throw new ArgumentException("Sth wrong with image.");

            var imagesPath = PathExtensions.GetImagesPath(_sessionResolver.GetSessionId());

            var filePath = Path.Combine(imagesPath.ToString(), request.Image.FileName + (request.ProjectionBefore ? "_before" : "_after"));
            using var stream = new FileStream(filePath, FileMode.Create);
            await request.Image.CopyToAsync(stream, cancellationToken);
        }
    }
}
