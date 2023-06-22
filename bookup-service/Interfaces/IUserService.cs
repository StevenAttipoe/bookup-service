using System;
using bookup_service.Dto.Request;
using bookup_service.Models;

namespace bookup_service.Interfaces
{
	public interface IUserService
	{
        bool CreateUser(User user);

        (bool, string) AuthenticateUser(UserLogInDto userLogInDto);
    }
}

