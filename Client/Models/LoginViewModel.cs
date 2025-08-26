using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class LoginViewModel
    {
        //[Required]
        //public string Email { get; set; }

        //[Required]
        //public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
