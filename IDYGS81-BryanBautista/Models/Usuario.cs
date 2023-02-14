using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDYGS81_BryanBautista.Models
{
    public class Usuario
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }

        [ForeignKey("Roles")]
        public int FKRol { get; set; }
        public Rol Roles { get; set; }
    }
}
