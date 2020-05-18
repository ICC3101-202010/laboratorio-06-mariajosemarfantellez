using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio06
{
    [Serializable]
    class Seccion : Division
    {
        public Seccion(string NameSeccion, Persona p)
             : base(NameSeccion, p)
        {

        }
    }
}
