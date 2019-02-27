using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netstandar;

namespace net451
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
