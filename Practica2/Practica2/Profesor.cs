using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class Profesor : Usuario
    {
        public List<Curso> CursosAsignados { get; set; }
        public ConsultaHorario consultaHorario;

        public Profesor(string Nombre, string Apellido, string UsuarioId, string Contraseña, ConsultaHorario consultaHorario) : base(Nombre, Apellido, UsuarioId, Contraseña)
        {
            CursosAsignados = new List<Curso>();
            this.consultaHorario = consultaHorario;
        }

        public override void MostrarMenu()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Menú del Estudiante:");
                Console.WriteLine("1. Consultar horario");
                Console.WriteLine("0. Salir");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        consultaHorario.ConsultarHorarios();
                        break;
                    case "0":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;

                }
            }
        }
    }
}
