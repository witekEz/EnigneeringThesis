using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyColours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyColours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Segment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    TrunkCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeatiledInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeatiledInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivetrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivetrains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    Torque = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FuelConsumptionCity = table.Column<double>(type: "float", nullable: false),
                    FuelConsumptionSuburban = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfGears = table.Column<int>(type: "int", nullable: false),
                    TypeOfGearbox = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suspensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyColourDetailedInfo",
                columns: table => new
                {
                    BodyColoursId = table.Column<int>(type: "int", nullable: false),
                    DeatiledInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyColourDetailedInfo", x => new { x.BodyColoursId, x.DeatiledInfosId });
                    table.ForeignKey(
                        name: "FK_BodyColourDetailedInfo_BodyColours_BodyColoursId",
                        column: x => x.BodyColoursId,
                        principalTable: "BodyColours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BodyColourDetailedInfo_DeatiledInfos_DeatiledInfosId",
                        column: x => x.DeatiledInfosId,
                        principalTable: "DeatiledInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrakeDetailedInfo",
                columns: table => new
                {
                    BrakesId = table.Column<int>(type: "int", nullable: false),
                    DetailedInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrakeDetailedInfo", x => new { x.BrakesId, x.DetailedInfosId });
                    table.ForeignKey(
                        name: "FK_BrakeDetailedInfo_Brakes_BrakesId",
                        column: x => x.BrakesId,
                        principalTable: "Brakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrakeDetailedInfo_DeatiledInfos_DetailedInfosId",
                        column: x => x.DetailedInfosId,
                        principalTable: "DeatiledInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailedInfoSuspension",
                columns: table => new
                {
                    DetailedInfosId = table.Column<int>(type: "int", nullable: false),
                    SuspensionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedInfoSuspension", x => new { x.DetailedInfosId, x.SuspensionsId });
                    table.ForeignKey(
                        name: "FK_DetailedInfoSuspension_DeatiledInfos_DetailedInfosId",
                        column: x => x.DetailedInfosId,
                        principalTable: "DeatiledInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailedInfoSuspension_Suspensions_SuspensionsId",
                        column: x => x.SuspensionsId,
                        principalTable: "Suspensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Generations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinPrice = table.Column<double>(type: "float", nullable: false),
                    MaxPrice = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    DeatiledInfoId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generations_DeatiledInfos_DeatiledInfoId",
                        column: x => x.DeatiledInfoId,
                        principalTable: "DeatiledInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Generations_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyTypeGeneration",
                columns: table => new
                {
                    BodyTypesId = table.Column<int>(type: "int", nullable: false),
                    GenerationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypeGeneration", x => new { x.BodyTypesId, x.GenerationsId });
                    table.ForeignKey(
                        name: "FK_BodyTypeGeneration_BodyTypes_BodyTypesId",
                        column: x => x.BodyTypesId,
                        principalTable: "BodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BodyTypeGeneration_Generations_GenerationsId",
                        column: x => x.GenerationsId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrivetrainGeneration",
                columns: table => new
                {
                    DrivetrainsId = table.Column<int>(type: "int", nullable: false),
                    GenerationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivetrainGeneration", x => new { x.DrivetrainsId, x.GenerationsId });
                    table.ForeignKey(
                        name: "FK_DrivetrainGeneration_Drivetrains_DrivetrainsId",
                        column: x => x.DrivetrainsId,
                        principalTable: "Drivetrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrivetrainGeneration_Generations_GenerationsId",
                        column: x => x.GenerationsId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineGeneration",
                columns: table => new
                {
                    EnginesId = table.Column<int>(type: "int", nullable: false),
                    GenerationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineGeneration", x => new { x.EnginesId, x.GenerationsId });
                    table.ForeignKey(
                        name: "FK_EngineGeneration_Engines_EnginesId",
                        column: x => x.EnginesId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineGeneration_Generations_GenerationsId",
                        column: x => x.GenerationsId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GearboxGeneration",
                columns: table => new
                {
                    GearboxesId = table.Column<int>(type: "int", nullable: false),
                    GenerationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearboxGeneration", x => new { x.GearboxesId, x.GenerationsId });
                    table.ForeignKey(
                        name: "FK_GearboxGeneration_GearBoxes_GearboxesId",
                        column: x => x.GearboxesId,
                        principalTable: "GearBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GearboxGeneration_Generations_GenerationsId",
                        column: x => x.GenerationsId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionalEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RearAxleSteering = table.Column<bool>(type: "bit", nullable: false),
                    StandardTailPipes = table.Column<bool>(type: "bit", nullable: false),
                    Rooftop = table.Column<bool>(type: "bit", nullable: false),
                    ABS = table.Column<bool>(type: "bit", nullable: false),
                    ESP = table.Column<bool>(type: "bit", nullable: false),
                    ASR = table.Column<bool>(type: "bit", nullable: false),
                    GenerationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionalEquipments_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyColourDetailedInfo_DeatiledInfosId",
                table: "BodyColourDetailedInfo",
                column: "DeatiledInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyTypeGeneration_GenerationsId",
                table: "BodyTypeGeneration",
                column: "GenerationsId");

            migrationBuilder.CreateIndex(
                name: "IX_BrakeDetailedInfo_DetailedInfosId",
                table: "BrakeDetailedInfo",
                column: "DetailedInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedInfoSuspension_SuspensionsId",
                table: "DetailedInfoSuspension",
                column: "SuspensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DrivetrainGeneration_GenerationsId",
                table: "DrivetrainGeneration",
                column: "GenerationsId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineGeneration_GenerationsId",
                table: "EngineGeneration",
                column: "GenerationsId");

            migrationBuilder.CreateIndex(
                name: "IX_GearboxGeneration_GenerationsId",
                table: "GearboxGeneration",
                column: "GenerationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Generations_DeatiledInfoId",
                table: "Generations",
                column: "DeatiledInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Generations_ModelId",
                table: "Generations",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionalEquipments_GenerationId",
                table: "OptionalEquipments",
                column: "GenerationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyColourDetailedInfo");

            migrationBuilder.DropTable(
                name: "BodyTypeGeneration");

            migrationBuilder.DropTable(
                name: "BrakeDetailedInfo");

            migrationBuilder.DropTable(
                name: "DetailedInfoSuspension");

            migrationBuilder.DropTable(
                name: "DrivetrainGeneration");

            migrationBuilder.DropTable(
                name: "EngineGeneration");

            migrationBuilder.DropTable(
                name: "GearboxGeneration");

            migrationBuilder.DropTable(
                name: "OptionalEquipments");

            migrationBuilder.DropTable(
                name: "BodyColours");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "Brakes");

            migrationBuilder.DropTable(
                name: "Suspensions");

            migrationBuilder.DropTable(
                name: "Drivetrains");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "GearBoxes");

            migrationBuilder.DropTable(
                name: "Generations");

            migrationBuilder.DropTable(
                name: "DeatiledInfos");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
