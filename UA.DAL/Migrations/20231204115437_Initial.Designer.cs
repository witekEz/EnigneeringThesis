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
    [Migration("20231204115437_Initial")]
    partial class Initial
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

                    b.Property<int>("DeatiledInfosId")
                        .HasColumnType("int");

                    b.HasKey("BodyColoursId", "DeatiledInfosId");

                    b.HasIndex("DeatiledInfosId");

                    b.ToTable("BodyColourDetailedInfo");
                });

            modelBuilder.Entity("BodyTypeGeneration", b =>
                {
                    b.Property<int>("BodyTypesId")
                        .HasColumnType("int");

                    b.Property<int>("GenerationsId")
                        .HasColumnType("int");

                    b.HasKey("BodyTypesId", "GenerationsId");

                    b.HasIndex("GenerationsId");

                    b.ToTable("BodyTypeGeneration");
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

            modelBuilder.Entity("UA.Model.Entities.BodyColour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColourCode")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDoors")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("Segment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrunkCapacity")
                        .HasColumnType("int");

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
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("UA.Model.Entities.DetailedInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ProductionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProductionStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

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
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Torque")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfGears")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("TypeOfGearbox")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GearBoxes");
                });

            modelBuilder.Entity("UA.Model.Entities.Generation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeatiledInfoId")
                        .HasColumnType("int");

                    b.Property<double>("MaxPrice")
                        .HasColumnType("float");

                    b.Property<double>("MinPrice")
                        .HasColumnType("float");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DeatiledInfoId");

                    b.HasIndex("ModelId");

                    b.ToTable("Generations");
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

            modelBuilder.Entity("UA.Model.Entities.Suspension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasForeignKey("DeatiledInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BodyTypeGeneration", b =>
                {
                    b.HasOne("UA.Model.Entities.BodyType", null)
                        .WithMany()
                        .HasForeignKey("BodyTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Generation", null)
                        .WithMany()
                        .HasForeignKey("GenerationsId")
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

            modelBuilder.Entity("UA.Model.Entities.Generation", b =>
                {
                    b.HasOne("UA.Model.Entities.DetailedInfo", "DeatiledInfo")
                        .WithMany()
                        .HasForeignKey("DeatiledInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UA.Model.Entities.Model", "Model")
                        .WithMany("Generations")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeatiledInfo");

                    b.Navigation("Model");
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

            modelBuilder.Entity("UA.Model.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("UA.Model.Entities.Generation", b =>
                {
                    b.Navigation("OptionalEquipment");
                });

            modelBuilder.Entity("UA.Model.Entities.Model", b =>
                {
                    b.Navigation("Generations");
                });
#pragma warning restore 612, 618
        }
    }
}
