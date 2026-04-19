using Firma.Data.CMS;
using Firma.Data.CRM;
using Firma.Data.Nieruchomosci;
using Microsoft.EntityFrameworkCore;

namespace Firma.Data
{
    public class FirmaContext : DbContext
    {
        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options) { }

        public DbSet<Aktualnosc> Aktualnosc { get; set; } = default!;
        public DbSet<Strona> Strona { get; set; } = default!;
        public DbSet<TypNieruchomosci> TypNieruchomosci { get; set; } = default!;
        public DbSet<Nieruchomosc> Nieruchomosc { get; set; } = default!;
        public DbSet<Klient> Klient { get; set; } = default!;
        public DbSet<Pracownik> Pracownik { get; set; } = default!;
        public DbSet<Oferta> Oferta { get; set; } = default!;
        public DbSet<Umowa> Umowa { get; set; } = default!;
    }
}
