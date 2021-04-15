using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Controllers.Models.Almacen.Categoria
{
    public class CategoriaViewModel
    {
        //Propiedade de la tabla categoria con los metodos GET SET
        public int idcategoria { get; set; }     
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool condicion { get; set; }

    }
}
