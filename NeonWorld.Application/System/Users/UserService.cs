using NeonWorld.EF;
using NeonWorld.Entities;
using NeonWorld.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NeonWorld.ViewModels.Common;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace NeonWorld.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly NeonWorldDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserService(NeonWorldDbContext context, IMapper mapper,
            IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        public ApiResult<bool> ChangePassword(UserChangePassword changePassword)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == changePassword.Email);
            if (user == null)
            {
                return new ApiErrorResult<bool>("Invalid User!");
            }
            bool verified = BCrypt.Net.BCrypt.Verify(changePassword.Password, user.Password);
            if (verified)
            {
                user.Password = changePassword.NewPassword;
                _context.Users.Update(user);
            }
            if (_context.SaveChanges() > 0)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Change password failed!");
        }

        public ApiResult<bool> CreateUser(RegisterRequest userRegister)
        {
            var user = _context.Users.FirstOrDefault(u => u.Phone == userRegister.Phone);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Phone number already exists!");
            }
            user = _context.Users.FirstOrDefault(u => u.Email == userRegister.Email);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Email already exists!");
            }
            var userEntity = _mapper.Map<User>(userRegister);
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(userEntity.Password);

            _context.Users.Add(userEntity);
            if (_context.SaveChanges() > 0)
            {
                return new ApiSuccessResult<bool>(); ;
            }
            return new ApiErrorResult<bool>("Registration failed!"); 
        }

        public ApiResult<string> Login(UserLogin userLogin)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userLogin.Email);
            if (user == null)
            {
                return new ApiErrorResult<string>("Email doesn't exists!");
            }
            bool verified = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password);
            if (verified)
            {
                return new ApiSuccessResult<string>(GenerateToken(user));
            }
            return new ApiErrorResult<string>("Incorrect Password!");
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
            return user;
        }

        public ApiResult<string> Logout()
        {
            new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };
            return new ApiSuccessResult<string>("Logout success!");
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, (user.UserID).ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token) + ":" + (int)((DateTimeOffset)DateTime.Now.AddMinutes(15)).ToUnixTimeSeconds(); ;
        }
    }
}
