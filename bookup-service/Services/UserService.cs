using System;
using bookup_service.Interfaces;
using bookup_service.Models;

namespace bookup_service.Services
{
	public class UserService: IUserService, IService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUser(User user)
        {
            _dbContext.Set<User>().Add(user);
            _dbContext.SaveChanges();
        }
    }
}

