using System.ComponentModel.DataAnnotations;

namespace HayvanBarinagi.Models
{
    public class AnimalTypes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Animal Type")]
        public string AnimalType { get; set; }
    }
}