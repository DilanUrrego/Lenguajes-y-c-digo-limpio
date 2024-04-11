using Practica2;

namespace practica1
{
    class Program
    {
        static void Main()
        {

            GestorUsuarios gestorUsuarios = new GestorUsuarios();
            GestorCursos gestorCursos = new GestorCursos(gestorUsuarios);
            GestorHorarios gestorHorarios = new GestorHorarios(gestorCursos.cursos);
            ConsultaHorario consultaHorario = new ConsultaHorario(gestorUsuarios, gestorCursos);
            Autenticacion autenticacion = new Autenticacion(gestorUsuarios, gestorCursos, gestorHorarios, consultaHorario);
            InscripcionCursos inscripcionCursos = new InscripcionCursos(gestorCursos);

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("----------");
                Console.WriteLine("1. Registrarse");
                Console.WriteLine("2. Iniciar sesión");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        autenticacion.RegistrarUsuario();
                        break;
                    case "2":
                        autenticacion.IniciarSesion();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                break;
                }
            }
        }
    }
}