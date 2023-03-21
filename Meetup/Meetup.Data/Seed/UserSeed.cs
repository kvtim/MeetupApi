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
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "admin",
                    LastName = "admin",
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    Password = "admin",
                    Role = Role.Admin,
                }
                );

            builder.HasData(
                new User
                {
                    Id = 2,
                    FirstName = "owner",
                    LastName = "owner",
                    Email = "owner@gmail.com",
                    UserName = "owner",
                    Password = "owner",
                    Role = Role.Owner,
                }
                );

            builder.HasData(
                new User
                {
                    Id = 3,
                    FirstName = "speaker",
                    LastName = "speaker",
                    Email = "speaker@gmail.com",
                    UserName = "speaker",
                    Password = "speaker",
                    Role = Role.Speaker,
                }
                );

            builder.HasData(
                new User
                {
                    Id = 4,
                    FirstName = "user",
                    LastName = "user",
                    Email = "user@gmail.com",
                    UserName = "user",
                    Password = "user",
                    Role = Role.User,
                }
                );
        }
    }
}
