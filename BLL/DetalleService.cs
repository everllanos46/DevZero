using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace BLL
{
    public class DetalleService
    {

        private TiendaContext _TiendaContext;
        public DetalleService(TiendaContext tiendaContext)
        {
            _TiendaContext = tiendaContext;
        }

        public GuardarResponse Guardar(Detalle detalle)
        {
            try
            {
                var Respuesta = _TiendaContext.detalles.Find(detalle.DetalleId);
                if (Respuesta == null)
                {
                    Producto producto = _TiendaContext.productos.Find(detalle.ProductoId);
                    if (producto != null)
                    {
                        if (detalle.CantidadProducto > producto.Cantidad)
                        {
                            return new GuardarResponse("No hay suficiente cantidad de este producto", "INSUFICIENTE");
                        }
                        else
                        {
                            detalle.Producto = _TiendaContext.productos.Find(detalle.ProductoId);
                            detalle.Producto.Proveedor=_TiendaContext.proveedores.Find(detalle.Producto.IdProveedor);
                            detalle.Calcular();
                            _TiendaContext.detalles.Add(detalle);
                            _TiendaContext.SaveChanges();
                            return new GuardarResponse(detalle);
                        }
                    }
                    else
                    {
                        return new GuardarResponse("No se encuentra este detalle", "EXISTE");
                    }


                }
                else
                {
                    return new GuardarResponse("Ya se encuentra este detalle", "EXISTE");
                }
            }
            catch (Exception e)
            {
                return new GuardarResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        public class GuardarResponse
        {
            public GuardarResponse(Detalle detalle)
            {
                Error = false;
                Detalle = detalle;
            }

            public GuardarResponse(String Message, String Estate)
            {
                Error = true;
                Mensaje = Message;
                Estado = Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public Detalle Detalle { get; set; }
            public String Estado { get; set; }
        }

    }
}