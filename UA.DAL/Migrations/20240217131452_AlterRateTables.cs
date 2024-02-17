using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AlterRateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AverageRate",
                table: "AvgRateGenerations",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRates",
                table: "AvgRateGenerations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "AverageRate",
                table: "AvgRateGearboxes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRates",
                table: "AvgRateGearboxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "AverageRate",
                table: "AvgRateEngines",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRates",
                table: "AvgRateEngines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRates",
                table: "AvgRateGenerations");

            migrationBuilder.DropColumn(
                name: "NumberOfRates",
                table: "AvgRateGearboxes");

            migrationBuilder.DropColumn(
                name: "NumberOfRates",
                table: "AvgRateEngines");

            migrationBuilder.AlterColumn<int>(
                name: "AverageRate",
                table: "AvgRateGenerations",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "AverageRate",
                table: "AvgRateGearboxes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "AverageRate",
                table: "AvgRateEngines",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
