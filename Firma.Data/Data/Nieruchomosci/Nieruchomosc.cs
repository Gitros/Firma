using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Nieruchomosci
{
    public class Nieruchomosc
    {
        [Key]
        public int IdNieruchomosci { get; set; }

        [Required(ErrorMessage = "Podaj tytuł ogłoszenia")]
        [MaxLength(100)]
        [Display(Name = "Tytuł")]
        public required string Tytul { get; set; }

        [Required(ErrorMessage = "Podaj adres nieruchomości")]
        [MaxLength(200)]
        [Display(Name = "Adres")]
        public required string Adres { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Cena (zł)")]
        public decimal Cena { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Powierzchnia (m²)")]
        public decimal Powierzchnia { get; set; }

        [Display(Name = "Liczba izb")]
        public int LiczbaIzb { get; set; }

        [Required(ErrorMessage = "Podaj URL zdjęcia")]
        [Display(Name = "Zdjęcie (URL)")]
        public required string FotoURL { get; set; }

        [Display(Name = "Opis")]
        public string Opis { get; set; } = string.Empty;

        [ForeignKey("TypNieruchomosci")]
        [Display(Name = "Typ nieruchomości")]
        public int IdTypu { get; set; }

        public TypNieruchomosci? TypNieruchomosci { get; set; }
    }
}
