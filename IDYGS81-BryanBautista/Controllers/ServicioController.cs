using IDYGS81_BryanBautista.Context;
using IDYGS81_BryanBautista.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IDYGS81_BryanBautista.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServicioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var res = _context.Servicios.ToList();
            return View(res);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Servicio request)
        {
            try
            {
                Servicio servicio = new Servicio();
                servicio.Titulo= request.Titulo;  
                servicio.Descripcion = request.Descripcion;
                _context.Servicios.Add(servicio);
                await _context.SaveChangesAsync();  
                return RedirectToAction(nameof(Index));


            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }
        
        }

        [HttpGet]
        public IActionResult Editar(int id) {
            try
            {
                var servicio = _context.Servicios.Find(id);
                return View(servicio);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }
        
        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Servicio request)
        {
            try
            {
                Servicio service = new Servicio();
                service = _context.Servicios.Find(id);
                service.Titulo = request.Titulo;
                service.Descripcion = request.Descripcion;
                _context.Servicios.Update(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var servicio = _context.Servicios.Find(id);
                return View(servicio);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id, Servicio request)
        {
            try
            {
                Servicio service = new Servicio();
                service = _context.Servicios.Find(id); 
                _context.Servicios.Remove(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }

    }
}
