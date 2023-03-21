using Meetup.Core.Models;
using Meetup.Data.Configuration;
using Meetup.Data.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingConfiguration());
            modelBuilder.ApplyConfiguration(new UserSeed());
            modelBuilder.ApplyConfiguration(new MeetingSeed());

            modelBuilder.Entity("MeetingUser").HasData(
                new { MeetingsId = 1, UsersId = 1 },
                new { MeetingsId = 1, UsersId = 2 },
                new { MeetingsId = 1, UsersId = 3 },
                new { MeetingsId = 1, UsersId = 4 }
                );
        }
    }
}
