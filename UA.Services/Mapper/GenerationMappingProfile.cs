using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Model.DTOs.Read;
using UA.Model.Entities.Rate;
using UA.Model.DTOs.Create.Rate;
using UA.Model.DTOs.Read.Rate;
using UA.Model.Entities.Authentication;
using SixLabors.ImageSharp.ColorSpaces.Companding;

namespace UA.Services.Mapper
{
    public class GenerationMappingProfile:Profile
    {
        public GenerationMappingProfile() 
        {
            //From Entity => DTO
            CreateMap<Generation,GenerationDTO>()
                .ForMember(des=>des.Rate,opt=>opt.MapFrom(src=>src.AvgRateGeneration));
            CreateMap<BodyColour,BodyColourDTO>();
            CreateMap<Body,BodyDTO>();
            CreateMap<BodyType, BodyTypeDTO>();
            CreateMap<Brake,BrakeDTO>();
            CreateMap<Brand,BrandDTO >();
            CreateMap<DetailedInfo,DetailedInfoDTO>();
            CreateMap<Drivetrain,DrivetrainDTO>();
            CreateMap<Engine,EngineDTO>()
                .ForMember(des => des.Rate, opt => opt.MapFrom(src => src.AvgRateEngine));
            CreateMap<Gearbox,GearboxDTO>()
                .ForMember(des => des.Rate, opt => opt.MapFrom(src => src.AvgRateGearbox));
            CreateMap<Model.Entities.Model,ModelDTO >();
            CreateMap<OptionalEquipment,OptionalEquipmentDTO>();
            CreateMap<Suspension,SuspensionDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentReply, CommentReplyDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<User, UserDetailsDTO>();
            CreateMap<Role, RoleDTO>();

            CreateMap<AvgRateGeneration, AvgRateGenerationDTO>()
                .ForMember(des => des.Value, opt => opt.MapFrom(src => src.AverageRate));
            CreateMap<AvgRateEngine, AvgRateEngineDTO>()
                .ForMember(des => des.Value, opt => opt.MapFrom(src => src.AverageRate));
            CreateMap<AvgRateGearbox, AvgRateGearboxDTO>()
                .ForMember(des => des.Value, opt => opt.MapFrom(src => src.AverageRate));

            //From CreateDTO => Entity
            CreateMap<CreateGenerationDTO, Generation>()
                .ForMember(m => m.Drivetrains, c => c.Ignore())
                .ForMember(m => m.Engines, c => c.Ignore())
                .ForMember(m => m.Bodies, c => c.Ignore())
                .ForMember(m => m.Gearboxes, c => c.Ignore())
                .ForMember(m => m.Bodies, c => c.Ignore())
            .ForMember(dest => dest.Bodies, opt => opt.MapFrom(src => new List<CreateBodyDTO> { src.Body } ));

            CreateMap<CreateBodyColourDTO, BodyColour>();
            CreateMap<CreateBodyDTO, Body>();
                //.ForMember(m => m.BodyTypeId, opt => opt.MapFrom(src => src.BodyType));
            CreateMap<CreateBodyTypeDTO, BodyType>();
            CreateMap<CreateBrakeDTO, Brake>();
            CreateMap<CreateBrandDTO, Brand>();
            CreateMap<CreateDetailedInfoDTO, DetailedInfo>()
                .ForMember(m => m.BodyColours, c => c.Ignore())
                .ForMember(m => m.Brakes, c => c.Ignore())
                .ForMember(m => m.Suspensions, c => c.Ignore());
            CreateMap<CreateDrivetrainDTO, Drivetrain>();
            CreateMap<CreateEngineDTO, Engine>();
            CreateMap<CreateGearboxDTO, Gearbox>();
            CreateMap<CreateModelDTO, Model.Entities.Model >();
            CreateMap<CreateOptionalEquipmentDTO, OptionalEquipment>();
            CreateMap<CreateSuspensionDTO, Suspension>();
            CreateMap<CreateGenerationImageDTO, GenerationImage>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CreateCommentDTO, Comment>();
            CreateMap<CreateCommentReplyDTO, CommentReply>();

            CreateMap<CreateAvgRateGenerationDTO, AvgRateGeneration>()
                .ForMember(des => des.AverageRate, opt => opt.MapFrom(src => src.Value));

            CreateMap<CreateAvgRateEngineDTO, AvgRateEngine>()
                .ForMember(des => des.AverageRate, opt => opt.MapFrom(src => src.Value));

            CreateMap<CreateAvgRateGearboxDTO, AvgRateGearbox>()
                .ForMember(des => des.AverageRate, opt => opt.MapFrom(src => src.Value));
               

            CreateMap<CreateRateEngineDTO, RateEngine>();
            CreateMap<CreateRateGenerationDTO, RateGeneration>();
            CreateMap<CreateRateGearboxDTO, RateGearbox>();


            //From UpdateDTO => Entity
            CreateMap<UpdateGenerationDTO, Generation>();
            CreateMap<UpdateBodyColourDTO, BodyColour>();
            CreateMap<UpdateBodyDTO, Body>();
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
            CreateMap<UpdateCategoryDTO, Category>();
           


        }
    }
}
