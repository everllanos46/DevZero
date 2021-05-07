using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace devzero.Models
{
    public class DetalleInputModel
    {

        public int CantidadProducto{get;set;}
        public int ProductoId{get;set;}
        public double Descuento{get; set;}
        public double ValorProducto{get; set;}
    }

    public class DetalleViewModel : DetalleInputModel{

        public DetalleViewModel()
        {
            
        }
        public DetalleViewModel(Detalle detalle )
        {
            CantidadProducto=detalle.CantidadProducto;
            ProductoId=detalle.ProductoId;
            Descuento=detalle.Descuento;
            ValorProducto=detalle.ValorProducto;
        }
    }
}