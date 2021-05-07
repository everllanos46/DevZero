using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
namespace devzero.Models
{
    public class ProductoInputModel
    {
       public int Codigo{get; set;}
       public String Nombre {get; set;}
       public double Descuento {get; set;}
       public double Iva {get; set;}
    
        public string Description{get;set;}
       public double Precio{get; set;}
  
       public int Cantidad{get; set;}
       public Proveedor Proveedor{get; set;}
    }

    public class ProductoViewModel : ProductoInputModel{
        public ProductoViewModel()
        {
            
        }

        public ProductoViewModel(Producto producto)
        {
            Codigo=producto.Codigo;
            Cantidad=producto.Cantidad;
            Nombre=producto.Nombre;
            Descuento=producto.Descuento;
            Iva=producto.Iva;
            Precio=producto.Precio;
            Proveedor=producto.Proveedor;
            Description=producto.Description;
        }


    }
}