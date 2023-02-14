using IDYGS81_BryanBautista.Context;
using IDYGS81_BryanBautista.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace IDYGS81_BryanBautista.Controllers
{
    public class RolesController : Controller
    {

        private readonly ApplicationDbContext _context;
        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var res = _context.Roles.ToList();
            return View(res);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Rol request)
        {
            try
            {
                Rol roles = new Rol();
                roles.Nombre = request.Nombre;
                roles.Descripcion = request.Descripcion;
                _context.Roles.Add(roles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                var rol = _context.Roles.Find(id);
                return View(rol);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Rol request)
        {
            try
            {
                Rol roles = new Rol();
                roles = _context.Roles.Find(id);
                roles.Nombre = request.Nombre;
                roles.Descripcion = request.Descripcion;
                _context.Roles.Update(roles);
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
                var rol = _context.Roles.Find(id);
                return View(rol);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id, Rol request)
        {
            try
            {
                Rol roles = new Rol();
                roles = _context.Roles.Find(id);
                _context.Roles.Remove(roles);
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
