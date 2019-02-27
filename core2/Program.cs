using System;
using netstandar;

namespace core2
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultado = "";
            var xml = new netstandar.XMLUtil();
            xml.Validar(args[0], args[1], out resultado);
            Console.Write(resultado);
        }
    }
}
