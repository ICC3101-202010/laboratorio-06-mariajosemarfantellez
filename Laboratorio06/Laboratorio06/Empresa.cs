using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio06
{
    [Serializable]
    class Empresa
    {
        private string nombre;
        private int rut;
        private List<Division> divisiones = new List<Division>();
        public Empresa(string nombre, int rut)
        {
            this.Nombre = nombre;
            this.Rut = rut;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Rut { get => rut; set => rut = value; }

        private static List<Empresa> empresas = new List<Empresa>();
        public static List<Empresa> Empresas { get => empresas; set => empresas = value; }
        public List<Division> Divisiones { get => divisiones; set => divisiones = value; }
    }
}
