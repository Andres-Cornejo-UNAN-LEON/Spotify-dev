using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spotify.Models;

namespace Spotify.Controllers
{
    public class ReggaetonsController : Controller
    {
        private readonly AppDbContext _context;

        public ReggaetonsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> search(string buscar){
            List<Reggaeton> reggaeton = await _context.Reggaetons.ToListAsync();
            if(buscar==null){
                return View("Index", reggaeton);
            }
            List<Reggaeton> sear = new List<Reggaeton>();
            foreach(var item in reggaeton){
                if(item.cancion.ToLower().Contains(buscar.ToLower())){
                    sear.Add(item);
                }
            }
            if(sear.Count==0){
                return View("Index", null);
            }
            return View("Index", sear);
        }
        public async Task<IActionResult> filtrado(int? id){
            List<Reggaeton> reggaeton = await _context.Reggaetons.ToListAsync();
            List<Reggaeton> ord = null;
            if(id.Equals(1)){
                ord = reggaeton.OrderBy(x => x.cancion).ToList();
            }
            if(id.Equals(2)){
                ord = reggaeton.OrderBy(x => x.artista).ToList();
            }
            return View("Index", ord);
        }

        // GET: Reggaetons
        public async Task<IActionResult> Index()
        {
              return _context.Reggaetons != null ? 
                          View(await _context.Reggaetons.ToListAsync()) :
                          View(null);
        }

        // GET: Reggaetons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reggaetons == null)
            {
                return NotFound();
            }

            var reggaeton = await _context.Reggaetons
                .Where(m => m.id == id).Include(m=>m.Comments).FirstAsync();
            if (reggaeton == null)
            {
                return NotFound();
            }

            return View(reggaeton);
        }

        // GET: Reggaetons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reggaetons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,cancion,artista,lanzamiento,imgPrincipal,Spotify,color")] Reggaeton reggaeton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reggaeton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reggaeton);
        }

        // GET: Reggaetons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reggaetons == null)
            {
                return NotFound();
            }

            var reggaeton = await _context.Reggaetons.FindAsync(id);
            if (reggaeton == null)
            {
                return NotFound();
            }
            return View(reggaeton);
        }

        // POST: Reggaetons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,cancion,artista,lanzamiento,imgPrincipal,Spotify,color")] Reggaeton reggaeton)
        {
            if (id != reggaeton.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reggaeton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReggaetonExists(reggaeton.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reggaeton);
        }

        // GET: Reggaetons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reggaetons == null)
            {
                return NotFound();
            }

            var reggaeton = await _context.Reggaetons
                .FirstOrDefaultAsync(m => m.id == id);
            if (reggaeton == null)
            {
                return NotFound();
            }

            return View(reggaeton);
        }

        // POST: Reggaetons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reggaetons == null)
            {
                return Problem("Entity set 'AppDbContext.Reggaetons'  is null.");
            }
            var reggaeton = await _context.Reggaetons.FindAsync(id);
            if (reggaeton != null)
            {
                _context.Reggaetons.Remove(reggaeton);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReggaetonExists(int id)
        {
          return (_context.Reggaetons?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
