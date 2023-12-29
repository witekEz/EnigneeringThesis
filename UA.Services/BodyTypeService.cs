﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class BodyTypeService : IBodyTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BodyTypeService(ApplicationDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BodyTypeDTO> GetAll()
        {
            var bodyTypes=_dbContext.BodyTypes.ToList();
            if(bodyTypes is null) {
                throw new NotFoundException("Body Types not found");
            }
            var bodyTypeDTOs=_mapper.Map<List<BodyTypeDTO>>(bodyTypes);
            return bodyTypeDTOs;
        }
    }
}
