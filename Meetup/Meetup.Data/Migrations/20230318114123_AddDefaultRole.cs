using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meetup.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: true,
                defaultValue: "User",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MeetingTime",
                table: "Meetings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 18, 14, 41, 22, 973, DateTimeKind.Local).AddTicks(6374),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 3, 17, 17, 37, 20, 731, DateTimeKind.Local).AddTicks(4240));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MeetingTime",
                table: "Meetings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 17, 17, 37, 20, 731, DateTimeKind.Local).AddTicks(4240),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 3, 18, 14, 41, 22, 973, DateTimeKind.Local).AddTicks(6374));
        }
    }
}
