using IDYGS81_BryanBautista.Models;
using Microsoft.EntityFrameworkCore;

namespace IDYGS81_BryanBautista.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
