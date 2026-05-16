using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktualnosc",
                columns: table => new
                {
                    IdAktualnosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktualnosc", x => x.IdAktualnosci);
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataRejestracji = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.IdKlienta);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    IdPracownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stanowisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataZatrudnienia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.IdPracownika);
                });

            migrationBuilder.CreateTable(
                name: "Strona",
                columns: table => new
                {
                    IdStrony = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strona", x => x.IdStrony);
                });

            migrationBuilder.CreateTable(
                name: "TypNieruchomosci",
                columns: table => new
                {
                    IdTypu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypNieruchomosci", x => x.IdTypu);
                });

            migrationBuilder.CreateTable(
                name: "Umowa",
                columns: table => new
                {
                    IdUmowy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPodpisania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypUmowy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WartoscUmowy = table.Column<decimal>(type: "money", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Umowa", x => x.IdUmowy);
                    table.ForeignKey(
                        name: "FK_Umowa_Klient_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nieruchomosc",
                columns: table => new
                {
                    IdNieruchomosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    Powierzchnia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiczbaIzb = table.Column<int>(type: "int", nullable: false),
                    FotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTypu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nieruchomosc", x => x.IdNieruchomosci);
                    table.ForeignKey(
                        name: "FK_Nieruchomosc_TypNieruchomosci_IdTypu",
                        column: x => x.IdTypu,
                        principalTable: "TypNieruchomosci",
                        principalColumn: "IdTypu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    IdOferty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataWystawienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    IdNieruchomosci = table.Column<int>(type: "int", nullable: false),
                    IdPracownika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.IdOferty);
                    table.ForeignKey(
                        name: "FK_Oferta_Nieruchomosc_IdNieruchomosci",
                        column: x => x.IdNieruchomosci,
                        principalTable: "Nieruchomosc",
                        principalColumn: "IdNieruchomosci",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oferta_Pracownik_IdPracownika",
                        column: x => x.IdPracownika,
                        principalTable: "Pracownik",
                        principalColumn: "IdPracownika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nieruchomosc_IdTypu",
                table: "Nieruchomosc",
                column: "IdTypu");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdNieruchomosci",
                table: "Oferta",
                column: "IdNieruchomosci");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdPracownika",
                table: "Oferta",
                column: "IdPracownika");

            migrationBuilder.CreateIndex(
                name: "IX_Umowa_IdKlienta",
                table: "Umowa",
                column: "IdKlienta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktualnosc");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Strona");

            migrationBuilder.DropTable(
                name: "Umowa");

            migrationBuilder.DropTable(
                name: "Nieruchomosc");

            migrationBuilder.DropTable(
                name: "Pracownik");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "TypNieruchomosci");
        }
    }
}
