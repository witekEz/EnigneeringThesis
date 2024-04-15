using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Model.Entities;
using UA.Model.Entities.Authentication;
using UA.Services.Interfaces;
using UA.Services.Middleware.Exceptions;

namespace UA.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException("User not found");
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<UserDetailsDTO> GetAll()
        {
            var users = _dbContext.Users.Include(r=>r.Role).ToList() ?? throw new NotFoundException("Users not found");
            var userDTOs=_mapper.Map<List<UserDetailsDTO>>(users);
            return userDTOs;
        }

        public UserDetailsDTO GetById(int id)
        {
            var user = _dbContext.Users.Include(r => r.Role).FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException("User not found");
            var userDTO = _mapper.Map<UserDetailsDTO>(user);
            return userDTO;
        }

        public void Update(int id, UpdateUserDetailsDTO dto)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException("User not found");
            if(dto.Email!=null)
                user.Email = dto.Email;
            if (dto.NickName != null)
                user.NickName = dto.NickName;
            if (dto.RoleId != null)
                user.RoleId = (int)dto.RoleId;
            _dbContext.SaveChanges();
        }
    }
}
