using Meetup.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Configuration
{
    internal class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();
            builder
                .HasOne(m => m.Meeting)
                .WithMany(p => p.Participants)
                .IsRequired();
        }
    }
}
