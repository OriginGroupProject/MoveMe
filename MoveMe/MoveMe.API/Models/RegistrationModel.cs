using System.ComponentModel.DataAnnotations;

namespace MoveMe.API.Models
{
    public class RegistrationModel
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }

        public string CompanyName { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}