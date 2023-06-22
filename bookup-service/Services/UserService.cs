using System;
using bookup_service.Configurations;
using bookup_service.Dto.Request;
using bookup_service.Exception;
using bookup_service.Interfaces;
using bookup_service.Models;
using Microsoft.EntityFrameworkCore;

namespace bookup_service.Services
{
	public class UserService: IUserService, IService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly JwtService _jwtService;

        public UserService(ApplicationDbContext dbContext, JwtService jwtService)
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
        }

        public (bool, string) AuthenticateUser(UserLogInDto userLogInDto)
        {
            var user= _dbContext.Set<User>().FirstOrDefault(user => user.Email == userLogInDto.Email);

            if (user == null)
            {
                throw new UserException("User not found for email");
            }
            else
            {
                if (user.Password.Equals(userLogInDto.Password))
                {
                    return (true, _jwtService.GenerateJwt(user.Id, user.Email));
                }
                else
                {
                    return (false, "Wrong password");
                }
            }
        }

        public bool CreateUser(User user)
        {
            _dbContext.Set<User>().Add(user);
            _dbContext.SaveChanges();
            return true;
        }
    }
}

