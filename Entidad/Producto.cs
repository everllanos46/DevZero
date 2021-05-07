using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Producto
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Codigo{get; set;}
       public String Nombre {get; set;}
       public String Description{get; set;}
       public String Fecha{get; set;}
       public double Descuento {get; set;}
       public double Iva {get; set;}
       public double TotalDescuento {get; set;}
       public double TotalIva{get; set;}
       public double Precio{get; set;}
       public double Total{get; set;}
       public int Cantidad{get; set;}
       public String IdProveedor{get; set;}
       [NotMapped]
       public Proveedor Proveedor{get; set;}

       public void CalcularDescuento(){
           TotalDescuento = Precio * (Descuento/100);
       }

       public void CalcularIVA(){
           TotalIva = Precio  * (Iva/100);
       }

       public void CalcularTotal(){
           CalcularDescuento();
           CalcularIVA();
           Total = Precio - Descuento;
           Total =Total+TotalIva;
       }

       public void Date(){
           Fecha= DateTime.Now.ToShortDateString();
       }
    }
}
