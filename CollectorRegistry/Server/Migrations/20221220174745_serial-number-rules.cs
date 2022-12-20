using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorRegistry.Server.Migrations
{
    /// <inheritdoc />
    public partial class serialnumberrules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumberEndsWith",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerialNumberMaxLength",
                table: "Sites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerialNumberMinLength",
                table: "Sites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumberStartsWith",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumberEndsWith",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "SerialNumberMaxLength",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "SerialNumberMinLength",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "SerialNumberStartsWith",
                table: "Sites");
        }
    }
}
