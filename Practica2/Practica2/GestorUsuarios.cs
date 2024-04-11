using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class GestorUsuarios
    {
        public List<Usuario> usuarios;
        public List<string> profesoresRegistrados;
        public List<string> estudiantesRegistrados;
        public Usuario usuarioActual { get; set; }

        public GestorUsuarios()
        {
            usuarios = new List<Usuario>();
            profesoresRegistrados = new List<string>();
            estudiantesRegistrados = new List<string>();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public Usuario BuscarUsuario(string usuarioId)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.UsuarioId == usuarioId)
                {
                    return usuario;
                }
            }
            return null;
        }
    }
}
