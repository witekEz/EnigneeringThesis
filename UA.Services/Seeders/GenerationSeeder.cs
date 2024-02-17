using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.Entities;
using UA.Model.Entities.Authentication;
using UA.Model.Entities.Enums;
using UA.Model.Entities.Rate;

namespace UA.Services.Seeders
{
    public class GenerationSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public GenerationSeeder(ApplicationDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public void Seed() 
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Users.Any())
                {
                    
                }
                if (!_dbContext.Generations.Any())
                {

                    var user = GetUser();
                    _dbContext.AddRange(user);

                    var bodyTypes=GetBodyTypes();
                    var bodies=GetBodies(bodyTypes);
                    var drivetrains=GetDrivetrains();
                    var engines =GetEngines();
                    var gearboxes=GetGearboxes();
                    var suspensions=GetSuspensions();
                    var bodyColours=GetBodyColours();
                    var brakes=GetBrakes();
                    var brands=GetBrands();
                    var models = GetModels(brands);
                    var categories=GetCategories();

                    var modelGenerations = GetModelGenerations(bodies, drivetrains, engines, gearboxes, suspensions, bodyColours, brakes, categories, models);

                    var rateGenerations = GetRateGenerations(modelGenerations, user);
                    var rateEngines = GetRateEngines(engines, user);
                    var rateGearboxes = GetRateGearboxes(gearboxes, user);

                    _dbContext.AddRange(bodyTypes);
                    _dbContext.AddRange(bodies);
                    _dbContext.AddRange(drivetrains);
                    _dbContext.AddRange(engines);
                    _dbContext.AddRange(gearboxes);
                    _dbContext.AddRange(suspensions);
                    _dbContext.AddRange(bodyColours);
                    _dbContext.AddRange(brakes);
                    _dbContext.AddRange(brands);
                    _dbContext.AddRange(models);
                    _dbContext.AddRange(categories);
                    _dbContext.AddRange(modelGenerations);

                    _dbContext.AddRange(rateGenerations);
                    _dbContext.AddRange(rateEngines);
                    _dbContext.AddRange(rateGearboxes);

                    _dbContext.SaveChanges();                   
                }

            }
        }
        private User GetUser()
        {
            var newUser = new User()
            {
                NickName = "witek",
                Email = "witek@witek.com",
                DateOfBirth = new DateTime(2001, 03, 12),
                RoleId = 3
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, "haslo123haslo123");
            newUser.PasswordHash = hashedPassword;
            return newUser;
        }
       
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User",
                },
                new Role()
                {
                    Name = "SuperUser",
                },
                new Role()
                {
                    Name = "Admin",
                }
            };
            return roles;
        }
        private IEnumerable<BodyType> GetBodyTypes()
        {
            var bodyTypes = new List<BodyType>()
            {
                new BodyType()
                {
                    Name="Kombi"
                },
                new BodyType()
                {
                    Name="Sedan"
                },
                new BodyType()
                {
                    Name="Limuzyna"
                },
                new BodyType()
                {
                    Name="Crossover"
                },
                new BodyType()
                {
                    Name="CoupeSUV"
                },
                new BodyType()
                {
                    Name="Terenowy"
                },
                new BodyType()
                {
                    Name="Pickup"
                },
                new BodyType()
                {
                    Name="VAN"
                },
                new BodyType()
                {
                    Name="Micro"
                },
                new BodyType()
                {
                    Name="Kabriolet"
                },
                new BodyType()
                {
                    Name="Muscle"
                },
                new BodyType()
                {
                    Name="Hyper"
                },
                new BodyType()
                {
                    Name="Copue"
                },
                new BodyType()
                {
                    Name="SUV"
                },
                new BodyType()
                {
                    Name="Hatchback"
                }

            };
            return bodyTypes;
        }
        private IEnumerable<Body> GetBodies(IEnumerable<BodyType> bodyTypes)
        {
            var bodies = new List<Body>() 
            {
                //b6
                new Body()
                {
                    BodyType=bodyTypes.First(),
                    Segment = "A",
                    NumberOfDoors = 5,
                    NumberOfSeats = 5,
                    TrunkCapacity = 1250,
                },
                new Body()
                {
                    BodyType =bodyTypes.Skip(1).First(),
                    Segment = "A",
                    NumberOfDoors = 5,
                    NumberOfSeats = 5,
                    TrunkCapacity = 700,
                },
                //b7
                new Body()
                {
                    BodyType = bodyTypes.Skip(1).First(),
                    Segment = "B",
                    NumberOfDoors = 5,
                    NumberOfSeats = 5,
                    TrunkCapacity = 500,
                },
                new Body()
                {
                    BodyType=bodyTypes.First(),
                    Segment = "B",
                    NumberOfDoors = 5,
                    NumberOfSeats = 5,
                    TrunkCapacity = 850,
                },
                //f10
                new Body()
                {
                    BodyType=bodyTypes.First(),
                    Segment = "C",
                    NumberOfDoors = 3,
                    NumberOfSeats = 5,
                    TrunkCapacity = 450,
                },
                new Body()
                {
                    BodyType = bodyTypes.Skip(1).First(),
                    Segment = "C",
                    NumberOfDoors = 3,
                    NumberOfSeats = 5,
                    TrunkCapacity = 500,
                },
                //f11
                new Body()
                {
                    BodyType=bodyTypes.First(),
                    Segment = "C",
                    NumberOfDoors = 3,
                    NumberOfSeats = 5,
                    TrunkCapacity = 450,
                },
                new Body()
                {
                    BodyType = bodyTypes.Skip(1).First(),
                    Segment = "C",
                    NumberOfDoors = 3,
                    NumberOfSeats = 5,
                    TrunkCapacity = 500,
                },
                //e39
                new Body()
                {
                    BodyType = bodyTypes.Skip(1).First(),
                    Segment = "D",
                    NumberOfDoors = 3,
                    NumberOfSeats = 5,
                    TrunkCapacity = 500,
                },
                //e34
                new Body()
                {
                    BodyType = bodyTypes.Skip(2).Last(),
                    Segment = "E",
                    NumberOfDoors = 3,
                    NumberOfSeats = 5,
                    TrunkCapacity = 500,
                },
                //IV
                new Body()
                {
                    BodyType = bodyTypes.Last(),
                    Segment = "F",
                    NumberOfDoors = 3,
                    NumberOfSeats = 5,
                    TrunkCapacity = 500,
                },
                //V
                new Body()
                {
                    BodyType = bodyTypes.Last(),
                    Segment = "G",
                    NumberOfDoors = 3,
                    NumberOfSeats = 5,
                    TrunkCapacity = 500,
                },
            };
            return bodies;
        }
        private IEnumerable<Drivetrain> GetDrivetrains()
        {
            var drivetrains = new List<Drivetrain>()
            {
                new Drivetrain()
                {
                     Type="FrontWheelDrive"
                },
                new Drivetrain()
                {
                     Type="AllWheelDrive"
                },
                new Drivetrain()
                {
                     Type="RearWheelDrive"
                }
            };
            return drivetrains;
        }
        private IEnumerable<Engine> GetEngines()
        {
            var engines = new List<Engine>()
            {
                  new Engine()
                  {
                     Version="2.5 TDI",
                     Capacity=2.5,
                     HorsePower=180,
                     Torque=400,
                     Type=TypeEnum.Diesel,
                     FuelConsumptionCity=9.5,
                     FuelConsumptionSuburban=6.5
                  },
                  new Engine()
                  {
                     Version="1.9 TDI",
                     Capacity=1.9,
                     HorsePower=130,
                     Torque=350,
                     Type=TypeEnum.Diesel,
                     FuelConsumptionCity=8.2,
                     FuelConsumptionSuburban=6.0
                  },
                  new Engine()
                  {
                     Version="2.0 FSI",
                     Capacity=2.0,
                     HorsePower=110,
                     Torque=300,
                     Type=TypeEnum.Petrol,
                     FuelConsumptionCity=10,
                     FuelConsumptionSuburban=8.0
                  },
                  new Engine()
                  {
                     Version="528i",
                     Capacity=2.8,
                     HorsePower=245,
                     Torque=350,
                     Type=TypeEnum.Petrol,
                     FuelConsumptionCity=12,
                     FuelConsumptionSuburban=7.0
                     
                  },
                  new Engine()
                  {
                     Version="530i",
                     Capacity=3.0,
                     HorsePower=272,
                     Torque=310,
                     Type=TypeEnum.Petrol,
                     FuelConsumptionCity=15,
                     FuelConsumptionSuburban=7.4
                  },
                  new Engine()
                  {
                     Version="1.6",
                     Capacity=1.6,
                     HorsePower=101,
                     Torque=145,
                     Type=TypeEnum.Petrol,
                     FuelConsumptionCity=8.2,
                     FuelConsumptionSuburban=8.0
                  },
                  new Engine()
                  {
                     Version="1.9 TDI PD 150",
                     Capacity=1.9,
                     HorsePower=150,
                     Torque=320,
                     Type=TypeEnum.Diesel,
                     FuelConsumptionCity=10.2,
                     FuelConsumptionSuburban=8.0
                  }
            };
            return engines;
        }
        private IEnumerable<Gearbox> GetGearboxes()
        {
            var gearboxes = new List<Gearbox>()
            {
               new Gearbox()
               {
                    Name="ZF",
                    NumberOfGears=5,
                    TypeOfGearbox=TypeOfGearboxEnum.Manual
               },
               new Gearbox()
               {
                    Name="ZF",
                    NumberOfGears=8,
                    TypeOfGearbox=TypeOfGearboxEnum.Autmatic
               },
               new Gearbox()
               {
                    Name="ZF",
                    NumberOfGears=6,
                    TypeOfGearbox=TypeOfGearboxEnum.Manual
               }
            };
            return gearboxes;
        }
        private IEnumerable<Suspension> GetSuspensions()
        {
            var suspensions = new List<Suspension>()
            {
                new Suspension()
                {
                    Type="Four-shovel suspension"
                },
                new Suspension()
                {
                    Type="Two-shovel suspension"
                },
                new Suspension()
                {
                    Type="Pneumatic"
                },
                new Suspension()
                {
                    Type="Multi-link"
                },
                new Suspension()
                {
                    Type="McPherson"
                },
                new Suspension()
                {
                    Type="Torsion beam"
                },
                new Suspension()
                {
                    Type="Torsion bar beam"
                },
                new Suspension()
                {
                    Type="Hydropneumatics"
                },
            };
            return suspensions;
        }
        private IEnumerable<BodyColour> GetBodyColours()
        {
            var bodycolours = new List<BodyColour>()
            {
                new BodyColour()
                {
                    Colour="ALPAKA BEIGE MET",
                    ColourCode="LY1W"
                },
                new BodyColour()
                {
                    Colour="BRILLIANT BLACK",
                    ColourCode="LY9B"
                },
                new BodyColour()
                {
                    Colour="EBONY BLACK PEARL",
                    ColourCode="LZ9W"
                },
                new BodyColour()
                {
                    Colour="VOLCANO BLACK PEARL MET",
                    ColourCode="LZ9U"
                },
                new BodyColour()
                {
                    Colour="BRILLIANT BLUE",
                    ColourCode="LY5K"
                },
                new BodyColour()
                {
                    Colour="CORN FLOWER BLUE",
                    ColourCode="LY5M"
                },
                new BodyColour()
                {
                    Colour="OCEAN BLUE PEARL EFFECT",
                    ColourCode="LZ5C"
                },
                new BodyColour()
                {
                    Colour="MING BLUE PEARL MET",
                    ColourCode="LZ5L"
                },
                new BodyColour()
                {
                    Colour="MORO BLUE PEARL EFFECT",
                    ColourCode="LZ5J"
                },
                new BodyColour()
                {
                    Colour="NOGARO BLUE PEARL",
                    ColourCode="LZ5M"
                },
                new BodyColour()
                {
                    Colour="SANTORIN BLUE PEAR",
                    ColourCode="LZ5K"
                },
                new BodyColour()
                {
                    Colour="SABLE BROWN PEARL",
                    ColourCode="LZ8P"
                },
                new BodyColour()
                {
                    Colour="AVOCADO PERLEFFEKT",
                    ColourCode="LZ6R"
                },
                new BodyColour()
                {
                    Colour="CACTUS GREEN PEARL",
                    ColourCode="LZ6L"
                },
                new BodyColour()
                {
                    Colour="LORBEER GREEN MET",
                    ColourCode="LY6R"
                },
                new BodyColour()
                {
                    Colour="PARADISE GREEN MET",
                    ColourCode="LY6K"
                },
                new BodyColour()
                {
                    Colour="ALUMINIUM SILVER MET",
                    ColourCode="LY7M"
                },
                new BodyColour()
                {
                    Colour="DAYTONA GRAY PEARL EFFECT",
                    ColourCode="LZ7S"
                },
                new BodyColour()
                {
                    Colour="DOLPHIN GREY PEARL",
                    ColourCode="LX7Z"
                },
                new BodyColour()
                {
                    Colour="MINERAL GRAY MET",
                    ColourCode="LY7K"
                },
                new BodyColour()
                {
                    Colour="BRILLIANT RED",
                    ColourCode="LY3J"
                },
                new BodyColour()
                {
                    Colour="HIBISCUS RED PEARL",
                    ColourCode="LZ3L"
                },
                new BodyColour()
                {
                    Colour="AUTUMN RED MET",
                    ColourCode="LY3Z"
                },
                new BodyColour()
                {
                    Colour="JAIPUR RED PEARL",
                    ColourCode="LZ3S"
                },
                new BodyColour()
                {
                    Colour="LASER RED",
                    ColourCode="LY3H"
                },
                new BodyColour()
                {
                    Colour="MERLOTROT PERLEFFEKT",
                    ColourCode="LZ3Q"
                },
                new BodyColour()
                {
                    Colour="MISANO RED PEARL EFFECT",
                    ColourCode="LZ3M"
                },
                new BodyColour()
                {
                    Colour="RUBIN RED PEARL",
                    ColourCode="LZ3N"
                },
                new BodyColour()
                {
                    Colour="AKOYA SILVER MET",
                    ColourCode="LY7H"
                },
                new BodyColour()
                {
                    Colour="AVUS SILVER PEARL EFFECT",
                    ColourCode="LY7J"
                },
                new BodyColour()
                {
                    Colour="LIGHT SILVER MET",
                    ColourCode="LY7W"
                },
                new BodyColour()
                {
                    Colour="CASABLANCA WHITE",
                    ColourCode="LY9G"
                },
                new BodyColour()
                {
                    Colour="POLARWEISS",
                    ColourCode="LY9H"
                },
                new BodyColour()
                {
                    Colour="IMOLA YELLOW",
                    ColourCode="LY1C"
                },
                new BodyColour()
                {
                    Colour="MAYA YELLOW MET",
                    ColourCode="LY1U"
                }
            };
            return bodycolours;
        }
        private IEnumerable<Brake> GetBrakes()
        {
            var brakes = new List<Brake>()
            {
               new Brake()
                {
                    Type="Ceramic"
                },
                new Brake()
                {
                    Type="Disc"
                },
                new Brake()
                {
                    Type="Drum"
                }
            };
            return brakes;
        }
        private IEnumerable<Brand> GetBrands()
        {
            var brands = new List<Brand>()
            {
                new Brand()
                {
                    Name = "AUDI",      
                },
                new Brand()
                {
                    Name = "BMW",
                },
                new Brand()
                {
                    Name = "Volkswagen",
                }
            };
            return brands;
        }
        private IEnumerable<Model.Entities.Model> GetModels(IEnumerable<Brand>brands)
        {
            var models = new List<Model.Entities.Model>()
            {
                new Model.Entities.Model()
                {
                    Name="A4",
                    Brand=brands.First()
                },
                new Model.Entities.Model()
                {
                    Name="5 SERIES",
                    Brand=brands.Skip(1).First()
                },
                new Model.Entities.Model()
                {
                    Name="GOLF",
                    Brand=brands.Last()
                }
            };
            return models;
        }
        private IEnumerable<Category>GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name="Rodzinny"
                },
                new Category()
                {
                    Name="Sportowy"
                },
                new Category()
                {
                    Name="Komfortowy"
                },
                new Category()
                {
                    Name="Ekonomiczny"
                },
                new Category()
                {
                    Name="Klasyk"
                }
            };
            return categories;
        }
        private IEnumerable<RateGeneration> GetRateGenerations(IEnumerable<Generation>generations,User user)
        {
            var rates = new List<RateGeneration>()
            {
                new RateGeneration()
                {
                    Value=5,
                    Generation=generations.First(),
                    User=user
                },
                new RateGeneration()
                {
                    Value=4.5,
                    Generation =generations.Skip(1).First(),
                    User=user
                },
                new RateGeneration()
                {
                    Value=5,
                    Generation =generations.Skip(2).First(),
                    User=user
                },
                new RateGeneration()
                {
                    Value=3,
                    Generation =generations.Skip(3).First(),
                    User=user,
                },
                new RateGeneration()
                {
                    Value=4.1,
                    Generation =generations.Skip(4).First(),
                    User=user
                },
                new RateGeneration()
                {
                    Value=2.2,
                    Generation =generations.Skip(5).First(),
                    User=user
                },
                new RateGeneration()
                {
                    Value=5.0,
                    Generation =generations.Skip(6).First(),
                    User=user
                }
            };
            return rates;
        }
        private IEnumerable<RateEngine> GetRateEngines(IEnumerable<Engine> engines, User user)
        {
            var rates = new List<RateEngine>()
            {
                new RateEngine()
                {
                    Value=5,
                    Engine=engines.First(),
                    User=user
                },
                new RateEngine()
                {
                    Value=4.5,
                    Engine=engines.Skip(1).First(),
                    User=user
                },
                new RateEngine()
                {
                    Value=5,
                    Engine=engines.Skip(2).First(),
                    User=user
                },
                new RateEngine()
                {
                    Value=3,
                    Engine=engines.Skip(3).First(),
                    User=user
                },
                new RateEngine()
                {
                    Value=4.1,
                    Engine=engines.Skip(4).First(),
                    User=user
                }          
            };
            return rates;
        }
        private IEnumerable<RateGearbox> GetRateGearboxes(IEnumerable<Gearbox> gearboxes, User user)
        {
            var rates = new List<RateGearbox>()
            {
                new RateGearbox()
                {
                    Value=5,
                    Gearbox=gearboxes.First(),
                    User=user
                },
                new RateGearbox()
                {
                    Value=4.5,
                    Gearbox=gearboxes.Skip(1).First(),
                    User=user
                },
                new RateGearbox()
                {
                    Value=5,
                    Gearbox=gearboxes.Last(),
                    User=user
                },
                new RateGearbox()
                {
                    Value=3,
                    Gearbox=gearboxes.First(),
                    User = user
                },
                new RateGearbox()
                {
                    Value=4.1,
                    Gearbox=gearboxes.Skip(1).First(),
                    User = user
                },
                new RateGearbox()
                {
                    Value=2.2,
                    Gearbox=gearboxes.Last(),
                    User = user
                } 
            };
            return rates;
        }
        private IEnumerable<Generation> GetModelGenerations( IEnumerable<Body>bodies,
             IEnumerable<Drivetrain> drivetrains,
             IEnumerable<Engine> engines, 
             IEnumerable<Gearbox> gearboxes,
             IEnumerable<Suspension> suspensions,
             IEnumerable<BodyColour> bodyColours,
             IEnumerable<Brake> brakes,
             IEnumerable<Category> categories,
             IEnumerable<Model.Entities.Model> models)

        {
            var modelAudi = models.ToList().First();
            var modelBMW = models.ToList().Skip(1).First();
            var modelVW = models.ToList().Last();
            var generations = new List<Generation>()
            {
                new Generation()
                {
                    Category=categories.First(),
                    Name = "B6",
                    Bodies = bodies.Take(2).ToList(),
                    MinPrice=7000,
                    MaxPrice=30000,
                    Drivetrains=drivetrains.ToList(),
                    Engines=engines.Take(2).ToList(),
                    Gearboxes=gearboxes.ToList(),
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions.Skip(1).ToList(),
                        ProductionStartDate=new DateTime(2001,01,01),
                        ProductionEndDate=new DateTime(2004,12,31),
                        BodyColours=bodyColours.ToList(),
                        Brakes=brakes.ToList(),
                    },
                    OptionalEquipment=new OptionalEquipment()
                    {
                        RearAxleSteering=true,
                        StandardTailPipes=false,
                        Rooftop=true,
                        ABS=true,
                        ESP=true,
                        ASR=true
                    },
                    Model=modelAudi,
                },
                new Generation()
                {
                    Category=categories.First(),
                    Name = "B7",
                    Bodies = bodies.Skip(2).Take(2).ToList(),
                    MinPrice=10000,
                    MaxPrice=25000,
                    Drivetrains=drivetrains.ToList(),
                    Engines=engines.Skip(1).ToList(),
                    Gearboxes=gearboxes.ToList(),
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions.ToList(),
                        ProductionStartDate=new DateTime(2004,01,01),
                        ProductionEndDate=new DateTime(2007,12,31),
                        BodyColours=bodyColours.ToList(),
                        Brakes=brakes.ToList(),
                    },
                    OptionalEquipment=new OptionalEquipment()
                    {
                        RearAxleSteering=true,
                        StandardTailPipes=false,
                        Rooftop=true,
                        ABS=true,
                        ESP=true,
                        ASR=true
                    },
                    Model=modelAudi,
                },
                new Generation()
                {
                    Category=categories.Skip(2).First(),
                    Name = "F10",
                    Bodies = bodies.Skip(4).Take(2).ToList(),
                    MinPrice=50000,
                    MaxPrice=95000,
                    Drivetrains=drivetrains.ToList(),
                    Engines=engines.Skip(3).SkipLast(2).ToList(),
                    Gearboxes=gearboxes.TakeLast(2).ToList(),
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions.TakeLast(6).ToList(),
                        ProductionStartDate=new DateTime(2007,01,01),
                        ProductionEndDate=new DateTime(2012,12,31),
                        BodyColours=bodyColours.ToList(),
                        Brakes=brakes.ToList(),
                    },
                    OptionalEquipment=new OptionalEquipment()
                    {
                        RearAxleSteering=true,
                        StandardTailPipes=false,
                        Rooftop=true,
                        ABS=true,
                        ESP=true,
                        ASR=false
                    },
                    Model=modelBMW,
                },
                new Generation()
                {
                    Category=categories.Skip(2).First(),
                    Name = "F11",
                    Bodies = bodies.Skip(6).Take(2).ToList(),
                    MinPrice=50000,
                    MaxPrice=95000,
                    Drivetrains=drivetrains.ToList(),
                    Engines=engines.Skip(3).SkipLast(2).ToList(),
                    Gearboxes=gearboxes.TakeLast(2).ToList(),
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions.TakeLast(6).ToList(),
                        ProductionStartDate=new DateTime(2007,01,01),
                        ProductionEndDate=new DateTime(2012,12,31),
                        BodyColours=bodyColours.ToList(),
                        Brakes=brakes.ToList(),
                    },
                    OptionalEquipment=new OptionalEquipment()
                    {
                        RearAxleSteering=true,
                        StandardTailPipes=false,
                        Rooftop=true,
                        ABS=true,
                        ESP=false,
                        ASR=true
                    },
                    Model=modelBMW,
                },
                new Generation()
                {
                    Category=categories.Last(),
                    Name = "E39",
                    Bodies = bodies.Skip(8).Take(1).ToList(),
                    MinPrice=50000,
                    MaxPrice=95000,
                    Drivetrains=drivetrains.ToList(),
                    Engines=engines.Skip(3).SkipLast(2).ToList(),
                    Gearboxes=gearboxes.TakeLast(2).ToList(),
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions.TakeLast(6).ToList(),
                        ProductionStartDate=new DateTime(2007,01,01),
                        ProductionEndDate=new DateTime(2012,12,31),
                        BodyColours=bodyColours.ToList(),
                        Brakes=brakes.ToList(),
                    },
                    OptionalEquipment=new OptionalEquipment()
                    {
                        RearAxleSteering=true,
                        StandardTailPipes=false,
                        Rooftop=true,
                        ABS=true,
                        ESP=false,
                        ASR=true
                    },
                    Model=modelBMW,
                },
                new Generation()
                {
                    Category=categories.Last(),
                    Name = "E34",
                    Bodies = bodies.Skip(9).Take(1).ToList(),
                    MinPrice=50000,
                    MaxPrice=95000,
                    Drivetrains=drivetrains.ToList(),
                    Engines=engines.Skip(3).SkipLast(2).ToList(),
                    Gearboxes=gearboxes.TakeLast(2).ToList(),
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions.TakeLast(6).ToList(),
                        ProductionStartDate=new DateTime(2007,01,01),
                        ProductionEndDate=new DateTime(2012,12,31),
                        BodyColours=bodyColours.ToList(),
                        Brakes=brakes.ToList(),
                    },
                    OptionalEquipment=new OptionalEquipment()
                    {
                        RearAxleSteering=true,
                        StandardTailPipes=false,
                        Rooftop=true,
                        ABS=true,
                        ESP=false,
                        ASR=true
                    },
                    Model=modelBMW,
                },
                new Generation()
                {
                    Category=categories.SkipLast(1).Last(),
                    Name = "IV",
                    Bodies = bodies.Skip(10).Take(1).ToList(),
                    MinPrice=35000,
                    MaxPrice=50000,
                    Drivetrains=drivetrains.Take(4).ToList(),
                    Engines=engines.TakeLast(2).ToList(),
                    Gearboxes=gearboxes.Take(2).ToList(),
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions.Take(6).ToList(),
                        ProductionStartDate=new DateTime(2004,01,01),
                        ProductionEndDate=new DateTime(2008,12,31),
                        BodyColours=bodyColours.ToList(),
                        Brakes=brakes.ToList(),
                    },
                    OptionalEquipment=new OptionalEquipment()
                    {
                        RearAxleSteering=true,
                        StandardTailPipes=true,
                        Rooftop=true,
                        ABS=true,
                        ESP=true,
                        ASR=true
                    },
                    Model=modelVW,
                },
                new Generation()
                {
                    Category=categories.SkipLast(1).Last(),
                    Name = "V",
                    Bodies = bodies.TakeLast(1).ToList(),
                    MinPrice=45000,
                    MaxPrice=65000,
                    Drivetrains=drivetrains.Take(4).ToList(),
                    Engines=engines.TakeLast(2).ToList(),
                    Gearboxes=gearboxes.Take(2).ToList(),
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions.Take(6).ToList(),
                        ProductionStartDate=new DateTime(2008,01,01),
                        ProductionEndDate=new DateTime(2012,12,31),
                        BodyColours=bodyColours.ToList(),
                        Brakes=brakes.ToList(),
                    },
                    OptionalEquipment=new OptionalEquipment()
                    {
                        RearAxleSteering=true,
                        StandardTailPipes=true,
                        Rooftop=true,
                        ABS=true,
                        ESP=true,
                        ASR=true
                    },
                    Model=modelVW,
                }
            };
            return generations;
        }
    }
}
