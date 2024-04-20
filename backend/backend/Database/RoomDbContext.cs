using System;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options) : base(options)
        {
            
        }
        public DbSet<Room> Rooms { get; set; }
    }
}
