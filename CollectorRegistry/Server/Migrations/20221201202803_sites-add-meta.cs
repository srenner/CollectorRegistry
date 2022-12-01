using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorRegistry.Server.Migrations
{
    /// <inheritdoc />
    public partial class sitesaddmeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Sites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Sites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sites",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sites");
        }
    }
}
