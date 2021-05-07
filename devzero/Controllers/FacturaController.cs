using Microsoft.AspNetCore.Mvc;
using BLL;
using Entidad;
using Datos;
using devzero.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;

namespace devzero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private FacturaService _service;

        public FacturaController(TiendaContext tiendaContext) 
        {
            _service = new FacturaService(tiendaContext);
        }

        [HttpPost]
        public ActionResult<FacturaViewModel> GuardarFactura(FacturaInputModel facturaInputModel){
            Factura factura = Mapear(facturaInputModel);
            var Response = _service.Guardar(factura);
            if(Response.Error){
                ModelState.AddModelError("Error al guardar a la factura", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                if(Response.Estado.Equals("EXISTE")){
                    detalleProblemas.Status=StatusCodes.Status302Found;
                }
                if(Response.Error.Equals("ERROR")){
                    detalleProblemas.Status=StatusCodes.Status500InternalServerError;
                }
                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Mensaje);
        }

        [HttpGet]
        public ActionResult<FacturaViewModel> ConsultarFacturas( ){
            var Response = _service.ConsultarFacturas();
            if(Response.Error){
                ModelState.AddModelError("Error al consultar a las facturas", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Facturas);
        }

        private Factura Mapear(FacturaInputModel facturaInputModel){
            var factura = new Factura{
                UsuarioId=facturaInputModel.UsuarioId,
                DetallesFactura=MapearDetalles(facturaInputModel.DetallesFactura),
                InteresadoId=facturaInputModel.InteresadoId
            };
            return factura;
        }

        private List<Detalle> MapearDetalles(List<DetalleInputModel> detalles){
            List<Detalle> listaDetalles = new List<Detalle>();
            foreach (var item in detalles)
            {
                var detalle = new Detalle{
                    CantidadProducto=item.CantidadProducto,
                    ProductoId=item.ProductoId,
                    ValorProducto=item.ValorProducto,
                    Descuento=item.Descuento
                };
                listaDetalles.Add(detalle);
            }
            return listaDetalles;
        }
        
    }
}