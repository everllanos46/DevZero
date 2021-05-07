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
    public class ProductoController : ControllerBase
    {
        

        private ProductoService _service;

        public ProductoController(TiendaContext tiendaContext) 
        {
            _service = new ProductoService(tiendaContext);
        }

        [HttpPost]
        public ActionResult<ProductoViewModel> GuardarProducto(ProductoInputModel productoInputModel){
            Producto producto = Mapear(productoInputModel);
            var Response = _service.Guardar(producto);
            if(Response.Error){
                ModelState.AddModelError("Error al guardar al producto", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                if(Response.Estado.Equals("EXISTE")){
                    detalleProblemas.Status=StatusCodes.Status302Found;
                }
                if(Response.Error.Equals("ERROR")){
                    detalleProblemas.Status=StatusCodes.Status500InternalServerError;
                }
                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Producto);
        }

        [HttpGet]
        public ActionResult<ProductoViewModel> ConsultarProductos( ){
            var Response = _service.ConsultarProductos();
            if(Response.Error){
                ModelState.AddModelError("Error al consultar productos", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Productos);
        }

        [HttpPut("producto")]
         public ActionResult<ProductoViewModel> ActualizarCantidad(int codigo, int cantidad){
            var Response = _service.ActualizarCantidadProducto(codigo, cantidad);
            if(Response.Error){
                ModelState.AddModelError("Error al actualizar la cantidad", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            return Ok(Response);
        }

        private Producto Mapear(ProductoInputModel productoInputModel){
            var producto = new Producto{
                Codigo=productoInputModel.Codigo,
                Descuento=productoInputModel.Descuento,
                Iva=productoInputModel.Iva,
                Nombre=productoInputModel.Nombre,
                Precio=productoInputModel.Precio,
                Proveedor=productoInputModel.Proveedor,
                Cantidad=productoInputModel.Cantidad,
                Description=productoInputModel.Description

            };
            return producto;
        }
    }
}