using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meetup.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    MeetingTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 4, 20, 23, 49, 43, 383, DateTimeKind.Local).AddTicks(7937))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false, defaultValue: 4)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingUser",
                columns: table => new
                {
                    MeetingsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingUser", x => new { x.MeetingsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MeetingUser_Meetings_MeetingsId",
                        column: x => x.MeetingsId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "Description", "Location", "MeetingTime", "Title" },
                values: new object[] { 1, "Some meetup 1", "Some meetup street 1", new DateTime(2023, 3, 21, 23, 49, 43, 383, DateTimeKind.Local).AddTicks(8377), "Meetup 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "admin", "admin", "admin", 1, "admin" },
                    { 2, "owner@gmail.com", "owner", "owner", "owner", 2, "owner" },
                    { 3, "speaker@gmail.com", "speaker", "speaker", "speaker", 3, "speaker" },
                    { 4, "user@gmail.com", "user", "user", "user", 4, "user" }
                });

            migrationBuilder.InsertData(
                table: "MeetingUser",
                columns: new[] { "MeetingsId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingUser_UsersId",
                table: "MeetingUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingUser");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
