using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace BLL
{
    public class InteresadoService
    {
        private TiendaContext _TiendaContext;
        public InteresadoService(TiendaContext tiendaContext)
        {
            _TiendaContext = tiendaContext;
        }

        public GuardarResponse Guardar(Usuario usuario){
             try{
                var Respuesta=_TiendaContext.interesados.Find(usuario.Identificacion);
                if(Respuesta==null){
                    Interesado interesado = new Interesado();
                    interesado.Identificacion=usuario.Identificacion;
                    interesado.Nombres=usuario.Nombres;
                    interesado.Apellidos=usuario.Apellidos;
                    interesado.User=usuario.User;
                    interesado.Pass=usuario.Pass;
                    interesado.Sexo=usuario.Sexo;
                    _TiendaContext.interesados.Add(interesado);
                    _TiendaContext.SaveChanges();
                    return new GuardarResponse(interesado);
                } else{
                    return new GuardarResponse("Ya se encuentra este usuario", "EXISTE");
                }
            } catch(Exception e){
                return new GuardarResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        public class GuardarResponse{
            public GuardarResponse(Interesado interesado)
            {
                Error=false;
                Interesado=interesado;
            }

            public GuardarResponse(String Message, String Estate)
            {
                Error=true;
                Mensaje=Message;
                Estado=Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public Interesado Interesado { get; set; }
            public String Estado { get; set; }
        }
        
    }
}