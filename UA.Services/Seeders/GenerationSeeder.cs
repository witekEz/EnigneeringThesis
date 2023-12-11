using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.Entities;
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
                if(!_dbContext.Generations.Any())
                {
                    var modelGenerations = GetModelGenerations();
                    _dbContext.Generations.AddRange(modelGenerations);
                    _dbContext.SaveChanges();
                }
            }
        }
        public IEnumerable<Generation> GetModelGenerations()
        {
            BodyType bodyTypeCombi = new BodyType()
            {
                Name = "Combi",
                Segment = "D",
                NumberOfDoors = 5,
                NumberOfSeats = 5,
                TrunkCapacity = 1250,
            };
            BodyType bodyTypeSedan = new BodyType()
            {
                Name = "Sedan",
                Segment = "D",
                NumberOfDoors = 5,
                NumberOfSeats = 5,
            };
            List<Drivetrain> drivetrains = new List<Drivetrain>()
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
            List<Engine> engines = new List<Engine>()
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
                  },
            };
            List<Gearbox> gerboxes = new List<Gearbox>()
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
            List<Suspension> suspensions = new List<Suspension>()
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
            List<BodyColour> bodyColours = new List<BodyColour>
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
            List<Brake> brakes = new List<Brake>()
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
                },
            };
            Brand brand = new Brand()
            {
                Name = "AUDI"
            };
            Model.Entities.Model model = new Model.Entities.Model()
            {
                Brand = brand,
                Name="A4"
                
            };
            var generations = new List<Generation>()
            {
                new Generation()
                {
                    Category="Family",
                    Name = "B6",
                    BodyTypes = new List<BodyType>()
                    {
                        bodyTypeCombi,bodyTypeSedan
                    },
                    MinPrice=7000,
                    MaxPrice=30000,
                    Rate=5.0,
                    Drivetrains=new List<Drivetrain>()
                    {
                        drivetrains[0], drivetrains[1]
                    },
                    Engines=new List<Engine>()
                    {
                       engines[0], engines[1]
                    },
                    Gearboxes=new List<Gearbox>()
                    {
                        gerboxes[0] , gerboxes[1]
                    },
                    DeatiledInfo=new DetailedInfo()
                    {
                        Suspensions=new List<Suspension>()
                        {
                            suspensions[0] , suspensions[1]
                        },
                        ProductionStartDate=new DateTime(2001,01,01),
                        ProductionEndDate=new DateTime(2004,12,31),
                        BodyColours=bodyColours,
                        Brakes=brakes
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
                    Model=model
                },
                new Generation()
                {
                    Category="Family",
                    Name = "B7",
                    BodyTypes=new List<BodyType>()
                    {
                        bodyTypeCombi,bodyTypeSedan
                    },
                    MinPrice=10000,
                    MaxPrice=25000,
                    Drivetrains=new List<Drivetrain>()
                    {
                       drivetrains[0], drivetrains[1]
                    },
                    Engines=new List<Engine>()
                    {
                        engines[0], engines[2]
                    },
                    Gearboxes=new List<Gearbox>()
                    {
                        gerboxes[0],gerboxes[1]
                    },
                    DeatiledInfo=new DetailedInfo()
                    {
                        Suspensions=new List<Suspension>()
                        {
                            suspensions[0],suspensions[1]
                        },
                        ProductionStartDate=new DateTime(2004,01,01),
                        ProductionEndDate=new DateTime(2007,12,31),
                        BodyColours=bodyColours,
                        Brakes=brakes
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
                    Model=model
                }
            };
            return generations;
        }
    }
}
