using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meetup.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenUserAndMeeting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MeetingTime",
                table: "Meetings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 18, 14, 46, 15, 990, DateTimeKind.Local).AddTicks(8023),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 3, 18, 14, 41, 22, 973, DateTimeKind.Local).AddTicks(6374));

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "MeetingTime",
                table: "Meetings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 18, 14, 41, 22, 973, DateTimeKind.Local).AddTicks(6374),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 3, 18, 14, 46, 15, 990, DateTimeKind.Local).AddTicks(8023));
        }
    }
}
