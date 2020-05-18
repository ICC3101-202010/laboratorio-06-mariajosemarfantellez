using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;

namespace Laboratorio06
{
    class Program
    {
        List<Empresa> empresas = new List<Empresa>();
        static private void SaveEmpresa(List<Empresa> empresas)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, empresas);
            stream.Close();
        }
        static private List<Empresa> LoadEmpresa()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Empresa> empresas = (List<Empresa>)formatter.Deserialize(stream);
            stream.Close();
            return empresas;
        }
        static void Main(string[] args)
        {
            bool i = true;
            while (i != false)
            {
                List<Empresa> empresas = new List<Empresa>();
                Console.WriteLine("Desea utilizar un archivo para cargar la información?(si o no) o presione cualquier tecla para salir");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "no")
                {
                    Console.WriteLine("Diga el nombre de la empresa");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Diga el rut de la empresa sin punto ni guión");
                    int rut = -1;
                    while (rut == -1)
                    {
                        try
                        {
                            rut = int.Parse(Console.ReadLine());
                            if (rut < 1)
                            {
                                Console.WriteLine("Ingrese un rut valido");
                                rut = -1;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formato invalido\nIngrese un numero como rut");
                        }
                    }
                    Empresa e1 = new Empresa(nombre, rut);
                    Console.Clear();

                    Console.WriteLine("Ingrese el nombre del área");
                    string narea = Console.ReadLine();
                    Console.WriteLine("Desea usted crear a la persona del área?(si / no) Si dice que no, se creará automáticamente");
                    string r = Console.ReadLine();
                    if (r.ToLower() == "si")
                    {
                        Console.WriteLine("Ingrese el nombre de la persona del área");
                        string nparea = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido de la persona del área");
                        string aparea = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut de la persona del área");
                        string rparea = Console.ReadLine();
                        Console.WriteLine("Ingrese el cargo de la persona del área");
                        string cparea = Console.ReadLine();
                        Persona p0 = new Persona(nparea, aparea, rparea, cparea);
                        Area a1 = new Area(narea, p0);
                        e1.Divisiones.Add(a1);
                    }
                    if (r.ToLower() == "no")
                    {
                        Persona p0 = new Persona("Maria", "Marfan", "200873505", "jefe area");
                        Area a1 = new Area(narea, p0);
                        e1.Divisiones.Add(a1);
                    }
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre del departamento");
                    string ndepa = Console.ReadLine();
                    Console.WriteLine("Desea usted crear a la persona del departamento?(si / no) Si dice que no, se creará automáticamente");
                    string r1 = Console.ReadLine();
                    if (r1.ToLower() == "si")
                    {
                        Console.WriteLine("Ingrese el nombre de la persona del departamento");
                        string npdepa = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido de la persona del departamento");
                        string apdepa = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut de la persona del departamento");
                        string rpdepa = Console.ReadLine();
                        Console.WriteLine("Ingrese el cargo de la persona del departamento");
                        string cpdepa = Console.ReadLine();
                        Persona p1 = new Persona(npdepa, apdepa, rpdepa, cpdepa);
                        Departamento d1 = new Departamento(ndepa, p1);
                        e1.Divisiones.Add(d1);
                    }
                    if (r1.ToLower() == "no")
                    {
                        Persona p1 = new Persona("Ignacio", "Correa", "198723407", "jefe departamento");
                        Departamento d1 = new Departamento(ndepa, p1);
                        e1.Divisiones.Add(d1);
                    }
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre de la seccion");
                    string nsecc = Console.ReadLine();
                    Console.WriteLine("Desea usted crear a la persona de la seccion?(si / no) Si dice que no, se creará automáticamente");
                    string r2 = Console.ReadLine();
                    if (r2.ToLower() == "si")
                    {
                        Console.WriteLine("Ingrese el nombre de la persona de la seccion");
                        string npsecc = Console.ReadLine();
                        Console.WriteLine("Ingrese el apelllido de la persona de la seccion");
                        string apsecc = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut de la persona de la seccion");
                        string rpsecc = Console.ReadLine();
                        Console.WriteLine("Ingrese el cargo de la persona de la seccion");
                        string cpsecc = Console.ReadLine();
                        Persona p2 = new Persona(npsecc, apsecc, rpsecc, cpsecc);
                        Seccion s1 = new Seccion(nsecc, p2);
                        e1.Divisiones.Add(s1);
                    }
                    if (r2.ToLower() == "no")
                    {
                        Persona p2 = new Persona("Lucia", "Tellez", "93661358", "jefe de seccion");
                        Seccion s1 = new Seccion(nsecc, p2);
                        e1.Divisiones.Add(s1);
                    }
                    Console.Clear();
                    Console.WriteLine("A los empleados de los bloques deberá crearlos usted");
                    int m = 0;
                    while (m < 2)
                    {
                        Console.WriteLine("Ingrese el nombre del bloque");
                        string nbloq = Console.ReadLine();
                        Console.Clear();
                        int o = 0;
                        while(o<2)
                        {
                            Console.WriteLine("Ingrese el nombre del empleado del bloque "+nbloq);
                            string n = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del empleado del bloque "+nbloq);
                            string a = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del empleado del bloque "+nbloq);
                            string rp = Console.ReadLine();
                            Console.WriteLine("Ingrese el cargo del empleado del bloque "+nbloq);
                            string c = Console.ReadLine();
                            Persona p4 = new Persona(n, a, rp, c);
                            Bloque.Empleados.Add(p4);
                            Console.Clear();
                            Bloque b1 = new Bloque(nbloq, p4);
                            e1.Divisiones.Add(b1);
                            o++;
                        }
                        m++;
                    }
                    Empresa.Empresas.Add(e1);
                    SaveEmpresa(Empresa.Empresas);
                }
                if (respuesta.ToLower() == "si")
                {
                    try
                    {
                        empresas = LoadEmpresa();
                        Empresa.Empresas = empresas;
                        foreach(Empresa mj in empresas)
                        {
                            Console.WriteLine("El nombre de la empresa es "+ mj.Nombre);
                            Thread.Sleep(1000);
                            Console.WriteLine("El rut de la empresa es "+ mj.Rut);
                            Thread.Sleep(1000);
                            foreach (Division mjj in mj.Divisiones)
                            {   
                                Console.Clear();
                                Console.WriteLine("El nombre de la division es " + mjj.Name);
                                Thread.Sleep(1000);
                                Console.WriteLine("El nombre del empleado es "+mjj.empleado.Nombrep);
                                Thread.Sleep(1000);
                                Console.WriteLine("El apellido del empleado es "+mjj.empleado.Apellido);
                                Thread.Sleep(1000);
                                Console.WriteLine("El rut del empleado es "+mjj.empleado.Rutp);
                                Thread.Sleep(1000);
                                Console.WriteLine("El cargo del empleado es "+mjj.empleado.Cargo);
                                Thread.Sleep(1000);  
                            }
                        }

                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("El archivo no existe, diga el nombre de la empresa");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Diga el rut de la empresa sin punto ni guión");
                        int rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut valido");
                                    rut = -1;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut");
                            }
                        }
                        Empresa e1 = new Empresa(nombre, rut);
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre del área");
                        string narea = Console.ReadLine();
                        Console.WriteLine("Desea usted crear a la persona del área?(si / no) Si dice que no, se creará automáticamente");
                        string rr = Console.ReadLine();
                        if (rr.ToLower() == "si") 
                        {
                            Console.WriteLine("Ingrese el nombre de la persona del área");
                            string nparea = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido de la persona del área");
                            string aparea = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut de la persona del área");
                            string rparea = Console.ReadLine();
                            Console.WriteLine("Ingrese el cargo de la persona del área");
                            string cparea = Console.ReadLine();
                            Persona p0 = new Persona(nparea, aparea, rparea, cparea);
                            Area a1 = new Area(narea, p0);
                            e1.Divisiones.Add(a1);
                        }
                        if (rr.ToLower() == "no")
                        {
                            Persona p0 = new Persona("Maria", "Marfan", "200873505", "jefe area");
                            Area a1 = new Area(narea, p0);
                            e1.Divisiones.Add(a1);
                        }
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre del departamento");
                        string ndepa = Console.ReadLine();
                        Console.WriteLine("Desea usted crear a la persona del departamento?(si / no) Si dice que no, se creará automáticamente");
                        string rrd = Console.ReadLine();
                        if (rrd.ToLower() == "si")
                        {
                            Console.WriteLine("Ingrese el nombre de la persona del departamento");
                            string npdepa = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido de la persona del departamento");
                            string apdepa = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut de la persona del departamento");
                            string rpdepa = Console.ReadLine();
                            Console.WriteLine("Ingrese el cargo de la persona del departamento");
                            string cpdepa = Console.ReadLine();
                            Persona p1 = new Persona(npdepa, apdepa, rpdepa, cpdepa);
                            Departamento d1 = new Departamento(ndepa, p1);
                            e1.Divisiones.Add(d1);
                        }
                        if (rrd.ToLower() == "no")
                        {
                            Persona p1 = new Persona("Ignacio", "Correa", "198723407", "jefe departamento");
                            Departamento d1 = new Departamento(ndepa, p1);
                            e1.Divisiones.Add(d1);
                        }
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre de la seccion");
                        string nsecc = Console.ReadLine();
                        Console.WriteLine("Desea usted crear a la persona de la seccion?(si / no) Si dice que no, se creará automáticamente");
                        string rrs = Console.ReadLine();
                        if (rrs.ToLower() == "si")
                        {
                            Console.WriteLine("Ingrese el nombre de la persona de la seccion");
                            string npsecc = Console.ReadLine();
                            Console.WriteLine("Ingrese el apelllido de la persona de la seccion");
                            string apsecc = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut de la persona de la seccion");
                            string rpsecc = Console.ReadLine();
                            Console.WriteLine("Ingrese el cargo de la persona de la seccion");
                            string cpsecc = Console.ReadLine();
                            Persona p2 = new Persona(npsecc, apsecc, rpsecc, cpsecc);
                            Seccion s1 = new Seccion(nsecc, p2);
                            e1.Divisiones.Add(s1);
                        }
                        if (rrs.ToLower() == "no")
                        {
                            Persona p2 = new Persona("Lucia", "Tellez", "93661358", "jefe de seccion");
                            Seccion s1 = new Seccion(nsecc, p2);
                            e1.Divisiones.Add(s1);
                        }
                        Console.Clear();
                        Console.WriteLine("A los empleados de los bloques deberá crearlos usted");
                        int m = 0;
                        while (m < 2)
                        {
                            Console.WriteLine("Ingrese el nombre del bloque");
                            string nbloq = Console.ReadLine();
                            Console.Clear();
                            int o = 0;
                            while (o < 2)
                            {   
                                Console.WriteLine("Ingrese el nombre del empleado del bloque "+nbloq);
                                string n = Console.ReadLine();
                                Console.WriteLine("Ingrese el apellido del empleado del bloque "+nbloq);
                                string a = Console.ReadLine();
                                Console.WriteLine("Ingrese el rut del empleado del bloque "+nbloq);
                                string r = Console.ReadLine();
                                Console.WriteLine("Ingrese el cargo del empleado del bloque "+nbloq);
                                string c = Console.ReadLine();
                                Persona p4 = new Persona(n, a, r, c);
                                Bloque.Empleados.Add(p4);
                                Console.Clear();
                                Bloque b1 = new Bloque(nbloq, p4);
                                e1.Divisiones.Add(b1);
                                o++;

                            }
                            m++;
                        }
                        Empresa.Empresas.Add(e1);
                        SaveEmpresa(Empresa.Empresas);
                    }
                }
                else { Console.WriteLine("Opción inválida cerrando el programa\n");  i = false; }
            }
        }
    }
}
