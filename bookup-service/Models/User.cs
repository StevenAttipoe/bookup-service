using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookup_service.Models
{
	public class User
	{
        public User(long id, string? fullName, string? email, string? password)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
		[EmailAddress]
        [MaxLength(50)]
        public string? Email { get; set; }

		[Required]
		[MinLength(6)]
        public string? Password { get; set; }

 	}
}

