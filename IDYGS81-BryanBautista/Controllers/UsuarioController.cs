using IDYGS81_BryanBautista.Context;
using IDYGS81_BryanBautista.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace IDYGS81_BryanBautista.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly ApplicationDbContext _context;
        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var res = _context.Usuarios.ToList();
            return View(res);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuario request)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = request.Nombre;
                usuario.Apellido = request.Apellido;
                usuario.Correo = request.Correo;
                usuario.Password = request.Password;
                usuario.FKRol = request.FKRol;
                _context.Usuarios.Add(usuario);
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
                var usuario = _context.Usuarios.Find(id);
                return View(usuario);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar (int id, Usuario request)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = _context.Usuarios.Find(id);
                usuario.Nombre = request.Nombre;
                usuario.Apellido = request.Apellido;
                usuario.Correo = request.Correo;
                usuario.Password = request.Password;
                usuario.FKRol = request.FKRol;
                _context.Usuarios.Update(usuario);
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
                var usuario = _context.Usuarios.Find(id);
                return View(usuario);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id, Usuario request)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = _context.Usuarios.Find(id);
                _context.Usuarios.Remove(usuario);
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
