using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence
{
#nullable disable

    internal class RunicMagicDbContext : DbContext
    {
        public DbSet<RoomRecord> Rooms { get; set; }
        public DbSet<RoomLinkRecord> RoomLinks { get; set; }

        public RunicMagicDbContext(DbContextOptions<RunicMagicDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<RoomRecord>()
                .HasMany(r => r.Links)
                .WithOne(r => r.Origin);

            modelBuilder.Entity<RoomLinkRecord>()
                .HasOne(r => r.Target);
        }
    }
}
