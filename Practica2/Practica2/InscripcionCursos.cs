using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class InscripcionCursos
    {
        public GestorCursos gestorCursos;
        public InscripcionCursos(GestorCursos gestorCursos)
        {
            this.gestorCursos = gestorCursos;   
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
        public Curso ObtenerCursoPorCodigo(string codigo)
        {
            {
                foreach (var curso in gestorCursos.cursos)
                {
                    if (curso.Codigo == codigo)
                    {
                        return curso;
                    }
                }
                return null;
            }
        }
    }   
}
