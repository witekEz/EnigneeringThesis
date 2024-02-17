using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    Colour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColourCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivetrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
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
                    Version = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    Torque = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FuelConsumptionCity = table.Column<double>(type: "float", nullable: false),
                    FuelConsumptionSuburban = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gearboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumberOfGears = table.Column<int>(type: "int", nullable: false),
                    TypeOfGearbox = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gearboxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suspensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
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
                name: "AvgRateEngines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRate = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvgRateEngines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvgRateEngines_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvgRateGearboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRate = table.Column<int>(type: "int", nullable: false),
                    GearboxId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvgRateGearboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvgRateGearboxes_Gearboxes_GearboxId",
                        column: x => x.GearboxId,
                        principalTable: "Gearboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Generations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MinPrice = table.Column<double>(type: "float", nullable: false),
                    MaxPrice = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
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
                name: "RateEngines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateEngines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateEngines_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RateEngines_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RateGearboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    GearboxId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateGearboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateGearboxes_Gearboxes_GearboxId",
                        column: x => x.GearboxId,
                        principalTable: "Gearboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RateGearboxes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvgRateGenerations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRate = table.Column<int>(type: "int", nullable: false),
                    GenerationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvgRateGenerations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvgRateGenerations_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bodies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Segment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    TrunkCapacity = table.Column<int>(type: "int", nullable: false),
                    GenerationId = table.Column<int>(type: "int", nullable: false),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bodies_BodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bodies_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeatiledInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenerationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeatiledInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeatiledInfos_Generations_GenerationId",
                        column: x => x.GenerationId,
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
                        name: "FK_GearboxGeneration_Gearboxes_GearboxesId",
                        column: x => x.GearboxesId,
                        principalTable: "Gearboxes",
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
                name: "GenerationImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenerationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenerationImages_Generations_GenerationId",
                        column: x => x.GenerationId,
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

            migrationBuilder.CreateTable(
                name: "RateGenerations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    GenerationId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateGenerations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateGenerations_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RateGenerations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyColourDetailedInfo",
                columns: table => new
                {
                    BodyColoursId = table.Column<int>(type: "int", nullable: false),
                    DetailedInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyColourDetailedInfo", x => new { x.BodyColoursId, x.DetailedInfosId });
                    table.ForeignKey(
                        name: "FK_BodyColourDetailedInfo_BodyColours_BodyColoursId",
                        column: x => x.BodyColoursId,
                        principalTable: "BodyColours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BodyColourDetailedInfo_DeatiledInfos_DetailedInfosId",
                        column: x => x.DetailedInfosId,
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

            migrationBuilder.CreateIndex(
                name: "IX_AvgRateEngines_EngineId",
                table: "AvgRateEngines",
                column: "EngineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvgRateGearboxes_GearboxId",
                table: "AvgRateGearboxes",
                column: "GearboxId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvgRateGenerations_GenerationId",
                table: "AvgRateGenerations",
                column: "GenerationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bodies_BodyTypeId",
                table: "Bodies",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodies_GenerationId",
                table: "Bodies",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyColourDetailedInfo_DetailedInfosId",
                table: "BodyColourDetailedInfo",
                column: "DetailedInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_BrakeDetailedInfo_DetailedInfosId",
                table: "BrakeDetailedInfo",
                column: "DetailedInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_DeatiledInfos_GenerationId",
                table: "DeatiledInfos",
                column: "GenerationId",
                unique: true);

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
                name: "IX_GenerationImages_GenerationId",
                table: "GenerationImages",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_Generations_CategoryId",
                table: "Generations",
                column: "CategoryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_RateEngines_EngineId",
                table: "RateEngines",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_RateEngines_UserID",
                table: "RateEngines",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RateGearboxes_GearboxId",
                table: "RateGearboxes",
                column: "GearboxId");

            migrationBuilder.CreateIndex(
                name: "IX_RateGearboxes_UserID",
                table: "RateGearboxes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RateGenerations_GenerationId",
                table: "RateGenerations",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_RateGenerations_UserID",
                table: "RateGenerations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvgRateEngines");

            migrationBuilder.DropTable(
                name: "AvgRateGearboxes");

            migrationBuilder.DropTable(
                name: "AvgRateGenerations");

            migrationBuilder.DropTable(
                name: "Bodies");

            migrationBuilder.DropTable(
                name: "BodyColourDetailedInfo");

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
                name: "GenerationImages");

            migrationBuilder.DropTable(
                name: "OptionalEquipments");

            migrationBuilder.DropTable(
                name: "RateEngines");

            migrationBuilder.DropTable(
                name: "RateGearboxes");

            migrationBuilder.DropTable(
                name: "RateGenerations");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "BodyColours");

            migrationBuilder.DropTable(
                name: "Brakes");

            migrationBuilder.DropTable(
                name: "DeatiledInfos");

            migrationBuilder.DropTable(
                name: "Suspensions");

            migrationBuilder.DropTable(
                name: "Drivetrains");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Gearboxes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Generations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
