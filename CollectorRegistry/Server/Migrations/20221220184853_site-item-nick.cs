using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorRegistry.Server.Migrations
{
    /// <inheritdoc />
    public partial class siteitemnick : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemNickname",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemNickname",
                table: "Sites");
        }
    }
}
