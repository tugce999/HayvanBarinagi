using System.ComponentModel.DataAnnotations;

namespace HayvanBarinagi.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Username is required.")]
        [StringLength(20,ErrorMessage ="Username can be max 20 characters.")]
        public string ?UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3, ErrorMessage = "Password can be min 3 characters.")]
        [MaxLength(20,ErrorMessage = "Password can be max 20 characters.")]
        public string ?Password { get; set; }
    }

   
}

