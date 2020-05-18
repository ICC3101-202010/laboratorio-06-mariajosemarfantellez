using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio06
{
    [Serializable]
    class Persona
    {
        private string nombrep;
        private string apellido;
        private string rutp;
        private string cargo;

        public Persona(string nombrep, string apellido, string rutp, string cargo)
        {
            this.Nombrep = nombrep;
            this.Apellido = apellido;
            this.Rutp = rutp;
            this.Cargo = cargo;
        }
        public Persona()
        {

        }
        public string Nombrep { get => nombrep; set => nombrep = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Rutp { get => rutp; set => rutp = value; }
        public string Cargo { get => cargo; set => cargo = value; }
    }
}
