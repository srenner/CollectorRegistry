using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorRegistry.Server.Migrations
{
    /// <inheritdoc />
    public partial class items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Sites_SiteID",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "SiteID",
                table: "Entries",
                newName: "ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_SiteID",
                table: "Entries",
                newName: "IX_Entries_ItemID");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Items_ItemID",
                table: "Entries",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Items_ItemID",
                table: "Entries");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "Entries",
                newName: "SiteID");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_ItemID",
                table: "Entries",
                newName: "IX_Entries_SiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Sites_SiteID",
                table: "Entries",
                column: "SiteID",
                principalTable: "Sites",
                principalColumn: "SiteID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
