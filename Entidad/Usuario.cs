using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Usuario
    {
        [Key]
        public string Identificacion { get; set; }
        public string Nombres{get; set;}
        public string Apellidos { get; set; }
        public string User { get; set; }
        public string Pass{get; set;}
        public string Rol{get; set;}
        public string Sexo{get; set;}
    }
}