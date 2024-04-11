using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class Horario
    {
        public string Dia { get; set; }
        public int HoraInicio { get; set; }
        public int Duracion { get; set; }
        public string Aula { get; set; }

        public Horario(string dia, int horaInicio, int duracion, string aula)
        {
            Dia = dia;
            HoraInicio = horaInicio;
            Duracion = duracion;
            Aula = aula;
        }
    }
}
