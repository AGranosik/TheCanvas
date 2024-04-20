using backend.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

            var isRoomExist = await IsRoomExistsAsync(request.Name);
            if (isRoomExist)
                throw new ArgumentException("Room already exists.");

            var sessionId = Guid.NewGuid();
            _context.Rooms.Add(new Room
            {
                ID = sessionId,
                Name = request.Name,
            });
            await _context.SaveChangesAsync(cancellationToken);

            return sessionId;
        }

        private Task<bool> IsRoomExistsAsync(string name)
            => _context.Rooms.AnyAsync(r => r.Name == name);
    }
}
