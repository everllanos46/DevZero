using Microsoft.AspNetCore.Mvc;
using BLL;
using Entidad;
using Datos;
using devzero.Models;
using Microsoft.AspNetCore.Http;

namespace devzero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _service;

        public UsuarioController(TiendaContext tiendaContext) 
        {
            _service = new UsuarioService(tiendaContext);
        }

        [HttpPost]
        public ActionResult<UsuarioViewModel> GuardarUsuario(UsuarioInputModel usuarioInputModel){
            Usuario usuario = Mapear(usuarioInputModel);
            var Response = _service.Guardar(usuario);
            if(Response.Error){
                ModelState.AddModelError("Error al guardar al usuario", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                if(Response.Estado.Equals("EXISTE")){
                    detalleProblemas.Status=StatusCodes.Status302Found;
                }
                if(Response.Error.Equals("ERROR")){
                    detalleProblemas.Status=StatusCodes.Status500InternalServerError;
                }
                return BadRequest(detalleProblemas);
            }
            Response.Mensaje="Usuario registrado";
            return Ok(Response.Usuario);
        }

        private Usuario Mapear(UsuarioInputModel usuarioInputModel){
            var usuario = new Usuario{
                Identificacion=usuarioInputModel.Identificacion,
                Nombres=usuarioInputModel.Nombres,
                Apellidos=usuarioInputModel.Apellidos,
                Pass=usuarioInputModel.Pass,
                Rol=usuarioInputModel.Rol,
                Sexo=usuarioInputModel.Sexo,
                User=usuarioInputModel.User
            };
            return usuario;
        }
        
    }
}