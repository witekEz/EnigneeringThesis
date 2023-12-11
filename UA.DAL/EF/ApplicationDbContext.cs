using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities;

namespace UA.DAL.EF
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model.Entities.Model> Models { get; set; }
        public DbSet<Generation> Generations { get; set; }
        public DbSet<Drivetrain> Drivetrains { get; set; }
        public DbSet<DetailedInfo> DeatiledInfos { get; set; }
        public DbSet<BodyColour> BodyColours { get; set; }
        public DbSet<Suspension> Suspensions { get; set; }
        public DbSet<OptionalEquipment> OptionalEquipments { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Gearbox> GearBoxes { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Brake> Brakes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //BodyColour
            modelBuilder.Entity<BodyColour>()
                .Property(p => p.Colour)
                .HasMaxLength(50);
            modelBuilder.Entity<BodyColour>()
               .Property(p => p.ColourCode)
               .HasMaxLength(10);
            //BodyType
            modelBuilder.Entity<BodyType>()
                .Property(p=>p.Name) 
                .HasMaxLength(30);
            //Brake
            modelBuilder.Entity<Brake>()
                .Property(p => p.Type)
                .HasMaxLength(25);
            //Brand
            modelBuilder.Entity<Brand>()
                .Property(p => p.Name)
                .HasMaxLength(20);
            //Drivetrain
            modelBuilder.Entity<Drivetrain>()
                .Property(p => p.Type)
                .HasMaxLength(40);
            //Engine
            modelBuilder.Entity<Engine>()
                .Property(p => p.Version)
                .HasMaxLength(40);
            //Gearbox
            modelBuilder.Entity<Gearbox>()
                .Property(p => p.Name)
                .HasMaxLength(20);
            //Generation
            modelBuilder.Entity<Generation>()
                .Property(p => p.Name)
                .HasMaxLength(10);
            modelBuilder.Entity<Generation>()
                .Property(p => p.Category)
                .HasMaxLength(20);
            //Model
            modelBuilder.Entity<Generation>()
                .Property(p => p.Name)
                .HasMaxLength(10);
            //Suspension
            modelBuilder.Entity<Suspension>()
                .Property(p => p.Type)
                .HasMaxLength(40);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
