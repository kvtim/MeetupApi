﻿// <auto-generated />
using System;
using Meetup.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Meetup.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MeetingUser", b =>
                {
                    b.Property<int>("MeetingsId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("MeetingsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("MeetingUser");

                    b.HasData(
                        new
                        {
                            MeetingsId = 1,
                            UsersId = 1
                        },
                        new
                        {
                            MeetingsId = 1,
                            UsersId = 2
                        },
                        new
                        {
                            MeetingsId = 1,
                            UsersId = 3
                        },
                        new
                        {
                            MeetingsId = 1,
                            UsersId = 4
                        });
                });

            modelBuilder.Entity("Meetup.Core.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<DateTime?>("MeetingTime")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2023, 4, 20, 23, 49, 43, 383, DateTimeKind.Local).AddTicks(7937));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("Meetings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Some meetup 1",
                            Location = "Some meetup street 1",
                            MeetingTime = new DateTime(2023, 3, 21, 23, 49, 43, 383, DateTimeKind.Local).AddTicks(8377),
                            Title = "Meetup 1"
                        });
                });

            modelBuilder.Entity("Meetup.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(4);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "admin",
                            Role = 1,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "owner@gmail.com",
                            FirstName = "owner",
                            LastName = "owner",
                            Password = "owner",
                            Role = 2,
                            UserName = "owner"
                        },
                        new
                        {
                            Id = 3,
                            Email = "speaker@gmail.com",
                            FirstName = "speaker",
                            LastName = "speaker",
                            Password = "speaker",
                            Role = 3,
                            UserName = "speaker"
                        },
                        new
                        {
                            Id = 4,
                            Email = "user@gmail.com",
                            FirstName = "user",
                            LastName = "user",
                            Password = "user",
                            Role = 4,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("MeetingUser", b =>
                {
                    b.HasOne("Meetup.Core.Models.Meeting", null)
                        .WithMany()
                        .HasForeignKey("MeetingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meetup.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
