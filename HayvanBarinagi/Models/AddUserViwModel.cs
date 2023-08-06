using System.ComponentModel.DataAnnotations;

namespace HayvanBarinagi.Models
{
    public class AddUserViwModel
    {
        [StringLength(50)]
        public string? NameSurname { get; set; }
        [Required]
        [StringLength(20)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string? Email{ get; set; }
        public string? Password { get; set; }
        [Required]
        public DateTime CreatedAdd { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";

        public string? RePassword { get; set; }
    }
}
