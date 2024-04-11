using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class GestorCursos
    {
        public List<Curso> cursos;
        public GestorUsuarios gestorUsuarios;
        

        public GestorCursos(GestorUsuarios gestorUsuarios)
        {
            cursos = new List<Curso>();
            this.gestorUsuarios = gestorUsuarios;
        }

        public void AgregarCurso()
        {
            Console.WriteLine("Ingrese el nombre del curso:");
            string nombreCurso = Console.ReadLine();

            Console.WriteLine("Ingrese el código del curso:");
            string codigoCurso = Console.ReadLine();

            Curso nuevoCurso = new Curso(nombreCurso, codigoCurso);
            cursos.Add(nuevoCurso);
            Console.WriteLine("Curso agregado correctamente.");
        }

        public void EliminarCurso()
        {
            Console.WriteLine("Ingrese el código del curso a eliminar:");
            string codigoCursoAEliminar = Console.ReadLine();

            Curso cursoAEliminar = cursos.Find(curso => curso.Codigo == codigoCursoAEliminar);
            if (cursoAEliminar != null)
            {
                cursos.Remove(cursoAEliminar);
                Console.WriteLine("Curso eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("El curso no existe.");
            }
        }
        public void ListarCursos()
        {
            Console.WriteLine("Lista de Cursos:");
            foreach (var curso in cursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre}, Código: {curso.Codigo}");
                if (curso.ProfesorAsignadoId != null)
                {
                    Usuario profesor = gestorUsuarios.usuarios.Find(u => u.UsuarioId == curso.ProfesorAsignadoId);
                    Console.WriteLine($"Profesor Asignado: {profesor.Nombre} {profesor.Apellido}");
                }

                if (curso.EstudiantesInscritosIds != null)
                {
                    foreach (var estudianteId in curso.EstudiantesInscritosIds)
                    {
                        Console.WriteLine("Estudiantes inscritos:");
                        Usuario estudiante = gestorUsuarios.usuarios.Find(u => u.UsuarioId == estudianteId);
                        Console.WriteLine($"- {estudiante.Nombre} {estudiante.Apellido} ({estudianteId})");
                    }
                }
                Console.WriteLine();
            }
        }
        public void AsignarProfesor()
        {
            Console.WriteLine("Ingrese el código del curso:");
            string codigoCurso = Console.ReadLine();

            Curso curso = cursos.Find(c => c.Codigo == codigoCurso);
            if (curso != null)
            {
                Console.WriteLine("Ingrese el UsuarioId del profesor:");
                string usuarioIdProfesor = Console.ReadLine();

                if (gestorUsuarios.profesoresRegistrados.Contains(usuarioIdProfesor))
                {
                    curso.ProfesorAsignadoId = usuarioIdProfesor;
                    Console.WriteLine("Profesor asignado correctamente al curso.");
                }
                else
                {
                    Console.WriteLine("El UsuarioId proporcionado no corresponde a un profesor registrado.");
                }
            }
            else
            {
                Console.WriteLine("El curso no existe.");
            }
        }
        
        public Curso ObtenerCursoPorCodigo(string codigoCurso)
        {
            return cursos.Find(curso => curso.Codigo == codigoCurso);
        }



        public void InscribirEstudiantes()
        {
            Console.WriteLine("Ingrese el número de estudiantes que desea ingresar:");
            int.TryParse(Console.ReadLine(), out int nEstudiantes);


            Console.WriteLine("Ingrese el código del curso:");
            string cursoCodigo = Console.ReadLine();

            for (int i = 0; i < nEstudiantes; i++)
            {

                Console.WriteLine("Ingrese el ID del estudiante:");
                string estudianteId = Console.ReadLine();

                Curso curso = ObtenerCursoPorCodigo(cursoCodigo);
                if (curso != null)
                {
                    curso.EstudiantesInscritosIds.Add(estudianteId);
                    Console.WriteLine($"Estudiante {estudianteId} inscrito en {cursoCodigo}.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el curso {cursoCodigo}.");
                }
            }
        }
        public void DesinscribirEstudiante()
        {

            Console.WriteLine("Ingrese el código del curso:");
            string cursoCodigo = Console.ReadLine();

            Console.WriteLine("Ingrese el ID del estudiante:");
            string estudianteId = Console.ReadLine();


            Curso curso = ObtenerCursoPorCodigo(cursoCodigo);
            if (curso != null)
            {
                if (curso.EstudiantesInscritosIds.Contains(estudianteId))
                {
                    curso.EstudiantesInscritosIds.Remove(estudianteId);
                    Console.WriteLine($"Estudiante {estudianteId} desinscrito del curso {cursoCodigo}.");
                }
                else
                {
                    Console.WriteLine($"El estudiante {estudianteId} no está inscrito en el curso {cursoCodigo}.");
                }
            }
            else
            {
                Console.WriteLine($"No se encontró el curso con el código {cursoCodigo}.");
            }
        }
    }
}
