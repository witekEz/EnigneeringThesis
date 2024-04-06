using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class nullableBodyTypeId_Body : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodies_BodyTypes_BodyTypeId",
                table: "Bodies");

            migrationBuilder.AlterColumn<int>(
                name: "BodyTypeId",
                table: "Bodies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodies_BodyTypes_BodyTypeId",
                table: "Bodies",
                column: "BodyTypeId",
                principalTable: "BodyTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodies_BodyTypes_BodyTypeId",
                table: "Bodies");

            migrationBuilder.AlterColumn<int>(
                name: "BodyTypeId",
                table: "Bodies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bodies_BodyTypes_BodyTypeId",
                table: "Bodies",
                column: "BodyTypeId",
                principalTable: "BodyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
