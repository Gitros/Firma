using Firma.Data;
using Firma.Data.CRM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class UmowaController : Controller
    {
        private readonly FirmaContext _context;

        public UmowaController(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Umowa.Include(u => u.Klient).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Umowa.Include(u => u.Klient).FirstOrDefaultAsync(m => m.IdUmowy == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Nazwisko");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUmowy,DataPodpisania,TypUmowy,WartoscUmowy,Uwagi,IdKlienta")] Umowa item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Nazwisko", item.IdKlienta);
            return View(item);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Umowa.FindAsync(id);
            if (item == null) return NotFound();
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Nazwisko", item.IdKlienta);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUmowy,DataPodpisania,TypUmowy,WartoscUmowy,Uwagi,IdKlienta")] Umowa item)
        {
            if (id != item.IdUmowy) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Umowa.Any(e => e.IdUmowy == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Nazwisko", item.IdKlienta);
            return View(item);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Umowa.Include(u => u.Klient).FirstOrDefaultAsync(m => m.IdUmowy == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Umowa.FindAsync(id);
            if (item != null) _context.Umowa.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
