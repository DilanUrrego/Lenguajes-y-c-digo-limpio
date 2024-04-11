using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class GestorHorarios
    {
        public List<Curso> cursos;
        public Dictionary<string, List<Horario>> horariosPorAula; 
        private List<string> dias = ["lunes", "martes", "miercoles", "jueves", "viernes", "sabado"];

        public GestorHorarios(List<Curso> cursos)
        {
            this.cursos = cursos;
            horariosPorAula = new Dictionary<string, List<Horario>>();
        }

        public void AgregarHorarioACurso()
        {
            Console.WriteLine("Ingrese el código del curso al que desea agregar un horario:");
            string codigoCurso = Console.ReadLine();

            Curso curso = cursos.Find(c => c.Codigo == codigoCurso);
            if (curso != null)
            {
                Console.WriteLine("Ingrese el día de la semana (lunes/martes/miercoles/jueves/viernes/sabado/):");
                string dia = Console.ReadLine();
                if (dias.Contains(dia))
                {
                    Console.WriteLine("Ingrese la hora de inicio (en horas, formato de 6 a 20):");
                    if (int.TryParse(Console.ReadLine(), out int horaInicio))
                    {
                        Console.WriteLine("Ingrese la duración de la clase en horas:");
                        if (int.TryParse(Console.ReadLine(), out int duracionHoras))
                        {
                            Console.WriteLine("Ingrese el aula donde se llevará a cabo la clase:");
                            string aula = Console.ReadLine();

                            if (AulaDisponibleEnHorario(aula, dia, horaInicio, duracionHoras))
                            {
                                Horario nuevoHorario = new Horario(dia, horaInicio, duracionHoras, aula);
                                curso.AgregarHorario(nuevoHorario);

                                if (!horariosPorAula.ContainsKey(aula)) 
                                {
                                    horariosPorAula[aula] = new List<Horario>();
                                }
                                horariosPorAula[aula].Add(nuevoHorario);
                                Console.WriteLine("Horario agregado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Horario con solapamiento. Intente nuevamente.");
                            }
                         }
                        else
                        {
                            Console.WriteLine("Duración inválida. Intente nuevamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hora de inicio inválida. Intente nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Día inválido. Intente nuevamente.");
                }
            }
            else
            {
                Console.WriteLine("El curso no existe.");
            }
        }
        public bool AulaDisponibleEnHorario(string aula, string dia, int horaInicio, int duracion)
        {
            if (horariosPorAula.ContainsKey(aula))
            {
                foreach (var horario in horariosPorAula[aula])
                {
                    // Verificar si hay solapamiento de horarios
                    if (horario.Dia == dia && !(horaInicio >= horario.HoraInicio + horario.Duracion || horaInicio + duracion <= horario.HoraInicio))
                    {
                        return false; // Hay solapamiento de horarios
                    }
                }
            }
            return true; // El aula está disponible en el horario especificado

        }
    }
}
