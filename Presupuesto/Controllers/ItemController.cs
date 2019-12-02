using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presupuesto.Models;
using Presupuesto.Utils;

namespace Presupuesto.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly PresupuestoContext _context;

        public ItemController(PresupuestoContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Paginator<Item>>> GetItem(int proyectoId, string filter, int page = 1)
        {
            List<Item> _Item;
            Paginator<Item> _PaginadorItem;


            _Item = _context.Item
                .Where(x => x.ProyectoId.Equals(proyectoId)).ToList();

            //Filtering

            if (!string.IsNullOrEmpty(filter))
            {
                foreach (var item in filter.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries))

                    _Item = _Item
                        .Where(x => x.Codigo.StartsWith(item) ||
                                    x.Descripcion.Contains(item)).ToList();
            }

            //Pagination
            int _TotalRegister = 0;
            int _TotalPages = 0;

            _TotalRegister = _Item.Count();

            _Item = _Item.Skip((page - 1) * Constants.NPages)
                                            .Take(Constants.NPages)
                                            .OrderBy(x => x.Codigo)
                                            .OrderBy(x => x.Descripcion)
                                            .ToList();

            _TotalPages = (int)Math.Ceiling((double)_TotalRegister / Constants.NPages);

            _PaginadorItem = new Paginator<Item>()
            {
                RegisterPerPages = Constants.NPages,
                TotalRegister = _TotalRegister,
                TotalPages = _TotalPages,
                CurrentPage = page,
                CurrentFilter = filter,
                Result = _Item

            };

            return _PaginadorItem;
        }


        //GET api/Item/Capitulo
        [HttpGet("Capitulo")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemByCapitulo(int capituloId)
        {
            var List = await _context.Item.ToListAsync();
            List = await _context.Item.Where(i => i.CapituloId.Equals(capituloId)).ToListAsync();
            return List;
        }

        // GET api/Item/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpGet("CostoDirecto")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<int>> GetCostoDirecto(int proyectoId)
        {
            
            var Costos = await _context.Item.Where(i => i.ProyectoId == proyectoId).ToListAsync();
            var CostoDirecto = Costos.Sum(i => i.ValorUnitario * i.Cantidad);
            return CostoDirecto;
        }

        // POST api/Item
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        // PUT api/Item/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid item id");
            var item = _context.Item
                    .Where(i => i.Id == id)
                    .FirstOrDefault();

            _context.Entry(item).State = EntityState.Deleted;
            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}
