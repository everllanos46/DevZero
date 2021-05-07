using Microsoft.AspNetCore.Mvc;
using BLL;
using Entidad;
using Datos;
using devzero.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;


namespace devzero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {

        private DetalleService _service;

        public DetalleController(TiendaContext tiendaContext) 
        {
            _service = new DetalleService(tiendaContext);
        }

        [HttpPost]
        public ActionResult<DetalleViewModel> GuardarDetalle(DetalleInputModel detalleInputModel){
            Detalle detalle = Mapear(detalleInputModel);
            var Response = _service.Guardar(detalle);
            if(Response.Error){
                ModelState.AddModelError("Error al guardar al detalle", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                if(Response.Estado.Equals("EXISTE")){
                    detalleProblemas.Status=StatusCodes.Status302Found;
                }
                if(Response.Error.Equals("ERROR")){
                    detalleProblemas.Status=StatusCodes.Status500InternalServerError;
                }
                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Detalle);
        }

        private Detalle Mapear(DetalleInputModel detalleInputModel){
            var detalle = new Detalle{
                CantidadProducto=detalleInputModel.CantidadProducto,
                ProductoId=detalleInputModel.ProductoId
            };
            return detalle;
        }
        
    }
}