using Firma.Data;
using Firma.Data.Nieruchomosci;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class NieruchomoscController : Controller
    {
        private readonly FirmaContext _context;

        public NieruchomoscController(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Nieruchomosc.Include(n => n.TypNieruchomosci).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Nieruchomosc.Include(n => n.TypNieruchomosci).FirstOrDefaultAsync(m => m.IdNieruchomosci == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            ViewData["IdTypu"] = new SelectList(_context.TypNieruchomosci, "IdTypu", "Nazwa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNieruchomosci,Tytul,Adres,Cena,Powierzchnia,LiczbaIzb,FotoURL,Opis,IdTypu")] Nieruchomosc item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTypu"] = new SelectList(_context.TypNieruchomosci, "IdTypu", "Nazwa", item.IdTypu);
            return View(item);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Nieruchomosc.FindAsync(id);
            if (item == null) return NotFound();
            ViewData["IdTypu"] = new SelectList(_context.TypNieruchomosci, "IdTypu", "Nazwa", item.IdTypu);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNieruchomosci,Tytul,Adres,Cena,Powierzchnia,LiczbaIzb,FotoURL,Opis,IdTypu")] Nieruchomosc item)
        {
            if (id != item.IdNieruchomosci) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Nieruchomosc.Any(e => e.IdNieruchomosci == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTypu"] = new SelectList(_context.TypNieruchomosci, "IdTypu", "Nazwa", item.IdTypu);
            return View(item);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Nieruchomosc.Include(n => n.TypNieruchomosci).FirstOrDefaultAsync(m => m.IdNieruchomosci == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Nieruchomosc.FindAsync(id);
            if (item != null) _context.Nieruchomosc.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
