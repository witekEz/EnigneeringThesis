using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs;
using UA.Model.Entities;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;

namespace UA.Services.Mapper
{
    public class GenerationMappingProfile:Profile
    {
        public GenerationMappingProfile() 
        {
            //From Entity => DTO
            CreateMap<Generation,GenerationDTO>();
            CreateMap<BodyColour,BodyColourDTO>();
            CreateMap<BodyType,BodyTypeDTO>();
            CreateMap<Brake,BrakeDTO>();
            CreateMap<Brand,BrandDTO >();
            CreateMap<DetailedInfo,DetailedInfoDTO>();
            CreateMap<Drivetrain,DrivetrainDTO>();
            CreateMap<Engine,EngineDTO>();
            CreateMap<Gearbox,GearboxDTO>();
            CreateMap<Model.Entities.Model,ModelDTO >();
            CreateMap<OptionalEquipment,OptionalEquipmentDTO>();
            CreateMap<Suspension,SuspensionDTO>();

            //From CreateDTO => Entity
            CreateMap<CreateGenerationDTO, Generation>();
            CreateMap<CreateBodyColourDTO, BodyColour>();
            CreateMap<CreateBodyTypeDTO, BodyType>();
            CreateMap<CreateBrakeDTO, Brake>();
            CreateMap<CreateBrandDTO, Brand>();
            CreateMap<CreateDetailedInfoDTO, DetailedInfo>();
            CreateMap<CreateDrivetrainDTO, Drivetrain>();
            CreateMap<CreateEngineDTO, Engine>();
            CreateMap<CreateGearboxDTO, Gearbox>();
            CreateMap<CreateModelDTO, Model.Entities.Model >();
            CreateMap<CreateOptionalEquipmentDTO, OptionalEquipment>();
            CreateMap<CreateSuspensionDTO, Suspension>();
            CreateMap<CreateGenerationImageDTO, GenerationImage>();

            //From UpdateDTO => Entity
            CreateMap<UpdateGenerationDTO, Generation>();
            CreateMap<UpdateBodyColourDTO, BodyColour>();
            CreateMap<UpdateBodyTypeDTO, BodyType>();
            CreateMap<UpdateBrakeDTO, Brake>();
            CreateMap<UpdateBrandDTO, Brand>();
            CreateMap<UpdateDetailedInfoDTO, DetailedInfo>();
            CreateMap<UpdateDrivetrainDTO, Drivetrain>();
            CreateMap<UpdateEngineDTO, Engine>();
            CreateMap<UpdateGearboxDTO, Gearbox>();
            CreateMap<UpdateModelDTO, Model.Entities.Model>();
            CreateMap<UpdateOptionalEquipmentDTO, OptionalEquipment>();
            CreateMap<UpdateSuspensionDTO, Suspension>();


        }
    }
}
