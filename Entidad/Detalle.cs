
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class Detalle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string DetalleId { get; set; }
        public int CantidadProducto{get;set;}
        public double Total{get; set;}
        public double Descuento{get; set;}
        public double ValorProducto{get; set;}
        public double TotalDescontado{get; set;}
        public double TotalIVA{get;set;}
        public int ProductoId{get;set;}
        [NotMapped]
        public Producto Producto{get; set;}
        public void CalcularTotalDescontado(){
            TotalDescontado=(ValorProducto*(Descuento/100))*CantidadProducto;
        }

        public void CalcularTotalIVA(){
            TotalIVA=Producto.TotalIva*CantidadProducto;
        }

        public void CalcularTotal(){
            Total=Producto.Total*CantidadProducto;
        }

        public void Calcular(){
            CalcularTotalDescontado();
            CalcularTotalIVA();
            CalcularTotal();
        }

    }
}