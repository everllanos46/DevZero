using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace BLL
{
    public class UsuarioService
    {

        private TiendaContext _TiendaContext;
        private InteresadoService interesadoService;
        public UsuarioService(TiendaContext tiendaContext)
        {
            _TiendaContext = tiendaContext;
            interesadoService = new InteresadoService(tiendaContext);
        }

        public GuardarResponse Guardar(Usuario usuario)
        {
            try
            {
                var Respuesta = _TiendaContext.usuarios.Find(usuario.Identificacion);
                var RespuestaInteresado = _TiendaContext.interesados.Find(usuario.Identificacion);
                if (Respuesta == null && RespuestaInteresado==null)
                {
                    if (usuario.Rol.Equals("INTERESADO"))
                    {
                        interesadoService.Guardar(usuario);
                    }
                    else
                    {
                        _TiendaContext.usuarios.Add(usuario);
                        _TiendaContext.SaveChanges();
                    }
                    return new GuardarResponse(usuario);
                }
                else
                {
                    return new GuardarResponse("Ya se encuentra este usuario", "EXISTE");
                }
            }
            catch (Exception e)
            {
                return new GuardarResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }






        public class GuardarResponse
        {
            public GuardarResponse(Usuario usuario)
            {
                Error = false;
                Usuario = usuario;
            }

            public GuardarResponse(String Message, String Estate)
            {
                Error = true;
                Mensaje = Message;
                Estado = Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public Usuario Usuario { get; set; }
            public String Estado { get; set; }
        }

    }
}