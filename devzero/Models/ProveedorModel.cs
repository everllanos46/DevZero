using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace devzero.Models
{
    public class ProveedorInputModel
    {
        public String IdProveedor { get; set; }
        public String Nombre{get; set;}
       
    }

    public class ProveedorViewModel : ProveedorInputModel{
        public ProveedorViewModel()
        {
            
        }

        public ProveedorViewModel(Proveedor proveedor)
        {
            IdProveedor = proveedor.IdProveedor;
            Nombre = proveedor.Nombre;
            
        }
    }
}