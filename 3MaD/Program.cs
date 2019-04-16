using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3MaD
{ 
    class Program
    {
    
        static void Main(string[] args)
        {

            Trojuhelnik trojuhelnikTsucc = new Trojuhelnik(new Bod2D(0, 0), new Bod2D(0, 1), new Bod2D(1, 1));
            Trojuhelnik trojuhelnikTfaill = new Trojuhelnik(new Bod2D(0, 0), new Bod2D(0, 10), new Bod2D(0, 5));
            trojuhelnikTsucc.Existuje();
            trojuhelnikTfaill.Existuje();
            Console.WriteLine($"Trojuhelnik Test se sklada ze 3 bodu ");
            Console.ReadKey();

        }
    }
}
