using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spotify.Models;

namespace Spotify.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly AppDbContext _context;

        public ComentariosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ingresar(Comentario modelo){
            if(ModelState.IsValid){
                string[] meses = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
                string dia = DateTime.Now.Day.ToString();
                int mes = Int32.Parse(DateTime.Now.Month.ToString());
                string anio = DateTime.Now.Year.ToString();
                modelo.fecha = dia + " de " + meses[mes-1] + " del " + anio;
                _context.Comentarios.Add(modelo);
                await _context.SaveChangesAsync();
                return Redirect("/Reggaetons/Details/" + modelo.ReggaetonId);
            }
            return Redirect("/Reggaetons");
        }
        public async Task<IActionResult> eliminar(int id){
            var comentario = await _context.Comentarios.FindAsync(id);
            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return Redirect("/Reggaetons/Details/"+comentario.ReggaetonId);
        }
        public async Task<IActionResult> actualizar(int id, [Bind("id,texto,fecha,ReggaetonId")] Comentario comentario){
            string[] meses = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
            string dia = DateTime.Now.Day.ToString();
            int mes = Int32.Parse(DateTime.Now.Month.ToString());
            string anio = DateTime.Now.Year.ToString();
            string[] valor = comentario.fecha.Split('-');
            if(valor.Length == 2){
                comentario.fecha = valor[0] + " - Editado por ultima vez[ " + dia + " de " + meses[mes-1] + " del " + anio + " ]";
            }else{
                comentario.fecha = comentario.fecha + " - Editado por ultima vez[ " + dia + " de " + meses[mes-1] + " del " + anio + " ]";
            }
            _context.Update(comentario);
            await _context.SaveChangesAsync();
            return Redirect("/Reggaetons/Details/"+comentario.ReggaetonId);
        }
    }
}