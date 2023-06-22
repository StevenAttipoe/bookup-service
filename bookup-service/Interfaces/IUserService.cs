using System;
using bookup_service.Models;

namespace bookup_service.Interfaces
{
	public interface IUserService
	{
        void CreateUser(User user);
    }
}

