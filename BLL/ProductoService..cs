﻿using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace BLL
{
    public class ProductoService
    {
        private TiendaContext _TiendaContext;
        public ProductoService(TiendaContext tiendaContext)
        {
            _TiendaContext = tiendaContext;
        }

        public GuardarResponse Guardar(Producto producto)
        {
            try
            {
                var Respuesta = _TiendaContext.productos.Find(producto.Codigo);
                if (Respuesta == null)
                {
                    producto.IdProveedor = producto.Proveedor.IdProveedor;
                    if (_TiendaContext.proveedores.Find(producto.IdProveedor) != null)
                    {
                        producto.CalcularTotal();
                        _TiendaContext.productos.Add(producto);
                    }else{
                        _TiendaContext.proveedores.Add(producto.Proveedor);
                        producto.CalcularTotal();
                        _TiendaContext.productos.Add(producto);
                    }

                    _TiendaContext.SaveChanges();
                    return new GuardarResponse(producto);
                }
                else
                {
                    return new GuardarResponse("Ya se encuentra este producto", "EXISTE");
                }
            }
            catch (Exception e)
            {
                return new GuardarResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        public ActualizarCantidadResponse ActualizarCantidadProducto(int Codigo, int Cantidad){
            ActualizarCantidadResponse actualizarCantidadResponse = new ActualizarCantidadResponse();
            try{
                actualizarCantidadResponse.Error=false;
                actualizarCantidadResponse.Mensaje="Cantidad Actualizada";
                Producto producto = _TiendaContext.productos.Find(Codigo);
                producto.Cantidad=producto.Cantidad-Cantidad;
                _TiendaContext.productos.Update(producto);
                _TiendaContext.SaveChanges();
            } catch(Exception e){
                actualizarCantidadResponse.Error=true;
                actualizarCantidadResponse.Mensaje=$"Hubo un error al momento de actualizar, {e.Message}";
            }
            return actualizarCantidadResponse;
        }

        public class ActualizarCantidadResponse{
            public bool Error{get; set;}
            public string Mensaje{get; set;}
        }

        public class GuardarResponse
        {
            public GuardarResponse(Producto producto)
            {
                Error = false;
                Producto = producto;
            }

            public GuardarResponse(String Message, String Estate)
            {
                Error = true;
                Mensaje = Message;
                Estado = Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public Producto Producto { get; set; }
            public String Estado { get; set; }
        }
    }
}
