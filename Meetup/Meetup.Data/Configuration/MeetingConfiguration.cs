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
    internal class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder
                .Property(m => m.Title)
                .HasMaxLength(128)
                .IsRequired();
            builder
                .Property(m => m.Description)
                .HasColumnType("text")
                .IsRequired();
            builder
                .Property(m => m.Location)
                .HasMaxLength(400)
                .IsRequired();
            builder
                .Property(m => m.MeetingTime)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
