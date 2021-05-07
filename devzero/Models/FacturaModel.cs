using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace devzero.Models
{
    public class FacturaInputModel
    {

        public List<DetalleInputModel> DetallesFactura{get; set;}
        public string UsuarioId{get; set;}
        public string InteresadoId{get; set;}
        
    }

    public class FacturaViewModel : FacturaInputModel
    {
        public FacturaViewModel()
        {
            
        }

        public FacturaViewModel(Factura factura)
        {
            UsuarioId=factura.UsuarioId;
            InteresadoId=factura.InteresadoId;
        }

    }
}