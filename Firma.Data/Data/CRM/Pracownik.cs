using System.ComponentModel.DataAnnotations;

namespace Firma.Data.CRM
{
    public class Pracownik
    {
        [Key]
        public int IdPracownika { get; set; }

        [Required(ErrorMessage = "Podaj imię pracownika")]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko pracownika")]
        [MaxLength(50)]
        [Display(Name = "Nazwisko")]
        public required string Nazwisko { get; set; }

        [Required(ErrorMessage = "Podaj stanowisko")]
        [MaxLength(100)]
        [Display(Name = "Stanowisko")]
        public required string Stanowisko { get; set; }

        [Required(ErrorMessage = "Podaj adres e-mail")]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public required string Email { get; set; }

        [Display(Name = "Data zatrudnienia")]
        [DataType(DataType.Date)]
        public DateTime DataZatrudnienia { get; set; } = DateTime.Today;
    }
}
