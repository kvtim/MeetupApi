﻿using Meetup.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Infascructure.Configuration
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
                .HasOne(m => m.ParticipantMeeting)
                .WithMany(p => p.Participants)
                .HasForeignKey(e => e.ParticipantMeetingId)
                .IsRequired();
        }
    }
}
