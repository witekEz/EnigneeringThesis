using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities;
using UA.Model.Entities.Authentication;
using UA.Model.Entities.Rate;

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
        public DbSet<Gearbox> Gearboxes { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Brake> Brakes { get; set; }
        public DbSet<GenerationImage> GenerationImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<RateGeneration> RateGenerations { get; set; }
        public DbSet<RateGearbox> RateGearboxes { get; set; }
        public DbSet<RateEngine> RateEngines { get; set; }
        public DbSet<AvgRateGeneration> AvgRateGenerations { get; set; }
        public DbSet<AvgRateGearbox> AvgRateGearboxes { get; set; }
        public DbSet<AvgRateEngine> AvgRateEngines { get; set; }
        public DbSet<Comment> Comments { get; set; }  
        public DbSet<CommentReply> CommentReplies { get; set; }

        //Authentication
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


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
                .HasMaxLength(20);
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
            //Model
            modelBuilder.Entity<Generation>()
                .Property(p => p.Name)
                .HasMaxLength(10);
            //Suspension
            modelBuilder.Entity<Suspension>()
                .Property(p => p.Type)
                .HasMaxLength(40);
            //Category
            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasMaxLength(20);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
