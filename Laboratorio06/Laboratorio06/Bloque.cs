using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio06
{
    [Serializable]
    class Bloque : Division
    {
        private static List<Persona> empleados = new List<Persona>();
        public Bloque(string NameBloque, Persona p)
            : base(NameBloque, p)
        {
           
        }
        public static List<Persona> Empleados { get => empleados; set => empleados = value; }
    }
}
