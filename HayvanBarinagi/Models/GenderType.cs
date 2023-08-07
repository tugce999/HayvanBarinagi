using System.ComponentModel.DataAnnotations;

namespace HayvanBarinagi.Models
{
    public class GenderType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cinsiyet")]
        public string Gender { get; set; }
    }
}