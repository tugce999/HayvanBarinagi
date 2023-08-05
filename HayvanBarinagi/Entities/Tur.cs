using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarinagi.Entities
{
    [Table("Tür")]
    public class Tur
    {
        public int TurId { get; set; }
        [Display(Name = "Tür Adı")]
        [Required(ErrorMessage = "Tür Adı Girilmelidir")]
        public string? TurAdi { get; set; }

        //Hayvan ile ilişki
        public virtual List<Hayvan>? Hayvanlar { get; set; }
    }
}