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
    internal class ParticipantConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(p => p.UserName)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(p => p.Role)
                .HasDefaultValue(Role.User);
            builder
                .HasMany(m => m.Meetings)
                .WithMany(p => p.Users);
        }
    }
}
