using Meetup.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Seed
{
    public class MeetingSeed : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.HasData(
                new Meeting
                {
                    Id = 1,
                    Title = "Meetup 1",
                    Description = "Some meetup 1",
                    Location = "Some meetup street 1",
                    MeetingTime = DateTime.Now
                });
        }
    }
}
