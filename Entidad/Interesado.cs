using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entidad
{
    public class Interesado 
    {
         [Key]
        public string Identificacion { get; set; }
        public string Nombres{get; set;}
        public string Apellidos { get; set; }
        public string User { get; set; }
        public string Pass{get; set;}
        public string Sexo{get; set;}
        [NotMapped]
        public List<Factura> Facturas { get; set; }
        
    }
}