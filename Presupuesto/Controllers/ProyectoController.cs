using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presupuesto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Presupuesto.Utils;


namespace Presupuesto.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly PresupuestoContext _context;

        public ProyectoController(PresupuestoContext context)
        {
            _context = context;            
        }
        //GET: api/Proyecto
        [HttpGet]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetProyecto()
        {
            ListResponse<Proyecto> response = new ListResponse<Proyecto>();
            try
            {
                response.Model = await _context.Proyecto.ToListAsync();
                response.Message = "Lista de Proyectos";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = string.Format("There was an internal error, please contact to technical support. {0}", ex.Message);
            }
            return response.ToHttpResponse();
        }

        //GET: api/Proyecto/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetProyectoById(int id)
        {
            SingleResponse<Proyecto> response = new SingleResponse<Proyecto>();
            try
            {
                response.Model = await _context.Proyecto.FindAsync(id);                
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = string.Format("There was an internal error, please contact to technical support. {0}", ex.Message);
            }
            return response.ToHttpResponse();            
        }

        //POST: api/Proyecto
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostProyecto(Proyecto proyecto)
        {
            SingleResponse<Proyecto> response = new SingleResponse<Proyecto>();
            try
            {
                _context.Proyecto.Add(proyecto);
                await _context.SaveChangesAsync();
                response.Model = CreatedAtAction(nameof(GetProyectoById), new { id = proyecto.Id }, proyecto).Value as Proyecto;                
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = string.Format("There was an internal error, please contact to technical support. {0}", ex.Message);
            }
            return response.ToHttpResponse();
            
        }

        //PUT: api/Proyecto/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutProyecto(int id, [FromBody] Proyecto value)
        {
            Response response = new Response();
            try
            {
                Proyecto updatedProyecto = value;
                var selectedElement = _context.Proyecto.Find(id);
                selectedElement.Comentarios = value.Comentarios;
                selectedElement.Contratante = value.Contratante;                
                selectedElement.Fecha_Modificacion = value.Fecha_Modificacion;
                selectedElement.Fecha_Presentacion = value.Fecha_Presentacion;
                selectedElement.Nombre_Obra = value.Nombre_Obra;                                
                selectedElement.Proponente = value.Proponente;                
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

    }

    
    
}
