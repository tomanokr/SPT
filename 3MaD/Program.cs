using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3MaD
{
    struct bod2D
    {
        public double X;
        public double Y;

        public bod2D(double x, double y)
        {
            X = x;
            Y = y;
        }

    }
    
    class trojuhelnik
       {
        public bod2D BodA { get; set; }
        public bod2D BodB { get; set; }
        public bod2D BodC { get; set; }

        public trojuhelnik(bod2D bod1, bod2D bod2, bod2D bod3)
        {
            BodA = bod1;
            BodB = bod2;
            BodC = bod3;
        }

        public void testSestrojitelnosti()
        {
            double a = delkaStrany(BodB, BodC);
            double b = delkaStrany(BodA, BodC);
            double c = delkaStrany(BodA, BodC);
            double obsah = obsahTrojuhelnika();
            double alfa = velikostUhlu(BodA, BodB, BodC);
            double beta = velikostUhlu(BodB, BodA, BodC);
            double gama = velikostUhlu(BodC, BodB, BodA);

            if (a + b > c && a + c > b && b + c > a && obsah!=0 && (alfa+beta+gama==180))
            {
                
                Console.WriteLine("Trojuhlenik lze sestrojit");
            }
            else
            {
                Console.WriteLine("Ju fukedd upppp boizzzs");
            }

        }
        public double delkaStrany(bod2D bod1, bod2D bod2)
        {
            return Math.Sqrt((bod1.X-bod2.X)* (bod1.X - bod2.X)+ (bod1.Y - bod2.Y)* (bod1.Y - bod2.Y));
        }
        public double obsahTrojuhelnika()
        {
            double a = delkaStrany(BodB, BodC);
            double b = delkaStrany(BodA, BodC);
            double c = delkaStrany(BodA, BodC);
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        public double obvodTrojuhelnika()
        {
            double a = delkaStrany(BodB, BodC);
            double b = delkaStrany(BodA, BodC);
            double c = delkaStrany(BodA, BodC);

           
            return a + b + c;
        }
        public double velikostUhlu(bod2D bod1, bod2D bod2,bod2D bod3)
        {
            bod2D vektorV = new bod2D(bod2.X - bod1.X, bod2.Y - bod1.Y);
            bod2D vektorU = new bod2D(bod3.X - bod1.X, bod3.Y - bod1.Y);


            return Math.Acos(((vektorV.X * vektorU.X) + (vektorV.Y * vektorU.Y)) /((Math.Sqrt(Math.Pow(vektorV.X, 2) + Math.Pow(vektorV.Y, 2))) * Math.Sqrt(Math.Pow(vektorU.X, 2) + Math.Pow(vektorU.Y, 2))))*180/Math.PI;

        } 

            
    }
    class Program
    {
    
        static void Main(string[] args)
        {

            trojuhelnik trojuhelnikTsucc = new trojuhelnik(new bod2D(0, 0), new bod2D(0, 1), new bod2D(1, 1));
            trojuhelnik trojuhelnikTfaill = new trojuhelnik(new bod2D(0, 0), new bod2D(0, 10), new bod2D(0, 5));
            trojuhelnikTsucc.testSestrojitelnosti();
            trojuhelnikTfaill.testSestrojitelnosti();
            double uhel = trojuhelnikTsucc.velikostUhlu(trojuhelnikTsucc.BodC, trojuhelnikTsucc.BodA, trojuhelnikTsucc.BodB);
            Console.WriteLine($"Tak moc je to vyd8leno od pravdz {trojuhelnikTsucc.velikostUhlu(trojuhelnikTsucc.BodC, trojuhelnikTsucc.BodA, trojuhelnikTsucc.BodB)}");
            Console.WriteLine($"Trojuhelnik Test se sklada ze 3 bodu ");
            Console.ReadKey();

        }
    }
}
