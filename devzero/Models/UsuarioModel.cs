using Entidad;

namespace devzero.Models
{
    public class UsuarioInputModel
    {
        public string Identificacion { get; set; }
        public string Nombres{get; set;}
        public string Apellidos { get; set; }
        public string User { get; set; }
        public string Pass{get; set;}
        public string Rol{get; set;}
        public string Sexo{get; set;}
    }

    public class UsuarioViewModel : UsuarioInputModel
    {
        public UsuarioViewModel()
        {
            
        }

        public UsuarioViewModel(Usuario usuario){
            Identificacion=usuario.Identificacion;
            Nombres=usuario.Nombres;
            Apellidos=usuario.Apellidos;
            User=usuario.User;
            Pass=usuario.Pass;
            Rol=usuario.Rol;
            Sexo=usuario.Sexo;
        }
    }
}