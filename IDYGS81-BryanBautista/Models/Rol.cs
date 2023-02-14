using System.ComponentModel.DataAnnotations;

namespace IDYGS81_BryanBautista.Models
{
    public class Rol
    {
        [Key]
        public int PkRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
