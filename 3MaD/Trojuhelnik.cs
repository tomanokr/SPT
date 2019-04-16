using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3MaD
{
    class Trojuhelnik
    {
        public Bod2D BodA { get; set; }
        public Bod2D BodB { get; set; }
        public Bod2D BodC { get; set; }

        public Trojuhelnik(Bod2D bod1, Bod2D bod2, Bod2D bod3)
        {
            BodA = bod1;
            BodB = bod2;
            BodC = bod3;
        }

        public void testSestrojitelnosti()
        {
            double a = delkaStrany(BodB, BodC);
            double b = delkaStrany(BodA, BodC);
            double c = delkaStrany(BodA, BodB);
            double obsah = obsahTrojuhelnika();
            double alfa = velikostUhlu(BodA, BodB, BodC);
            double beta = velikostUhlu(BodB, BodA, BodC);
            double gama = velikostUhlu(BodC, BodB, BodA);

            if (a + b > c && a + c > b && b + c > a && obsah != 0 && (alfa + beta + gama == 180))
            {

                Console.WriteLine("Trojuhlenik lze sestrojit");
            }
            else
            {
                Console.WriteLine("Ju fukedd upppp boizzzs");
            }

        }
        public double delkaStrany(Bod2D bod1, Bod2D bod2)
        {
            return Math.Sqrt((bod1.X - bod2.X) * (bod1.X - bod2.X) + (bod1.Y - bod2.Y) * (bod1.Y - bod2.Y));
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
        public double velikostUhlu(Bod2D bod1, Bod2D bod2, Bod2D bod3)
        {
            Bod2D vektorV = new Bod2D(bod2.X - bod1.X, bod2.Y - bod1.Y);
            Bod2D vektorU = new Bod2D(bod3.X - bod1.X, bod3.Y - bod1.Y);


            return Math.Acos(((vektorV.X * vektorU.X) + (vektorV.Y * vektorU.Y)) / ((Math.Sqrt(Math.Pow(vektorV.X, 2) + Math.Pow(vektorV.Y, 2))) * Math.Sqrt(Math.Pow(vektorU.X, 2) + Math.Pow(vektorU.Y, 2)))) * 180 / Math.PI;

        }
    }
}
