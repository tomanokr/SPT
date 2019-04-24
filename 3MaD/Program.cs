using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3MaD
{ 
    class Program
    {
        static bool Nacteni(ref double[] souradnice)
        {
            // metoda nacitani souradnic bodu ze vstupu
            Console.WriteLine("Zadejte souradnice bodu trojuhelnika: ");
            for (byte i = 0; i < 6; i++)
            {
                switch(i)
                {
                    case 0:
                        Console.WriteLine();
                        Console.WriteLine("Zadejte souradnice bodu A:");
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Zadejte souradnice bodu B:");
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Zadejte souradnice bodu C:");
                        break;
                }
                string param = string.Empty;
                if(i % 2 == 0)
                {
                    param = "X: ";
                }
                else
                {
                    param = "Y: ";
                }
                byte pokus = 0;
                while (pokus < 3)
                {
                    Console.Write(param);
                    if (double.TryParse(Console.ReadLine(), out souradnice[i]))
                    {
                        pokus = 0;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Spatne zadany vstup. Pokus {pokus+1}/3");
                        pokus++;
                    }
                }
                if (pokus == 3)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            bool bezim = true;
            while (bezim)
            {
                Console.WriteLine("---------------------- PROGRAM SESTROJITELNOSTI TROJUHELNIKA ----------------------");
                Console.WriteLine();
                Console.WriteLine();
                double[] souradnice = new double[6]; // pole pro ukladani souradnic ze vstupu       
                if (Nacteni(ref souradnice))
                {
                    Trojuhelnik triangl = new Trojuhelnik(new Bod2D(souradnice[0], souradnice[1]), new Bod2D(souradnice[2], souradnice[3]), new Bod2D(souradnice[4], souradnice[5]));
                    if (triangl.Existuje())
                    {
                        triangl.Parametry();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("Pro dalsi trojuhelnik stisknete ENTER.");
                if (Console.ReadKey(true).Key != ConsoleKey.Enter) bezim = false;
                Console.Clear(); // vymazani konzole
            }

        }
    }
}
