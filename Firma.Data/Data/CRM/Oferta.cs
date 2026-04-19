using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Nieruchomosci;

namespace Firma.Data.CRM
{
    public class Oferta
    {
        [Key]
        public int IdOferty { get; set; }

        [Display(Name = "Data wystawienia")]
        [DataType(DataType.Date)]
        public DateTime DataWystawienia { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Podaj status oferty")]
        [MaxLength(50)]
        [Display(Name = "Status")]
        public required string Status { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Cena oferty (zł)")]
        public decimal Cena { get; set; }

        [ForeignKey("Nieruchomosc")]
        [Display(Name = "Nieruchomość")]
        public int IdNieruchomosci { get; set; }

        public Nieruchomosc? Nieruchomosc { get; set; }

        [ForeignKey("Pracownik")]
        [Display(Name = "Agent")]
        public int IdPracownika { get; set; }

        public Pracownik? Pracownik { get; set; }
    }
}
