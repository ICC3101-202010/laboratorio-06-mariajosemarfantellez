using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratorio06
{
    [Serializable]
    class Area : Division
    {
        public Area(string NameArea, Persona p)
            : base(NameArea, p)
        {

        }

    }
}
