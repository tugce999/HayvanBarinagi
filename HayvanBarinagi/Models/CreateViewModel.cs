using System.ComponentModel.DataAnnotations;

namespace HayvanBarinagi.Models
{
    public class CreateViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string ?NameSurname { get; set; }
        [Required]
        [StringLength(20)]
        public string ?UserName { get; set; }
        [Required]
        public DateTime CreatedAdd { get; set; } = DateTime.Now;
        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";

    }
}
