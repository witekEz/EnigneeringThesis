﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UA.DAL.EF;

#nullable disable

namespace UA.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240322110516_Migration_1")]
    partial class Migration_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BodyColourDetailedInfo", b =>
                {
                    b.Property<int>("BodyColoursId")
                        .HasColumnType("int");

                    b.Property<int>("DetailedInfosId")
                        .HasColumnType("int");

                    b.HasKey("BodyColoursId", "DetailedInfosId");

                    b.HasIndex("DetailedInfosId");

                    b.ToTable("BodyColourDetailedInfo");
                });

            modelBuilder.Entity("BrakeDetailedInfo", b =>
                {
                    b.Property<int>("BrakesId")
                        .HasColumnType("int");

                    b.Property<int>("DetailedInfosId")
                        .HasColumnType("int");

                    b.HasKey("BrakesId", "DetailedInfosId");

                    b.HasIndex("DetailedInfosId");

                    b.ToTable("BrakeDetailedInfo");
                });

            modelBuilder.Entity("DetailedInfoSuspension", b =>
                {
                    b.Property<int>("DetailedInfosId")
                        .HasColumnType("int");

                    b.Property<int>("SuspensionsId")
                        .HasColumnType("int");

                    b.HasKey("DetailedInfosId", "SuspensionsId");

                    b.HasIndex("SuspensionsId");

                    b.ToTable("DetailedInfoSuspension");
                });

            modelBuilder.Entity("DrivetrainGeneration", b =>
                {
                    b.Property<int>("DrivetrainsId")
                        .HasColumnType("int");

                    b.Property<int>("GenerationsId")
                        .HasColumnType("int");

                    b.HasKey("DrivetrainsId", "GenerationsId");

                    b.HasIndex("GenerationsId");

                    b.ToTable("DrivetrainGeneration");
                });

            modelBuilder.Entity("EngineGeneration", b =>
                {
                    b.Property<int>("EnginesId")
                        .HasColumnType("int");

                    b.Property<int>("GenerationsId")
                        .HasColumnType("int");

                    b.HasKey("EnginesId", "GenerationsId");

                    b.HasIndex("GenerationsId");

                    b.ToTable("EngineGeneration");
                });

            modelBuilder.Entity("GearboxGeneration", b =>
                {
                    b.Property<int>("GearboxesId")
                        .HasColumnType("int");

                    b.Property<int>("GenerationsId")
                        .HasColumnType("int");

                    b.HasKey("GearboxesId", "GenerationsId");

                    b.HasIndex("GenerationsId");

                    b.ToTable("GearboxGeneration");
                });

            modelBuilder.Entity("UA.Model.Entities.Authentication.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("UA.Model.Entities.Authentication.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UA.Model.Entities.Body", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BodyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("GenerationId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDoors")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("Segment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrunkCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("GenerationId");

                    b.ToTable("Bodies");
                });

            modelBuilder.Entity("UA.Model.Entities.BodyColour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ColourCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("BodyColours");
                });

            modelBuilder.Entity("UA.Model.Entities.BodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("BodyTypes");
                });

            modelBuilder.Entity("UA.Model.Entities.Brake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Brakes");
                });

            modelBuilder.Entity("UA.Model.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("UA.Model.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("UA.Model.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenerationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsModified")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenerationId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("UA.Model.Entities.CommentReply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsModified")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentReplies");
                });

            modelBuilder.Entity("UA.Model.Entities.DetailedInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenerationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProductionStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GenerationId")
                        .IsUnique();

                    b.ToTable("DeatiledInfos");
                });

            modelBuilder.Entity("UA.Model.Entities.Drivetrain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Drivetrains");
                });

            modelBuilder.Entity("UA.Model.Entities.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<double>("FuelConsumptionCity")
                        .HasColumnType("float");

                    b.Property<double>("FuelConsumptionSuburban")
                        .HasColumnType("float");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<int>("Torque")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("UA.Model.Entities.Gearbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("NumberOfGears")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfGearbox")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gearboxes");
                });

            modelBuilder.Entity("UA.Model.Entities.Generation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<double>("MaxPrice")
                        .HasColumnType("float");

                    b.Property<double>("MinPrice")
                        .HasColumnType("float");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ModelId");

                    b.ToTable("Generations");
                });

            modelBuilder.Entity("UA.Model.Entities.GenerationImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenerationId")
                        .HasColumnType("int");

                    b.Property<Guid>("ImageGUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GenerationId");

                    b.ToTable("GenerationImages");
                });

            modelBuilder.Entity("UA.Model.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("UA.Model.Entities.OptionalEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ABS")
                        .HasColumnType("bit");

                    b.Property<bool>("ASR")
                        .HasColumnType("bit");

                    b.Property<bool>("ESP")
                        .HasColumnType("bit");

                    b.Property<int>("GenerationId")
                        .HasColumnType("int");

                    b.Property<bool>("RearAxleSteering")
                        .HasColumnType("bit");

                    b.Property<bool>("Rooftop")
                        .HasColumnType("bit");

                    b.Property<bool>("StandardTailPipes")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("GenerationId")
                        .IsUnique();

                    b.ToTable("OptionalEquipments");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.AvgRateEngine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageRate")
                        .HasColumnType("float");

                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRates")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EngineId")
                        .IsUnique();

                    b.ToTable("AvgRateEngines");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.AvgRateGearbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageRate")
                        .HasColumnType("float");

                    b.Property<int>("GearboxId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRates")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GearboxId")
                        .IsUnique();

                    b.ToTable("AvgRateGearboxes");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.AvgRateGeneration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageRate")
                        .HasColumnType("float");

                    b.Property<int>("GenerationId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRates")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenerationId")
                        .IsUnique();

                    b.ToTable("AvgRateGenerations");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.RateEngine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EngineId");

                    b.HasIndex("UserID");

                    b.ToTable("RateEngines");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.RateGearbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GearboxId")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GearboxId");

                    b.HasIndex("UserID");

                    b.ToTable("RateGearboxes");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.RateGeneration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenerationId")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GenerationId");

                    b.HasIndex("UserID");

                    b.ToTable("RateGenerations");
                });

            modelBuilder.Entity("UA.Model.Entities.Suspension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Suspensions");
                });

            modelBuilder.Entity("BodyColourDetailedInfo", b =>
                {
                    b.HasOne("UA.Model.Entities.BodyColour", null)
                        .WithMany()
                        .HasForeignKey("BodyColoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.DetailedInfo", null)
                        .WithMany()
                        .HasForeignKey("DetailedInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BrakeDetailedInfo", b =>
                {
                    b.HasOne("UA.Model.Entities.Brake", null)
                        .WithMany()
                        .HasForeignKey("BrakesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.DetailedInfo", null)
                        .WithMany()
                        .HasForeignKey("DetailedInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DetailedInfoSuspension", b =>
                {
                    b.HasOne("UA.Model.Entities.DetailedInfo", null)
                        .WithMany()
                        .HasForeignKey("DetailedInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Suspension", null)
                        .WithMany()
                        .HasForeignKey("SuspensionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DrivetrainGeneration", b =>
                {
                    b.HasOne("UA.Model.Entities.Drivetrain", null)
                        .WithMany()
                        .HasForeignKey("DrivetrainsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Generation", null)
                        .WithMany()
                        .HasForeignKey("GenerationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EngineGeneration", b =>
                {
                    b.HasOne("UA.Model.Entities.Engine", null)
                        .WithMany()
                        .HasForeignKey("EnginesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Generation", null)
                        .WithMany()
                        .HasForeignKey("GenerationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GearboxGeneration", b =>
                {
                    b.HasOne("UA.Model.Entities.Gearbox", null)
                        .WithMany()
                        .HasForeignKey("GearboxesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Generation", null)
                        .WithMany()
                        .HasForeignKey("GenerationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UA.Model.Entities.Authentication.User", b =>
                {
                    b.HasOne("UA.Model.Entities.Authentication.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UA.Model.Entities.Body", b =>
                {
                    b.HasOne("UA.Model.Entities.BodyType", "BodyType")
                        .WithMany("Bodies")
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Generation", "Generation")
                        .WithMany("Bodies")
                        .HasForeignKey("GenerationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyType");

                    b.Navigation("Generation");
                });

            modelBuilder.Entity("UA.Model.Entities.Comment", b =>
                {
                    b.HasOne("UA.Model.Entities.Authentication.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Generation", "Generation")
                        .WithMany("Comments")
                        .HasForeignKey("GenerationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Generation");
                });

            modelBuilder.Entity("UA.Model.Entities.CommentReply", b =>
                {
                    b.HasOne("UA.Model.Entities.Authentication.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("UA.Model.Entities.Comment", "Comment")
                        .WithMany("Replies")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("UA.Model.Entities.DetailedInfo", b =>
                {
                    b.HasOne("UA.Model.Entities.Generation", "Generation")
                        .WithOne("DetailedInfo")
                        .HasForeignKey("UA.Model.Entities.DetailedInfo", "GenerationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generation");
                });

            modelBuilder.Entity("UA.Model.Entities.Generation", b =>
                {
                    b.HasOne("UA.Model.Entities.Category", "Category")
                        .WithMany("Generations")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Model", "Model")
                        .WithMany("Generations")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("UA.Model.Entities.GenerationImage", b =>
                {
                    b.HasOne("UA.Model.Entities.Generation", "Generation")
                        .WithMany("GenerationImages")
                        .HasForeignKey("GenerationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generation");
                });

            modelBuilder.Entity("UA.Model.Entities.Model", b =>
                {
                    b.HasOne("UA.Model.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("UA.Model.Entities.OptionalEquipment", b =>
                {
                    b.HasOne("UA.Model.Entities.Generation", "Generation")
                        .WithOne("OptionalEquipment")
                        .HasForeignKey("UA.Model.Entities.OptionalEquipment", "GenerationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generation");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.AvgRateEngine", b =>
                {
                    b.HasOne("UA.Model.Entities.Engine", "Engine")
                        .WithOne("AvgRateEngine")
                        .HasForeignKey("UA.Model.Entities.Rate.AvgRateEngine", "EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engine");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.AvgRateGearbox", b =>
                {
                    b.HasOne("UA.Model.Entities.Gearbox", "Gearbox")
                        .WithOne("AvgRateGearbox")
                        .HasForeignKey("UA.Model.Entities.Rate.AvgRateGearbox", "GearboxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gearbox");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.AvgRateGeneration", b =>
                {
                    b.HasOne("UA.Model.Entities.Generation", "Generation")
                        .WithOne("AvgRateGeneration")
                        .HasForeignKey("UA.Model.Entities.Rate.AvgRateGeneration", "GenerationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generation");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.RateEngine", b =>
                {
                    b.HasOne("UA.Model.Entities.Engine", "Engine")
                        .WithMany("Rates")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Authentication.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engine");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.RateGearbox", b =>
                {
                    b.HasOne("UA.Model.Entities.Gearbox", "Gearbox")
                        .WithMany("Rates")
                        .HasForeignKey("GearboxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Authentication.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gearbox");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UA.Model.Entities.Rate.RateGeneration", b =>
                {
                    b.HasOne("UA.Model.Entities.Generation", "Generation")
                        .WithMany("Rates")
                        .HasForeignKey("GenerationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Authentication.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UA.Model.Entities.BodyType", b =>
                {
                    b.Navigation("Bodies");
                });

            modelBuilder.Entity("UA.Model.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("UA.Model.Entities.Category", b =>
                {
                    b.Navigation("Generations");
                });

            modelBuilder.Entity("UA.Model.Entities.Comment", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("UA.Model.Entities.Engine", b =>
                {
                    b.Navigation("AvgRateEngine");

                    b.Navigation("Rates");
                });

            modelBuilder.Entity("UA.Model.Entities.Gearbox", b =>
                {
                    b.Navigation("AvgRateGearbox");

                    b.Navigation("Rates");
                });

            modelBuilder.Entity("UA.Model.Entities.Generation", b =>
                {
                    b.Navigation("AvgRateGeneration");

                    b.Navigation("Bodies");

                    b.Navigation("Comments");

                    b.Navigation("DetailedInfo");

                    b.Navigation("GenerationImages");

                    b.Navigation("OptionalEquipment");

                    b.Navigation("Rates");
                });

            modelBuilder.Entity("UA.Model.Entities.Model", b =>
                {
                    b.Navigation("Generations");
                });
#pragma warning restore 612, 618
        }
    }
}