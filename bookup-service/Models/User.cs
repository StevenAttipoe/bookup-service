using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookup_service.Models
{
	public class User
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
		[EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

		[Required]
		[MinLength(6)]
        public string Password { get; set; }

        public User()
        {
        }

        public User(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }

    }
}

