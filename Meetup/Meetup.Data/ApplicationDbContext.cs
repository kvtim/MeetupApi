using Meetup.Domain.Models;
using Meetup.Infascructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Infascructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new SpeakerConfiguration());
            modelBuilder.ApplyConfiguration(new SponsorConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingConfiguration());
        }
    }
}
