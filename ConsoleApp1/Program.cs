using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teststandar2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var persona = new Persona("Pepe");
            Console.Write(persona.Nombre);
        }
    }
}
