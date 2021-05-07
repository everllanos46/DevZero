using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Proveedor
    {
        [Key]
        public String IdProveedor { get; set; }
        public String Nombre{get; set;}
    }
}