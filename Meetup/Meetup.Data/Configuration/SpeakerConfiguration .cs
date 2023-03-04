using Meetup.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Infascructure.Configuration
{
    internal class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
    {
        public void Configure(EntityTypeBuilder<Speaker> builder)
        {
            builder
                .Property(s => s.Report)
                .HasColumnType("text")
                .IsRequired();
            builder
                .HasOne(m => m.SpeakerMeeting)
                .WithOne(p => p.Speaker)
                .HasForeignKey<Meeting>(e => e.SpeakerId)
                .IsRequired();

        }
    }
}
