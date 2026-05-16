# Dokumentacja projektu Firma — NieruchomościPro

**Technologia:** ASP.NET Core 10 MVC · Bootstrap 5.3.3 · Bootstrap Icons 1.11.3 (lokalne)  
**Temat firmy:** Agencja nieruchomości — NieruchomościPro  
**Brak:** bazy danych, autentykacji, obsługi formularzy po stronie serwera (etap 1)

---

## Struktura solucji

```
Firma.slnx
├── Firma.PortalWWW/          ← projekt dla klientów (publiczny)
└── Firma.Intranet/           ← projekt dla pracowników (wewnętrzny)
```

---

## Firma.PortalWWW — Portal kliencki

**Styl:** jasny, elegancki, navy (#1a2a4a) + złoto (#c9a961), nagłówki serif (Georgia)

### Plik: `Controllers/HomeController.cs`

Jeden kontroler, cztery akcje — każda zwraca widok:

| Akcja | URL | Widok |
|-------|-----|-------|
| `Index()` | `/` | `Views/Home/Index.cshtml` |
| `Oferta()` | `/Home/Oferta` | `Views/Home/Oferta.cshtml` |
| `ONas()` | `/Home/ONas` | `Views/Home/ONas.cshtml` |
| `Kontakt()` | `/Home/Kontakt` | `Views/Home/Kontakt.cshtml` |
| `Error()` | (auto) | `Views/Shared/Error.cshtml` |

### Plik: `Views/Shared/_Layout.cshtml` — wspólny szkielet wszystkich stron

**Co zawiera:**
- `<head>` — Bootstrap CSS, Bootstrap Icons CSS (lokalny: `~/lib/bootstrap-icons/`), `site.css`
- **Navbar** — sticky-top, logo z ikoną `bi-house-heart-fill`, 4 linki nawigacyjne + przycisk CTA "Umów spotkanie"
  - aktywny link podkreślony złotą linią (klasa `active` ustawiana przez funkcję `Active()` w Razor)
  - na mobile: hamburger toggler → collapse menu
- `@RenderBody()` — tu wstawiają się treści poszczególnych stron
- **Footer** — 4 kolumny: opis firmy + social icons, nawigacja, usługi, dane kontaktowe
- `<footer-bottom>` — pasek z prawami autorskimi
- skrypty: jQuery, Bootstrap bundle, `site.js`
- `@RenderSectionAsync("Scripts")` — sekcja dla skryptów per-strona

### Plik: `Views/Home/Index.cshtml` — Strona główna

**Sekcje na stronie (z góry na dół):**

1. **Hero section** (ciemne tło gradientowe z sylwetami budynków SVG)
   - badge "Nr 1 w regionie · Od 2005 roku"
   - nagłówek H1 z akcentem złotym
   - lead text + 2 przyciski CTA (Przeglądaj oferty, Skontaktuj się)
   - search box (4 pola: typ, lokalizacja, cena, przycisk Szukaj)

2. **Dlaczego my** (tło białe, `section-light`)
   - 3 karty z ikonami: Bezpieczeństwo, Ceny rynkowe, Dedykowany agent

3. **Wyróżnione nieruchomości**
   - 3 karty ofert (`.property-card`): Zakopane apartament 685k, Nowy Sącz dom 1.25M, Kraków inwestycja 425k
   - każda karta: gradient-placeholder zamiast zdjęcia, badge typ, cena, lokalizacja, meta (m², pokoje)
   - przycisk "Zobacz wszystkie oferty"

4. **Stats strip** (tło navy)
   - 4 liczby: 2500+ klientów, 19 lat, 350+ ofert, 28 agentów

5. **O nas teaser** (tło białe)
   - placeholder graficzny (gradient) + tekst o firmie
   - link do strony O nas

### Plik: `Views/Home/Oferta.cshtml` — Oferta

**Sekcje:**

1. **Page header** — ciemny pasek z tytułem i breadcrumb
2. **Filter bar** — 4 pola filtra (typ, lokalizacja, cena od/do) + pills tematyczne (Nowości, Z ogrodem, Pod wynajem...)
3. **Sortowanie** — informacja "Znaleziono 6 ofert" + select sortowania
4. **6 kart ofert** — siatka 3×2:
   - Zakopane apartament 685k (Nowość)
   - Nowy Sącz dom 1.25M (Premium)
   - Kraków inwestycja 425k (Inwestycja)
   - Stary Sącz działka 320k (Działka)
   - Tarnów lokal 2.8M (Premium)
   - Nowy Sącz mieszkanie 389k (Okazja)
5. **Paginacja** — numeryczna (1/2/3/.../12)

### Plik: `Views/Home/ONas.cshtml` — O nas

**Sekcje:**

1. **Page header** — ciemny pasek z tytułem
2. **Misja** — 2 kolumny: tekst + cytat założyciela + placeholder graficzny
3. **Wartości** — 3 karty z border-top złotym: Pasja, Uczciwość, Profesjonalizm
4. **Historia firmy** — timeline pionowy z 5 punktami: 2005→2011→2017→2022→Dziś
   - złota linia pionowa, złote kółka punktów
5. **Zespół** — 4 karty: Marcin Wójcik (CEO), Anna Kowalska (Sprzedaż), Piotr Nowak (Prawnik), Katarzyna Zając (Marketing)
   - każda karta: okrągły avatar gradient z inicjałami, stanowisko

### Plik: `Views/Home/Kontakt.cshtml` — Kontakt

**Sekcje:**

1. **Page header** — ciemny pasek
2. **2 kolumny:**
   - **Lewa** (navy background, `.contact-info-card`): adres, telefon, email, godziny otwarcia, social icons
   - **Prawa** (biała karta, `.contact-form-card`): formularz — imię/nazwisko, telefon, email, temat (select), wiadomość (textarea), checkbox RODO, przycisk Wyślij
3. **4 oddziały** — karty z ikonami: Nowy Sącz, Kraków, Tarnów, Zakopane

### Plik: `wwwroot/css/site.css` — style portalu

**Co definiuje (z góry na dół):**
- `:root` — zmienne CSS: `--brand`, `--accent`, `--bg`, `--text`, `--muted`
- typography — font-size, body font, nagłówki serif
- `.portal-nav` — sticky navbar: brand, linki, efekt active (podkreślenie złotem)
- `.btn-brand`, `.btn-accent`, `.btn-outline-light-brand` — przyciski
- `.hero` — tło gradient + SVG budynki, min-height 600px
- `.hero-search` — biała wyszukiwarka na hero
- `.section`, `.section-light` — paddinging sekcji
- `.section-title`, `.eyebrow` — nagłówki sekcji
- `.feature-card`, `.feature-icon` — karty "Dlaczego my"
- `.property-card`, `.property-img`, `.property-badge`, `.property-body`, `.property-meta` — karty nieruchomości z hover-lift
- `.stats-strip`, `.stat-number`, `.stat-label` — pasek statystyk
- `.image-placeholder` — placeholder graficzny (gradient)
- `.filter-bar`, `.filter-pill` — pasek filtrów na Ofercie
- `.contact-info-card`, `.contact-form-card` — sekcje kontaktu
- `.value-card` — karty wartości z border-top
- `.team-avatar`, `.team-card` — karty zespołu
- `.timeline`, `.timeline-item`, `.timeline-year` — oś czasu
- `.portal-footer`, `.footer-brand`, `.footer-heading`, `.footer-links`, `.footer-contact`, `.social-icons` — stopka
- `.page-header` — ciemny nagłówek stron wewnętrznych

---

## Firma.Intranet — Panel pracowniczy (CRM)

**Styl:** ciemny sidebar (#1e2a3a), jasna treść (#f5f7fa), akcent niebieski (#2563eb), font systemowy

### Plik: `Controllers/HomeController.cs`

| Akcja | URL | Widok |
|-------|-----|-------|
| `Index()` | `/` | `Views/Home/Index.cshtml` (Dashboard) |
| `Pracownicy()` | `/Home/Pracownicy` | `Views/Home/Pracownicy.cshtml` |
| `Raporty()` | `/Home/Raporty` | `Views/Home/Raporty.cshtml` |
| `Ustawienia()` | `/Home/Ustawienia` | `Views/Home/Ustawienia.cshtml` |
| `Error()` | (auto) | `Views/Shared/Error.cshtml` |

### Plik: `Views/Shared/_Layout.cshtml` — szkielet panelu

**Struktura HTML:**

```
body
└── .app-shell (flex row)
    ├── <aside class="sidebar">         ← widoczny na desktopie (≥lg)
    ├── <div class="offcanvas"> #sideNav ← ten sam sidebar, mobile (offcanvas)
    └── .app-main (flex column)
        ├── <header class="topbar">     ← pasek górny
        ├── <main class="content-area"> ← @RenderBody()
        └── <footer class="app-footer"> ← wersja systemu
```

**Sidebar (desktop `<aside>` + mobile offcanvas):**
- brand: ikona `bi-buildings-fill` + "NieruchomościPro CRM v1.0"
- nawigacja (`.sidebar-nav`):
  - sekcja "Główne": Dashboard (bi-grid-1x2-fill), Pracownicy (bi-people-fill), Raporty (bi-bar-chart-fill)
  - sekcja "System": Ustawienia (bi-gear-fill), Pomoc
  - aktywny link: niebieski background + box-shadow
- stopka sidebara: avatar "JK" + "Jan Kowalski · Administrator"

**Topbar:**
- hamburger (widoczny tylko mobile) → otwiera offcanvas sidebar
- `ViewData["Title"]` — tytuł strony (duży)
- `ViewData["Subtitle"]` — podtytuł (mały, szary)
- search box (`.topbar-search`) z ikoną
- ikona dzwonka z czerwoną kropką powiadomienia
- ikona koperty
- dropdown użytkownika: avatar "JK" + "Jan Kowalski" → Mój profil / Ustawienia / Wyloguj

**Footer:** "NieruchomościPro CRM v1.0.0 © 2026"

### Plik: `Views/Home/Index.cshtml` — Dashboard

**Sekcje:**

1. **4 kafelki statystyk** (`.tile`) — siatka 4 kolumn:
   - Aktywne transakcje: 128 (+12.5%)
   - Klienci w bazie: 2547 (+8.3%)
   - Aktywne oferty: 352 (-2.1%)
   - Przychód m-c: 1.2 mln (+18.7%)
   - każdy kafelik: ikona kolorowa, wartość, etykieta, badge trendu (zielony↑ / czerwony↓)

2. **Ostatnia aktywność** (lewa kolumna 7/12)
   - 5 pozycji z ikoną, tekstem zdarzenia i czasem
   - zdarzenia: transakcja, nowy klient, nowa oferta, alert wygaśnięcia, oględziny

3. **Nadchodzące zadania** (prawa kolumna 5/12)
   - 5 zadań z kolorowym paskiem priorytetu (czerwony/żółty/zielony)
   - każde zadanie: tytuł, data/godzina

### Plik: `Views/Home/Pracownicy.cshtml` — Pracownicy

**Sekcje:**

1. **Toolbar** (section-h):
   - search input + select "Wszystkie stanowiska"
   - przyciski: Eksport CSV, Dodaj pracownika

2. **Tabela pracowników** (8 statycznych wierszy):

| Kolumny tabeli |
|----------------|
| # (ID) |
| Pracownik (avatar z inicjałami + imię/nazwisko + miasto) |
| Stanowisko |
| Email |
| Telefon |
| Sprzedaż (m-c) |
| Status (badge: Aktywny zielony / Urlop żółty / Offline szary) |
| Akcje (edytuj, wiadomość, usuń) |

Pracownicy: MW-Marcin Wójcik (CEO), AK-Anna Kowalska, PN-Piotr Nowak (urlop), KZ-Katarzyna Zając, PW-Piotr Wiśniewski, MK-Magdalena Kaczmarek, JL-Jakub Lewandowski, EK-Ewa Kamińska

3. **Paginacja** w stopce tabeli + info "Pokazano 8 z 28"

### Plik: `Views/Home/Raporty.cshtml` — Raporty

**Sekcje:**

1. **Toolbar**: select zakres czasu + select oddział + przyciski Drukuj/Export PDF/Pobierz

2. **3 KPI tiles**: Sprzedaż roczna (14.8 mln), Średni czas sprzedaży (42 dni), Konwersja (31.2%)

3. **Bar chart — Sprzedaż miesięczna 2026** (lewa kolumna)
   - 12 słupków (Sty–Gru), renderowane CSS div z różnymi wysokościami `%`
   - brak zewnętrznej biblioteki wykresów — pure CSS

4. **Ranking agentów Q1 2026** (prawa kolumna)
   - 5 agentów z: avatar, nazwa, oddział/transakcje, progress bar Bootstrap, wartość sprzedaży

5. **Tabela statystyk ofert** (pełna szerokość)
   - 4 kategorie: Mieszkania, Domy, Działki, Lokale użytkowe
   - kolumny: aktywnych, nowych, sprzedanych, średnia cena, czas sprzedaży, trend

### Plik: `Views/Home/Ustawienia.cshtml` — Ustawienia

**4 zakładki Bootstrap (nav-tabs):**

| Zakładka | Zawartość |
|----------|-----------|
| **Profil** | Avatar z inicjałami + przycisk zmień, 7 pól: imię, nazwisko, email, telefon, stanowisko, oddział (select), bio (textarea) |
| **Powiadomienia** | 4 toggles kanałów (Email, Push, SMS, Slack) + 6 checkboxów typów zdarzeń |
| **Bezpieczeństwo** | Formularz zmiany hasła (3 pola) + status 2FA + lista aktywnych sesji |
| **System** | Select język, strefa czasowa, format daty, waluta + 2 switche (tryb ciemny, autosave) |

Stopka formularza: Anuluj | Resetuj | Zapisz zmiany

### Plik: `wwwroot/css/site.css` — style intranetu

**Co definiuje:**
- `:root` — zmienne: `--sidebar-bg`, `--accent`, `--bg`, `--card`, `--border`, kolory statusów
- `.app-shell`, `.app-main` — flex layout całej strony
- `.sidebar`, `.sidebar-offcanvas` — stały panel boczny (position: fixed)
- `.sidebar-brand`, `.brand-title`, `.brand-sub` — nagłówek sidebara
- `.sidebar-nav`, `.nav-section`, `nav-link`, `nav-link.active` — pozycje menu, hover, aktywny stan
- `.sidebar-foot`, `.user-mini` — stopka sidebara z użytkownikiem
- `.avatar`, `.avatar-sm` — okrągłe inicjały
- `.topbar`, `.page-title`, `.topbar-search` — pasek górny
- `.topbar-icon`, `.user-pill` — ikony akcji i dropdown użytkownika
- `.content-area`, `.app-footer` — treść i stopka
- `.tile`, `.tile-head`, `.tile-icon`, `.tile-trend`, `.tile-value` — kafelki statystyk
- `.panel`, `.panel-head`, `.panel-body` — kontenery sekcji
- `.table` thead/tbody — style tabeli (szare nagłówki, hover wierszy)
- `.badge-status` (active/away/offline) — kolorowe statusy z kropką
- `.btn-icon` — małe kwadratowe przyciski akcji
- `.activity-item`, `.activity-dot` — lista aktywności
- `.task-item`, `.task-prio` — lista zadań z kolorowym paskiem
- `.bar-chart`, `.bar-col`, `.bar` — CSS wykres słupkowy
- `.agent-row`, `.progress` — ranking agentów z paskiem postępu
- `.nav-tabs`, `nav-link.active` — zakładki ustawień
- `.section-h` — nagłówek sekcji z toolbarem

---

## Pliki konfiguracyjne (oba projekty, identyczne)

| Plik | Rola |
|------|------|
| `Program.cs` | startuje aplikację, rejestruje MVC, konfiguruje routing `{controller=Home}/{action=Index}/{id?}` |
| `Views/_ViewStart.cshtml` | ustawia domyślny layout: `Layout = "_Layout"` |
| `Views/_ViewImports.cshtml` | importuje namespace projektu, modeli, rejestruje Tag Helpers |
| `Models/ErrorViewModel.cs` | model dla strony błędu (RequestId) |
| `Views/Shared/Error.cshtml` | strona błędu HTTP |
| `Views/Shared/_ValidationScriptsPartial.cshtml` | jQuery Validation (używane opcjonalnie w sekcji Scripts) |

## Biblioteki w `wwwroot/lib/`

| Biblioteka | Wersja | Użycie |
|------------|--------|--------|
| bootstrap | 5.3.3 | CSS framework, grid, komponenty (navbar, offcanvas, tabs, cards) |
| bootstrap-icons | 1.11.3 | ikony (lokalne w `lib/bootstrap-icons/font/`) |
| jquery | bundled | wymagane przez Bootstrap JS |
| jquery-validation | bundled | walidacja formularzy po stronie klienta |
| jquery-validation-unobtrusive | bundled | integracja z ASP.NET MVC validation |

> Brak zewnętrznych CDN — wszystkie zasoby serwowane lokalnie.

Mechanizm ASP.NET MVC — pozwala widokom wstrzykiwać własne skrypty JS na koniec <body>.

W _Layout.cshtml (deklaracja miejsca):

@await RenderSectionAsync("Scripts", required: false)
"Jeśli jakiś widok zadeklaruje sekcję Scripts, wstaw ją tutaj."
required: false = widok bez tej sekcji nie rzuca błędu.

W widoku (opcjonalne użycie):

@section Scripts {
    <script>
        console.log("tylko na tej stronie");
    </script>
}
Po co — jQuery Validation działa tak właśnie. Np. gdybyś dodał walidację formularza tylko na stronie Kontakt, wstawiasz tam:

@section Scripts {
    @await Html.PartialAsync("_ValidationScriptsPartial")
}
I skrypty validacji ładują się tylko na tej stronie, nie na każdej.