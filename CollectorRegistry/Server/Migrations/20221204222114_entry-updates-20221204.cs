using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorRegistry.Server.Migrations
{
    /// <inheritdoc />
    public partial class entryupdates20221204 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryDefinitions",
                columns: table => new
                {
                    EntryDefinitionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryDefinitions", x => x.EntryDefinitionID);
                    table.ForeignKey(
                        name: "FK_EntryDefinitions_Sites_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Sites",
                        principalColumn: "SiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryValues",
                columns: table => new
                {
                    EntryValueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDefinitionID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryValues", x => x.EntryValueID);
                    table.ForeignKey(
                        name: "FK_EntryValues_Entries_EntryID",
                        column: x => x.EntryID,
                        principalTable: "Entries",
                        principalColumn: "EntryID");
                    table.ForeignKey(
                        name: "FK_EntryValues_EntryDefinitions_EntryDefinitionID",
                        column: x => x.EntryDefinitionID,
                        principalTable: "EntryDefinitions",
                        principalColumn: "EntryDefinitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryDefinitions_SiteID",
                table: "EntryDefinitions",
                column: "SiteID");

            migrationBuilder.CreateIndex(
                name: "IX_EntryValues_EntryDefinitionID",
                table: "EntryValues",
                column: "EntryDefinitionID");

            migrationBuilder.CreateIndex(
                name: "IX_EntryValues_EntryID",
                table: "EntryValues",
                column: "EntryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryValues");

            migrationBuilder.DropTable(
                name: "EntryDefinitions");
        }
    }
}
