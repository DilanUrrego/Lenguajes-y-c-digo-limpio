using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class Administrativo: Usuario {

        public GestorCursos gestorCursos;
        public InscripcionCursos inscripcionCursos;
        public GestorHorarios gestorHorarios;


        public Administrativo(string Nombre, string Apellido, string UsuarioId, string Contraseña, GestorCursos gestorCursos, InscripcionCursos inscripcionCursos, GestorHorarios gestorHorarios) : base(Nombre, Apellido, UsuarioId, Contraseña)
        {
            this.gestorCursos = gestorCursos;
            this.inscripcionCursos = inscripcionCursos;
            this.gestorHorarios = gestorHorarios;
        }

        public override void MostrarMenu()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Menú del Administrativo:");
                Console.WriteLine("1. Agregar curso");
                Console.WriteLine("2. Asignar profesor a curso");
                Console.WriteLine("3. Asignar estudiantes a curso");
                Console.WriteLine("4. Desinscribir estudiante");
                Console.WriteLine("5. Listar cursos");
                Console.WriteLine("6. Agregar horario a un curso");
                Console.WriteLine("7. Eliminar curso");
                Console.WriteLine("0. Salir");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        gestorCursos.AgregarCurso();
                        break;
                    case "2":
                        gestorCursos.AsignarProfesor();
                        break;
                    case "3":
                        gestorCursos.InscribirEstudiantes();
                        break;
                    case "4":
                        gestorCursos.DesinscribirEstudiante();
                        break;
                    case "5":
                        gestorCursos.ListarCursos();
                        break;
                    case "6":
                        gestorHorarios.AgregarHorarioACurso();
                        break;
                    case "7":
                        gestorCursos.EliminarCurso();
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
