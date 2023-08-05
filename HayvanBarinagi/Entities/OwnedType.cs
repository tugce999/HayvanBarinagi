using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarinagi.Entities
{
    [Table("OwnedType")]
    public class OwnedType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sahipli")]
        public string? Owned { get; set; }
    }
}