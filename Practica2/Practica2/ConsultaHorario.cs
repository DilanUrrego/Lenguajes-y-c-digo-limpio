using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class ConsultaHorario
    {
        public GestorUsuarios gestorUsuarios;
        public GestorCursos gestorCursos;
        
        public ConsultaHorario(GestorUsuarios gestorUsuarios ,GestorCursos gestorCursos)
        {
            this.gestorUsuarios = gestorUsuarios;
            this.gestorCursos = gestorCursos;
        }

        public void ConsultarHorarios()
        {
            if (gestorUsuarios.usuarioActual is Estudiante)
            {
                Estudiante estudiante = (Estudiante)gestorUsuarios.usuarioActual;

                Console.WriteLine($"Horarios del estudiante {estudiante.Nombre} {estudiante.Apellido}:");

                foreach (Curso curso in estudiante.CursosInscritos)
                {
                    Curso cursoEncontrado = gestorCursos.ObtenerCursoPorCodigo(curso.Codigo);
                    if (cursoEncontrado != null)
                    {
                        Console.WriteLine($"Horario del curso {cursoEncontrado.Nombre} ({cursoEncontrado.Codigo}):");
                        foreach (Horario horario in cursoEncontrado.Horarios)
                        {
                            Console.WriteLine($"- Día: {horario.Dia}, Hora: {horario.HoraInicio}-{horario.HoraInicio+horario.Duracion}");
                        }
                    }
                }
            }
            if (gestorUsuarios.usuarioActual is Profesor)
            {
                Profesor profesor = (Profesor)gestorUsuarios.usuarioActual;
                Console.WriteLine($"Horarios del profesor {profesor.Nombre} {profesor.Apellido}:");

                foreach (Curso curso in profesor.CursosAsignados)
                {
                    Curso cursoEncontrado = gestorCursos.ObtenerCursoPorCodigo(curso.Codigo);
                    if (cursoEncontrado != null)
                    {
                        Console.WriteLine($"Horario del curso {cursoEncontrado.Nombre} ({cursoEncontrado.Codigo}):");
                        foreach (Horario horario in cursoEncontrado.Horarios)
                        {
                            Console.WriteLine($"- Día: {horario.Dia}, Hora: {horario.HoraInicio}-{horario.HoraInicio + horario.Duracion}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No se pudo consultar el horario.");
            }
        }
    }
}

