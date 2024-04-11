using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class Autenticacion
    {
        private Dictionary<string, string> credenciales; 
        public GestorUsuarios gestorUsuarios;
        public GestorCursos gestorCursos;
        public InscripcionCursos inscripcionCursos;
        public GestorHorarios gestorHorarios;
        public ConsultaHorario consultaHorario;

        public Autenticacion(GestorUsuarios gestorUsuarios, GestorCursos gestorCursos, GestorHorarios gestorHorarios, ConsultaHorario consultaHorario)
        {
            credenciales = new Dictionary<string, string>();
            this.gestorUsuarios = gestorUsuarios;
            this.gestorCursos = gestorCursos;
            this.gestorHorarios = gestorHorarios;
            this.consultaHorario = consultaHorario;
        }

        // Método para registrar un nuevo usuario
        public void RegistrarUsuario()
        {
            Console.WriteLine("Ingrese el nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese el UsuarioId:");
            string usuarioId = Console.ReadLine();

            if (credenciales.ContainsKey(usuarioId))
            {
                Console.WriteLine("El UsuarioId ya existe. Intente nuevamente.");
                return;
            }

            Console.WriteLine("Ingrese la contraseña:");
            string contraseña = Console.ReadLine();

            Console.WriteLine("Especifique el tipo de usuario (1. Estudiante 2.Profesor 3.Administrativo):");
            string tipoUsuario = Console.ReadLine();

            if (tipoUsuario != "1" && tipoUsuario != "2" && tipoUsuario != "3")
            {
                Console.WriteLine("Tipo inválido. Intente de nuevo");
            }
            else if (tipoUsuario == "1")
            {
                Estudiante nuevoEstudiante = new Estudiante(nombre, apellido, usuarioId, contraseña, consultaHorario);
                gestorUsuarios.usuarios.Add(nuevoEstudiante);
            }
            else if (tipoUsuario == "2")
            {
                Profesor nuevoProfesor = new Profesor(nombre, apellido, usuarioId, contraseña, consultaHorario);
                gestorUsuarios.usuarios.Add(nuevoProfesor);
            }
            else if (tipoUsuario == "3")
            {

                Administrativo nuevoAdministrativo = new Administrativo(nombre, apellido, usuarioId, contraseña, gestorCursos, inscripcionCursos, gestorHorarios);
                gestorUsuarios.usuarios.Add(nuevoAdministrativo);
            }


            credenciales[usuarioId] = contraseña;

            Console.WriteLine("Usuario registrado exitosamente.");
        }

        public bool IniciarSesion()
        {
            Console.WriteLine("Ingrese el UsuarioId:");
            string usuarioId = Console.ReadLine();

            Console.WriteLine("Ingrese la contraseña:");
            string contraseña = Console.ReadLine();

            if (credenciales.ContainsKey(usuarioId) && credenciales[usuarioId] == contraseña)
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                Usuario usuarioActual = gestorUsuarios.BuscarUsuario(usuarioId);
                gestorUsuarios.usuarioActual = usuarioActual;
                if (usuarioActual is Estudiante)
                {   
                    Console.WriteLine("Estudiante:");
                }
                else if (usuarioActual is Profesor)
                {
                    Console.WriteLine("Profesor:");
                }
                else if (usuarioActual is Administrativo)
                {
                    Console.WriteLine("Administrativo:");
                }
                usuarioActual.MostrarMenu();
                return true;
            }

            Console.WriteLine("Usuario no encontrado.");
            return false;
        }
    }
}
