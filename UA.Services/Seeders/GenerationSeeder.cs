using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.Entities;
using UA.Model.Entities.Authentication;
using UA.Model.Entities.Enums;

namespace UA.Services.Seeders
{
    public class GenerationSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public GenerationSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed() 
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                //if(!_dbContext.BodyTypes.Any())
                //{
                //    var bodyTypes=GetBodyTypes();
                //    _dbContext.BodyTypes.AddRange(bodyTypes);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.Drivetrains.Any())
                //{
                //    var drivetrains = GetDrivetrains();
                //    _dbContext.Drivetrains.AddRange(drivetrains);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.Engines.Any())
                //{
                //    var engines = GetEngines();
                //    _dbContext.Engines.AddRange(engines);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.GearBoxes.Any())
                //{
                //    var gearboxes = GetGearboxes();
                //    _dbContext.GearBoxes.AddRange(gearboxes);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.Suspensions.Any())
                //{
                //    var suspensions = GetSuspensions();
                //    _dbContext.Suspensions.AddRange(suspensions);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.BodyColours.Any())
                //{
                //    var bodyColours = GetBodyColours();
                //    _dbContext.BodyColours.AddRange(bodyColours);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.Brands.Any())
                //{
                //    var brands = GetBrands();
                //    _dbContext.Brands.AddRange(brands);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.Brakes.Any())
                //{
                //    var brakes = GetBrakes();
                //    _dbContext.Brakes.AddRange(brakes);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.Models.Any())
                //{
                //    var models = GetModels();
                //    _dbContext.Models.AddRange(models);
                //    _dbContext.SaveChanges();
                //}
                if (!_dbContext.Generations.Any())
                {
                    var modelGenerations = GetModelGenerations();
                    _dbContext.Generations.AddRange(modelGenerations);
                    _dbContext.SaveChanges();
                }

            }
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
            var roles = new List<BodyType>() 
            {
                new BodyType()
                {
                    Name = "Combi",
                    Segment = "D",
                    NumberOfDoors = 5,
                    NumberOfSeats = 5,
                    TrunkCapacity = 1250,
                },
                new BodyType()
                {
                    Name = "Sedan",
                    Segment = "D",
                    NumberOfDoors = 5,
                    NumberOfSeats = 5,
                    TrunkCapacity = 700,
                },
                new BodyType()
                {
                    Name = "Combi",
                    Segment = "D",
                    NumberOfDoors = 5,
                    NumberOfSeats = 5,
                    TrunkCapacity = 1250,
                },
                new BodyType()
                {
                    Name = "Sedan",
                    Segment = "D",
                    NumberOfDoors = 5,
                    NumberOfSeats = 5,
                    TrunkCapacity = 700,
                }
            };
            return roles;
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
                     Version="TDI",
                     Capacity=2.5,
                     HorsePower=180,
                     Torque=400,
                     Type=TypeEnum.Diesel,
                     FuelConsumptionCity=9.5,
                     FuelConsumptionSuburban=6.5,
                     Rate=5
                 },
                 new Engine()
                 {
                     Version="TDI",
                     Capacity=1.9,
                     HorsePower=130,
                     Torque=350,
                     Type=TypeEnum.Diesel,
                     FuelConsumptionCity=8.2,
                     FuelConsumptionSuburban=6.0,
                     Rate=5
                 },
                  new Engine()
                  {
                       Version="TFSI",
                       Capacity=2.0,
                       HorsePower=110,
                       Torque=300,
                       Type=TypeEnum.Petrol,
                       FuelConsumptionCity=10,
                       FuelConsumptionSuburban=8.0,
                       Rate=5
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
                    Type="four-shovel suspension"
                },
                new Suspension()
                {
                    Type="two-shovel suspension"
                }
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
                }    
            };
            return brands;
        }
        private IEnumerable<Model.Entities.Model> GetModels()
        {
            var models = new List<Model.Entities.Model>()
            {
                new Model.Entities.Model()
                {
                    Name="A4",
                    Brand=GetBrands().First()
                }
            };
            return models;
        }
        private IEnumerable<Generation> GetModelGenerations()
        {
            var bodyTypes = GetBodyTypes().ToList();
            //var bodytypes2 = GetBodyTypes().TakeLast(2).ToList();
            var drivetrains = GetDrivetrains().ToList();
            var engines = GetEngines().ToList();
            //var engines2 = GetEngines().Skip(1).ToList();
            var gearboxes = GetGearboxes().ToList();
            var suspensions = GetSuspensions().ToList();
            var bodyColours= GetBodyColours().ToList();
            var brakes = GetBrakes().ToList();
            var model = GetModels().ToList().First();
            var generations = new List<Generation>()
            {
                new Generation()
                {
                    Category="Family",
                    Name = "B6",
                    BodyTypes = bodyTypes.Take(2).ToList(),
                    MinPrice=7000,
                    MaxPrice=30000,
                    Rate=5.0,
                    Drivetrains=drivetrains,
                    Engines=engines.Take(2).ToList(),
                    Gearboxes=gearboxes,
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions.Skip(1).ToList(),                       
                        ProductionStartDate=new DateTime(2001,01,01),
                        ProductionEndDate=new DateTime(2004,12,31),
                        BodyColours=bodyColours,
                        Brakes=brakes,
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
                    Model=model,
                },
                new Generation()
                {
                    Category="Family",
                    Name = "B7",
                    BodyTypes = bodyTypes.TakeLast(2).ToList(),
                    MinPrice=10000,
                    MaxPrice=25000,
                    Rate=4.3,
                    Drivetrains=drivetrains,
                    Engines=engines.Skip(1).ToList(),
                    Gearboxes=gearboxes,
                    DetailedInfo=new DetailedInfo()
                    {
                        Suspensions=suspensions,
                        ProductionStartDate=new DateTime(2004,01,01),
                        ProductionEndDate=new DateTime(2007,12,31),
                        BodyColours=bodyColours,
                        Brakes=brakes,
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
                    Model=model,
                }
            };
            return generations;
        }
    }
}
