using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmmascoTravelsApp1.Models
{


    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }//login to be used for name

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        /*[Required]
        [MaxLength(255)]  // plenty of room for hashed passwords
        public string Password { get; set; }//login password to be used*/ 
        [Required]
        [StringLength(255)] // enough space for hashed passwords
        public string Password { get; set; }


        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public byte[]? ProfilePicture { get; set; }
        public string Role { get; set; }
        [NotMapped]
        public string? NewPassword { get; set; }

    }
}