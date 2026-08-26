using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundooNotesApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddTrashFieldsToNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTrashed",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrashedAt",
                table: "Notes",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTrashed",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TrashedAt",
                table: "Notes");
        }
    }
}
