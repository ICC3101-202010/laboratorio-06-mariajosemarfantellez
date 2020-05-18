using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio06
{
    [Serializable]
    class Departamento : Division
    {
        public Departamento(string NameDepa, Persona p)
            : base(NameDepa, p)
        {

        }
    }
}
