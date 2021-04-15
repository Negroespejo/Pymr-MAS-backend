using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Almacen
{
    public class Categoria
    {
        public int idcategoria { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "el nombre es demasiado largo")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
        public bool condicion { get; set; }

        public ICollection<Articulo> articulos { get; set; }
        //Declaracion de propiedad "articulo" para obtener articulos segun su categoria especifica       
    }
}
