using MediatR;

namespace backend.Logic.Coomands
{
    public class Save2DProjectionCommand : IRequest
    {
        public IFormFile Image { get; set; }
    }

    public class Save2DProjectionCommandHandler : IRequestHandler<Save2DProjectionCommand>
    {
        public async Task Handle(Save2DProjectionCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Image == null || request.Image.Length == 0)
                throw new ArgumentException("Sth wrong with image.");

            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            var imagesPath = Path.Combine(directoryPath, "Images");
            Directory.CreateDirectory(imagesPath);

            var filePath = Path.Combine(imagesPath.ToString(), request.Image.FileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await request.Image.CopyToAsync(stream);
        }
    }
}
