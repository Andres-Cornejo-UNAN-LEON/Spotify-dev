using Microsoft.AspNetCore.Mvc;
using Spotify.Models;
using Microsoft.EntityFrameworkCore;

namespace Spotify.Controllers;

public class BachatasController : Controller{
    private readonly AppDbContext _context;
    public BachatasController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> search(string buscar){
        List<Bachata> bachata = await _context.Bachatas.ToListAsync();
        if(buscar==null){
            return View("Index", bachata);
        }
        List<Bachata> sear = new List<Bachata>();
        foreach(var item in bachata){
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
        List<Bachata> bachata = await _context.Bachatas.ToListAsync();
        List<Bachata> ord = null;
        if(id.Equals(1)){
            ord = bachata.OrderBy(x => x.cancion).ToList();
        }
        if(id.Equals(2)){
            ord = bachata.OrderBy(x => x.artista).ToList();
        }
        return View("Index", ord);
    }
    public async Task<IActionResult> Index(){
        List<Bachata> lsBachata = await _context.Bachatas.ToListAsync();
        if(lsBachata.Count==0){return View(null);}
        return View(lsBachata);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,cancion,artista,lanzamiento,imgPrincipal,Spotify,color")] Bachata bachata)
    {
        if (ModelState.IsValid)
        {
            _context.Add(bachata);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(bachata);
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Bachatas == null)
        {
            return NotFound();
        }

        var bachata = await _context.Bachatas
            .FirstOrDefaultAsync(m => m.id == id);
        if (bachata == null)
        {
            return NotFound();
        }

        return View(bachata);
    }
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bachatas == null)
            {
                return NotFound();
            }

            var Bachata = await _context.Bachatas.FindAsync(id);
            if (Bachata == null)
            {
                return NotFound();
            }
            return View(Bachata);
        }

        // POST: Bachatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,cancion,artista,lanzamiento,imgPrincipal,Spotify,color")] Bachata bachata)
    {
        if (id != bachata.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(bachata);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BachataExists(bachata.id))
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
        return View(bachata);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Bachatas == null)
        {
            return NotFound();
        }

        var Bachata = await _context.Bachatas
            .FirstOrDefaultAsync(m => m.id == id);
        if (Bachata == null)
        {
            return NotFound();
        }

        return View(Bachata);
    }

        // POST: Bachatas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Bachatas == null)
        {
            return Problem("Entity set 'AppDbContext.Bachatas'  is null.");
        }
        var Bachata = await _context.Bachatas.FindAsync(id);
        if (Bachata != null)
        {
            _context.Bachatas.Remove(Bachata);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool BachataExists(int id)
    {
        return (_context.Bachatas?.Any(e => e.id == id)).GetValueOrDefault();
    }
}