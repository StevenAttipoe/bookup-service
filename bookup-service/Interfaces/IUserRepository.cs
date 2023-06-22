using System;
using bookup_service.Models;

namespace bookup_service.Interfaces
{
	public interface IUserRepository
	{
        void CreateUser(User user);
    }
}

