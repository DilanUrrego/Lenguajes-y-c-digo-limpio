using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class Curso
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string ProfesorAsignadoId { get; set; }
        public List<string> EstudiantesInscritosIds { get; set; }
        public List<string> Prerrequisitos { get; set; } 
        public List<string> Correquisitos { get; set; } 
        public List<Horario> Horarios { get; set; }
        public Curso(string nombre, string codigo)
        {
            Nombre = nombre;
            Codigo = codigo;
            Horarios = new List<Horario>();
            Prerrequisitos = new List<string>();
            Correquisitos = new List<string>();
            EstudiantesInscritosIds = new List<string>();
        }

        public void AgregarHorario(Horario horario)
        {
            Horarios.Add(horario);
        }
    }
}
