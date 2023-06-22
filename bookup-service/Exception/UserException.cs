using System;
namespace bookup_service.Exception
{
	public class UserException: System.Exception
    {
		public UserException(string message) : base(message)
		{
		}
	}
}

