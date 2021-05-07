using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace BLL
{
    public class FacturaService
    {
        private TiendaContext _TiendaContext;
        public FacturaService(TiendaContext tiendaContext)
        {
            _TiendaContext = tiendaContext;
        }

        public GuardarResponse Guardar(Factura factura){
             try{
                var Respuesta=_TiendaContext.proveedores.Find(factura.FacturaId);
                if(Respuesta==null){
                    foreach (var item in factura.DetallesFactura)
                    {
                        if(_TiendaContext.productos.Find(item.ProductoId)==null) return new GuardarResponse("No se encuentra este producto", "ERROR");
                        else{
                            item.Producto=_TiendaContext.productos.Find(item.ProductoId);
                            if(item.Producto.Cantidad<item.CantidadProducto) return new GuardarResponse("No hay suficientes unidades", "ERROR");
                            item.Calcular();
                        }
                    }
                    if(_TiendaContext.usuarios.Find(factura.UsuarioId)==null) return new GuardarResponse("No se encuentra este usuario", "ERROR");
                    factura.Interesado=_TiendaContext.interesados.Find(factura.InteresadoId);
                    factura.CalcularTotalDescontado();
                    factura.CalcularTotalIVA();
                    factura.CalcularTotal();
                    _TiendaContext.facturas.Add(factura);
                    _TiendaContext.SaveChanges();
                    return new GuardarResponse(factura);
                } else  return new GuardarResponse("Ya se encuentra esta factura", "EXISTE");
            } catch(Exception e){
                return new GuardarResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        public class FacturaConsultarResponse{
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public List<Factura> Facturas{get;set;}
            
        }



        public class GuardarResponse
        {
            public GuardarResponse(Factura factura)
            {
                Error = false;
                Factura = factura;
            }

            public GuardarResponse(String Message, String Estate)
            {
                Error = true;
                Mensaje = Message;
                Estado = Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public Factura Factura { get; set; }
            public String Estado { get; set; }
        }
        
    }
}