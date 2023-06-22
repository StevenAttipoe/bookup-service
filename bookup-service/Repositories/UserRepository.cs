using System;
using bookup_service.Interfaces;
using bookup_service.Models;
using Microsoft.EntityFrameworkCore;

namespace bookup_service.Repositories
{
	public class UserRepository: IUserRepository, IRepository
    {
		private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
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

