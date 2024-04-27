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
        public async Task Delete(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException("User not found");
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserDetailsDTO>> GetAll()
        {
            var users = await _dbContext.Users
                //.Include(r=>r.Role)
                .ToListAsync() ?? throw new NotFoundException("Users not found");
            var userDTOs=_mapper.Map<List<UserDetailsDTO>>(users);
            return userDTOs;
        }

        public async Task<UserDetailsDTO> GetById(int id)
        {
            var user = await _dbContext.Users
                //.Include(r => r.Role)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException("User not found");
            var userDTO = _mapper.Map<UserDetailsDTO>(user);
            return userDTO;
        }

        public async Task Update(int id, UpdateUserDetailsDTO dto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException("User not found");
            if(dto.Email!=null)
                user.Email = dto.Email;
            if (dto.NickName != null)
                user.NickName = dto.NickName;
            if (dto.RoleId != null)
                user.RoleId = (int)dto.RoleId;
            await _dbContext.SaveChangesAsync();
        }
    }
}
