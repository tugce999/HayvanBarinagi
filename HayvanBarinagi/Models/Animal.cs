using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HayvanBarinagi.Models
{
    [Table("Animals")]
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen isim giriniz")]
        [Display(Name = "İsmi")]
        public string ?Name { get; set; }

        public string sahip { get; set; }

        [Display(Name = "Cinsiyet")]
        public string  ?GenderType { get; set; }

        [Required(ErrorMessage = "Lütfen yaşını giriniz")]
        [Display(Name = "Yaş")]
        public string  ?Age { get; set; }

       

        [Required(ErrorMessage = "Lütfen rengini giriniz")]
        [Display(Name = "Renk")]
        public string ?Color { get; set; }

    }

    
}
