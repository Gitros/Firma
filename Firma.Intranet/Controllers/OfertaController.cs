using Firma.Data;
using Firma.Data.CRM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class OfertaController : Controller
    {
        private readonly FirmaContext _context;

        public OfertaController(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Oferta
                .Include(o => o.Nieruchomosc)
                .Include(o => o.Pracownik)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Oferta
                .Include(o => o.Nieruchomosc)
                .Include(o => o.Pracownik)
                .FirstOrDefaultAsync(m => m.IdOferty == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            ViewData["IdNieruchomosci"] = new SelectList(_context.Nieruchomosc, "IdNieruchomosci", "Tytul");
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "Nazwisko");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOferty,DataWystawienia,Status,Cena,IdNieruchomosci,IdPracownika")] Oferta item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNieruchomosci"] = new SelectList(_context.Nieruchomosc, "IdNieruchomosci", "Tytul", item.IdNieruchomosci);
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "Nazwisko", item.IdPracownika);
            return View(item);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Oferta.FindAsync(id);
            if (item == null) return NotFound();
            ViewData["IdNieruchomosci"] = new SelectList(_context.Nieruchomosc, "IdNieruchomosci", "Tytul", item.IdNieruchomosci);
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "Nazwisko", item.IdPracownika);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOferty,DataWystawienia,Status,Cena,IdNieruchomosci,IdPracownika")] Oferta item)
        {
            if (id != item.IdOferty) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Oferta.Any(e => e.IdOferty == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNieruchomosci"] = new SelectList(_context.Nieruchomosc, "IdNieruchomosci", "Tytul", item.IdNieruchomosci);
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "Nazwisko", item.IdPracownika);
            return View(item);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Oferta
                .Include(o => o.Nieruchomosc)
                .Include(o => o.Pracownik)
                .FirstOrDefaultAsync(m => m.IdOferty == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Oferta.FindAsync(id);
            if (item != null) _context.Oferta.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
