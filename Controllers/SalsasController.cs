using Microsoft.AspNetCore.Mvc;
using Spotify.Models;
using Microsoft.EntityFrameworkCore;

namespace Spotify.Controllers;

public class SalsasController : Controller{
    private readonly AppDbContext _context;
    public SalsasController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> search(string buscar){
        List<Salsa> salsa = await _context.Salsas.ToListAsync();
        if(buscar==null){
            return View("Index", salsa);
        }
        List<Salsa> sear = new List<Salsa>();
        foreach(var item in salsa){
            if(item.cancion.ToLower().Contains(buscar.ToLower())){
                sear.Add(item);
            }
        }
        if(sear.Count==0){
            return View("Index", null);
        }
        return View("Index", sear);
    }
    public async Task<IActionResult> Index(){
        List<Salsa> lsSalsas = await _context.Salsas.ToListAsync();
        if(lsSalsas.Count==0){return View(null);}
        return View(lsSalsas);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,cancion,artista,imgPrincipal,color")] Salsa salsa)
    {
        if (ModelState.IsValid)
        {
            _context.Add(salsa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(salsa);
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Salsas == null)
        {
            return NotFound();
        }

        var salsa = await _context.Salsas
            .FirstOrDefaultAsync(m => m.id == id);
        if (salsa == null)
        {
            return NotFound();
        }

        return View(salsa);
    }
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salsas == null)
            {
                return NotFound();
            }

            var Salsa = await _context.Salsas.FindAsync(id);
            if (Salsa == null)
            {
                return NotFound();
            }
            return View(Salsa);
        }

        // POST: Salsas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,cancion,artista,imgPrincipal,color")] Salsa salsa)
    {
        if (id != salsa.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(salsa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalsaExists(salsa.id))
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
        return View(salsa);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Salsas == null)
        {
            return NotFound();
        }

        var Salsa = await _context.Salsas
            .FirstOrDefaultAsync(m => m.id == id);
        if (Salsa == null)
        {
            return NotFound();
        }

        return View(Salsa);
    }

        // POST: Salsas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Salsas == null)
        {
            return Problem("Entity set 'AppDbContext.Salsa'  is null.");
        }
        var salsa = await _context.Salsas.FindAsync(id);
        if (salsa != null)
        {
            _context.Salsas.Remove(salsa);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool SalsaExists(int id)
    {
        return (_context.Salsas?.Any(e => e.id == id)).GetValueOrDefault();
    }
}