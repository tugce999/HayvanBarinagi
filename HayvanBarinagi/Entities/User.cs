using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HayvanBarinagi.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int ?Id { get; set; }

        [StringLength(50)]
        public String? NameSurname { get; set; }
        [Required]
        [StringLength(20)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string? Password { get; set; }
        [Required]
        public DateTime CreatedAdd { get; set; } = DateTime.Now;

        [Required]
       [StringLength(50)]
        public string Role { get; set; } = "user";
    }
}
