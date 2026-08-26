using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundooNotesApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddReminderFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReminderSent",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReminderDateTime",
                table: "Notes",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReminderSent",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ReminderDateTime",
                table: "Notes");
        }
    }
}
