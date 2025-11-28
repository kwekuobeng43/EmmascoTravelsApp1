using EmmascoTravelsApp1.Models;
using System.ComponentModel.DataAnnotations;

namespace EmmascoTravelsApp1.Models
{


    public class RegistrationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}

