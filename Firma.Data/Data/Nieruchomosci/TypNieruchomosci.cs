using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Nieruchomosci
{
    public class TypNieruchomosci
    {
        [Key]
        public int IdTypu { get; set; }

        [Required(ErrorMessage = "Podaj nazwę typu")]
        [MaxLength(50)]
        [Display(Name = "Nazwa")]
        public required string Nazwa { get; set; }

        [Display(Name = "Opis")]
        public string Opis { get; set; } = string.Empty;

        public ICollection<Nieruchomosc> Nieruchomosci { get; } = new List<Nieruchomosc>();
    }
}
