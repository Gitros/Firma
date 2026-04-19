using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.CRM
{
    public class Umowa
    {
        [Key]
        public int IdUmowy { get; set; }

        [Display(Name = "Data podpisania")]
        [DataType(DataType.Date)]
        public DateTime DataPodpisania { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Podaj typ umowy")]
        [MaxLength(50)]
        [Display(Name = "Typ umowy")]
        public required string TypUmowy { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Wartość umowy (zł)")]
        public decimal WartoscUmowy { get; set; }

        [Display(Name = "Uwagi")]
        public string Uwagi { get; set; } = string.Empty;

        [ForeignKey("Klient")]
        [Display(Name = "Klient")]
        public int IdKlienta { get; set; }

        public Klient? Klient { get; set; }
    }
}
