using System.ComponentModel.DataAnnotations;

namespace HayvanBarinagi.Models
{
    public class OwnedType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sahipli")]
        public string Owned { get; set; }
    }
}