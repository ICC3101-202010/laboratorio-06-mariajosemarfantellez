using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio06
{
    [Serializable]
    class Division
    {
        private string name;
        public Persona empleado = new Persona();
        public Division(string name, Persona empleado)
        {
            this.Name = name;
            this.empleado = empleado;
        }
        public string Name { get => name; set => name = value; }
    }
}
