using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Almacen;
using Sistema.Web.Controllers.Models.Almacen.Categoria;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")] // RUTA DE ACCESO
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CategoriasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Categorias/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaViewModel>> Listar()
        {
            // se utlilza la coleecion expuesta en el contexto
            var categoria = await _context.Categorias.ToListAsync(); //metodo ToListAsync() para liberar hilo principal de ejecucion
            // El return sigue la estructura del ViewModel
            return categoria.Select(c => new CategoriaViewModel
            {
                idcategoria = c.idcategoria,
                nombre = c.nombre,
                descripcion = c.descripcion,
                condicion = c.condicion
            });

        }

        // GET: api/Categorias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id) // se debe entrear el ID la llamado por que es parte de la ruta
        {
            //FndAsync: metodo para realiar busqueda
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new CategoriaViewModel {

                idcategoria = categoria.idcategoria,
                nombre = categoria.nombre,
                descripcion = categoria.descripcion,
                condicion = categoria.condicion

            });
        }

        // PUT: api/Categorias/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        // este metodo entrega el objeto completo
        {
            if (!ModelState.IsValid) // validar modelo
            {
                return BadRequest(ModelState);
            }

            if (model.idcategoria <= 0) // validar ID
            {
                return BadRequest();
            }

            // metodo FisrtOrDefaultAsync compreva que la categoria exista
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == model.idcategoria);

            // validar categoria no es nula
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.nombre = model.nombre;
            categoria.descripcion = model.descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //capturar excepcion
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Categorias/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid) // Validacion de DataAnnotations de CrearViewModel
            {
                return BadRequest(ModelState);
            }

            Categoria categoria = new Categoria
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                condicion = true,
            };
          
            _context.Categorias.Add(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
            return Ok();
        }

        // DELETE: api/Categorias/Eliminar/1
        [HttpDelete("[action]/{id}")] // Este metodo se puede mejorar con un docket
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
;               return BadRequest();
            }

            

            return Ok(categoria);
        }

        // PUT: api/Categorias/Desactivar/1
        [HttpPut("[action]/{id}")] //
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {
           
            if (id<= 0) // validar ID
            {
                return BadRequest();
            }

            // metodo FisrtOrDefaultAsync compreva que la categoria exista
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == id);

            // validar categoria no es nula
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.condicion = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //capturar excepcion
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Categorias/Activar/1
        [HttpPut("[action]/{id}")] //
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0) // validar ID
            {
                return BadRequest();
            }

            // metodo FisrtOrDefaultAsync compreva que la categoria exista
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == id);

            // validar categoria no es nula
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.condicion = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //capturar excepcion
                return BadRequest();
            }

            return Ok();
        }


        // GET: api/Categorias/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            // se utlilza la coleecion expuesta en el contexto
            var categoria = await _context.Categorias.Where(c=> c.condicion==true).ToListAsync(); //metodo ToListAsync() para liberar hilo principal de ejecucion
            // El return sigue la estructura del ViewModel
            return categoria.Select(c => new SelectViewModel
            {
                idcategoria = c.idcategoria,
                nombre = c.nombre,
           
            });

        }


        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.idcategoria == id);
        }
    }
}