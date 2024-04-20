using backend.Database;
using MediatR;

namespace backend.Logic.Coomands
{
    public class CreateRoomCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }

    public class CreateRoomCommandhandler : IRequestHandler<CreateRoomCommand, Guid>
    {
        private readonly RoomDbContext _context;

        public CreateRoomCommandhandler(RoomDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new Exception("Name cannot be empty.");

            var sessionId = Guid.NewGuid();
            _context.Rooms.Add(new Room
            {
                ID = sessionId,
                Name = request.Name,
            });
            await _context.SaveChangesAsync(cancellationToken);

            return sessionId;
        }
    }
}
