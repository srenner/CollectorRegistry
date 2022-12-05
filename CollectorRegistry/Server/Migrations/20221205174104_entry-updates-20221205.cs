using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorRegistry.Server.Migrations
{
    /// <inheritdoc />
    public partial class entryupdates20221205 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "EntryValues");

            migrationBuilder.AddColumn<int>(
                name: "EntryDefinitionOptionID",
                table: "EntryValues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EntryDefinitionsOptions",
                columns: table => new
                {
                    EntryDefinitionOptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDefinitionID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryDefinitionsOptions", x => x.EntryDefinitionOptionID);
                    table.ForeignKey(
                        name: "FK_EntryDefinitionsOptions_EntryDefinitions_EntryDefinitionID",
                        column: x => x.EntryDefinitionID,
                        principalTable: "EntryDefinitions",
                        principalColumn: "EntryDefinitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryValues_EntryDefinitionOptionID",
                table: "EntryValues",
                column: "EntryDefinitionOptionID");

            migrationBuilder.CreateIndex(
                name: "IX_EntryDefinitionsOptions_EntryDefinitionID",
                table: "EntryDefinitionsOptions",
                column: "EntryDefinitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryValues_EntryDefinitionsOptions_EntryDefinitionOptionID",
                table: "EntryValues",
                column: "EntryDefinitionOptionID",
                principalTable: "EntryDefinitionsOptions",
                principalColumn: "EntryDefinitionOptionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryValues_EntryDefinitionsOptions_EntryDefinitionOptionID",
                table: "EntryValues");

            migrationBuilder.DropTable(
                name: "EntryDefinitionsOptions");

            migrationBuilder.DropIndex(
                name: "IX_EntryValues_EntryDefinitionOptionID",
                table: "EntryValues");

            migrationBuilder.DropColumn(
                name: "EntryDefinitionOptionID",
                table: "EntryValues");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "EntryValues",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
