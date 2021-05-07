using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entidad
{
    public class Factura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string FacturaId { get; set; }
        public double Total{get; set;}
        public double TotalDescontado{get; set;}
        public double TotalIVA{get; set;}
        public List<Detalle> DetallesFactura{get; set;}
        public string UsuarioId{get; set;}
        [NotMapped]
        public Usuario Usuario{get; set;}
        public string InteresadoId{get; set;}
        [NotMapped]
        public Interesado Interesado{get; set;}


        public void CalcularTotal(){
           Total=DetallesFactura.Sum(d=>d.Total);
        }
        public void CalcularTotalDescontado(){
            TotalDescontado=DetallesFactura.Sum(d=>d.TotalDescontado);
        }

        public void CalcularTotalIVA(){
            TotalIVA=DetallesFactura.Sum(d=>d.TotalIVA);
        }
        
    }
}