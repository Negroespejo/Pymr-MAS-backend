using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Controllers.Models.Almacen.Categoria
{
    public class CrearViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "el nombre es demasiado largo")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
    }
}
