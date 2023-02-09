using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorRegistry.Server.Migrations
{
    /// <inheritdoc />
    public partial class latlongdouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "GeoLong",
                table: "Entries",
                type: "float(11)",
                precision: 11,
                scale: 8,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,8)",
                oldPrecision: 11,
                oldScale: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "GeoLat",
                table: "Entries",
                type: "float(10)",
                precision: 10,
                scale: 8,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,8)",
                oldPrecision: 10,
                oldScale: 8,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "GeoLong",
                table: "Entries",
                type: "decimal(11,8)",
                precision: 11,
                scale: 8,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float(11)",
                oldPrecision: 11,
                oldScale: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GeoLat",
                table: "Entries",
                type: "decimal(10,8)",
                precision: 10,
                scale: 8,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float(10)",
                oldPrecision: 10,
                oldScale: 8,
                oldNullable: true);
        }
    }
}
