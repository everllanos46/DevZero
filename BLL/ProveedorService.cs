using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ProveedorService
    {
        private TiendaContext _TiendaContext;
        public ProveedorService (TiendaContext tiendaContext)
        {
           _TiendaContext=tiendaContext;
        }

        public GuardarResponse Guardar(Proveedor proveedor){
             try{
                var Respuesta=_TiendaContext.proveedores.Find(proveedor.IdProveedor);
                if(Respuesta==null){
                    
                    _TiendaContext.proveedores.Add(proveedor);
                    _TiendaContext.SaveChanges();
                    return new GuardarResponse(proveedor);
                } else{
                    return new GuardarResponse("Ya se encuentra este proveedor", "EXISTE");
                }
            } catch(Exception e){
                return new GuardarResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        public ProveedorConsultarResponse ConsultarProveedores()
        {
            ProveedorConsultarResponse proveedorConsultarResponse = new ProveedorConsultarResponse();
            try
            {
                proveedorConsultarResponse.Error = false;
                proveedorConsultarResponse.Mensaje = "Consultado correctamente";
                proveedorConsultarResponse.Proveedores = _TiendaContext.proveedores.ToList();
            }
            catch (Exception e)
            {
                proveedorConsultarResponse.Error = true;
                proveedorConsultarResponse.Mensaje = $"Hubo un error al momento de consultar, {e.Message}";
                proveedorConsultarResponse.Proveedores =null;
            }
            return proveedorConsultarResponse;
        }

         public class ProveedorConsultarResponse{
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public List<Proveedor> Proveedores{get;set;}
            
        }

        public class GuardarResponse{
            public GuardarResponse(Proveedor proveedor)
            {
                Error=false;
                Proveedor=proveedor;
            }

            public GuardarResponse(String Message, String Estate)
            {
                Error=true;
                Mensaje=Message;
                Estado=Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public Proveedor Proveedor { get; set; }
            public String Estado { get; set; }
        }
    }
}
