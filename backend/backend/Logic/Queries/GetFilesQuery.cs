using backend.Logic.Common;
using MediatR;

namespace backend.Logic.Queries
{
    public class FilesResponse
    {
        // antipatter
        public string Path { get; set; }
        public List<ArchetectureFile> FileNames { get; set; }
    }
    
    public class ArchetectureFile
    {
        public string FileName { get; set; }
        public EFileType Type { get; set; }
        public bool Before { get; set; }
    }

    public enum EFileType
    {
        Images2d,
        View3d,
        Other
    }
    public class GetFilesQuery : IRequest<FilesResponse>
    {
    }

    public class GetFilesQueryHandler : IRequestHandler<GetFilesQuery, FilesResponse>
    {
        private readonly ISessionResolver _session;

        public GetFilesQueryHandler(ISessionResolver sessionResolver)
        {
            _session = sessionResolver;
        }

        public async Task<FilesResponse> Handle(GetFilesQuery request, CancellationToken cancellationToken)
        {
            var sesion = _session.GetSessionId();
            var path = PathExtensions.GetImagesPath(sesion);
            var files = Directory.GetFiles(path).Select(Path.GetFileName);

            return new FilesResponse
            {
                Path = path,
                FileNames = files.Select(f => new ArchetectureFile
                {
                    FileName = f,
                    Type = f.Contains(".jpg") ? EFileType.Images2d : EFileType.View3d,
                    Before = f.Contains("_before") ? true : false
                }).ToList()
            };
        }
    }
}
