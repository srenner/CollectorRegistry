using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorRegistry.Server.Migrations
{
    /// <inheritdoc />
    public partial class itemsite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_SiteID",
                table: "Items",
                column: "SiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Sites_SiteID",
                table: "Items",
                column: "SiteID",
                principalTable: "Sites",
                principalColumn: "SiteID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Sites_SiteID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_SiteID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SiteID",
                table: "Items");
        }
    }
}
