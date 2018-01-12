using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaTecla.Services;

namespace SantaTecla.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Comprobar();
            System.Console.ReadKey();
        }

        private async static void Comprobar()
        {
            SantaTeclaService service = new SantaTeclaService();
            var respuesta = Console.ReadLine();
            if (respuesta == "2")
            {
                var test = await service.AuthUser("farmacia", "098");
                if (test != null)
                {
                    System.Console.WriteLine($"Logue");
                }
                
            }
        }


    }
}
