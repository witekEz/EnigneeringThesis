using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.Entities.Authentication;
using UA.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using UA.Services.Middleware.Exceptions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UA.WebAPI;
using System.IdentityModel.Tokens.Jwt;
using UA.Model.DTOs.Read;

namespace UA.Services
{
    public class AccountService:IAccountService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public AccountService(ApplicationDbContext dbContext, 
            IPasswordHasher<User> passwordHasher, 
            AuthenticationSettings authenticationSettings) {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<string> GenerateJwt(LoginDTO dto)
        {
            var user = await _dbContext.Users
                .Include(r=>r.Role)
                .FirstOrDefaultAsync(u=>u.Email == dto.Email) ?? throw new BadRequestException("Invalid email or password");
            var result =_passwordHasher.VerifyHashedPassword(user,user.PasswordHash,dto.Password);
            if(result==PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid email or password");
            }
            var claims=new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role,$"{user.Role.Name}"),
                new Claim("DateOfBirth",user.DateOfBirth.Value.ToString("yyyy-MM-dd")),
                new Claim("NickName",user.NickName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);
            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);
            var tokenHandler=new JwtSecurityTokenHandler();
            return  tokenHandler.WriteToken(token);
        }

        public async Task RegisterUser(RegisterUserDTO dto)
        {
            var newUser = new User()
            {
                NickName = dto.NickName,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId
            };
            var hashedPassword= _passwordHasher.HashPassword(newUser,dto.Password);
            newUser.PasswordHash= hashedPassword;
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
