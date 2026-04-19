using System.ComponentModel.DataAnnotations;

namespace Firma.Data.CRM
{
    public class Klient
    {
        [Key]
        public int IdKlienta { get; set; }

        [Required(ErrorMessage = "Podaj imię klienta")]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko klienta")]
        [MaxLength(50)]
        [Display(Name = "Nazwisko")]
        public required string Nazwisko { get; set; }

        [Required(ErrorMessage = "Podaj adres e-mail")]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public required string Email { get; set; }

        [MaxLength(20)]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; } = string.Empty;

        [Display(Name = "Data rejestracji")]
        [DataType(DataType.Date)]
        public DateTime DataRejestracji { get; set; } = DateTime.Today;
    }
}
