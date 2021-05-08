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
    public class ProveedorController : ControllerBase
    {
        
        private ProveedorService _service;

        public ProveedorController(TiendaContext tiendaContext) 
        {
            _service = new ProveedorService(tiendaContext);
            
        }

        [HttpPost]
        public ActionResult<ProveedorViewModel> GuardarProveedor(ProveedorInputModel proveedorInputModel){
            Proveedor proveedor = Mapear(proveedorInputModel);
            var Response = _service.Guardar(proveedor);
            if(Response.Error){
                ModelState.AddModelError("Error al guardar al proveedor", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                if(Response.Estado.Equals("EXISTE")){
                    detalleProblemas.Status=StatusCodes.Status302Found;
                }
                if(Response.Error.Equals("ERROR")){
                    detalleProblemas.Status=StatusCodes.Status500InternalServerError;
                }
                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Proveedor);
        }

        [HttpGet]
        public ActionResult<ProveedorViewModel> ConsultarProveedores( ){
            var Response = _service.ConsultarProveedores();
            if(Response.Error){
                ModelState.AddModelError("Error al consultar los proveedores", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Proveedores);
        }

        private Proveedor Mapear(ProveedorInputModel proveedorInputModel){
            var proveedor = new Proveedor{
                IdProveedor=proveedorInputModel.IdProveedor,
                Nombre=proveedorInputModel.Nombre
            };
            return proveedor;
        }



        
    }
}