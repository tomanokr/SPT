using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3MaD
{
    class Trojuhelnik
    {
        private readonly Bod2D BodA;
        private readonly Bod2D BodB;
        private readonly Bod2D BodC;
        public double StranaA { get; private set; }
        public double StranaB { get; private set; }
        public double StranaC { get; private set; }

        public Trojuhelnik(Bod2D bod1, Bod2D bod2, Bod2D bod3)
        {
            BodA = bod1;
            BodB = bod2;
            BodC = bod3;
        }

        public void Existuje()
        {
            //jeden bod musi lezet na jine primce
            bool neleziNaPrimce = false;
            Vektor2D u = new Vektor2D(BodA, BodB);
            double t1 = (BodC.X - BodA.X) / (u.u1);
            double t2 = (BodC.Y - BodA.Y) / (u.u2);
            neleziNaPrimce = t1 != t2;

            if (neleziNaPrimce)
            {
                StranaA = delkaStrany(BodB, BodC);
                StranaB = delkaStrany(BodA, BodC);
                StranaC = delkaStrany(BodA, BodB);
                //trojuhelnikova nerovnost
                if ((StranaA + StranaB > StranaC) && (StranaB + StranaC > StranaA) && (StranaC + StranaA > StranaB))
                {
                    Console.WriteLine("Trojuhelnik je sestrojitelny.");
                    return;
                }
            }
            Console.WriteLine("Trojuhelnik nelze sestrojit.");
        }
        public double delkaStrany(Bod2D bod1, Bod2D bod2)
        {
            return Math.Sqrt((bod1.X - bod2.X) * (bod1.X - bod2.X) + (bod1.Y - bod2.Y) * (bod1.Y - bod2.Y));
        }
        public double obsahTrojuhelnika()
        {
            double a = delkaStrany(BodB, BodC);
            double b = delkaStrany(BodA, BodC);
            double c = delkaStrany(BodA, BodB);
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
