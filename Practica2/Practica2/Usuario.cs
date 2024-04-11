using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public abstract class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UsuarioId { get; set; }
        protected string Contraseña { get; set; }

        public Usuario(string Nombre, string Apellido, string UsuarioId, string Contraseña) 
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.UsuarioId = UsuarioId;
            this.Contraseña = Contraseña;
        }

        public abstract void MostrarMenu();
    }
}
