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

        public bool Existuje()
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
                    return true;
                }
            }
            Console.WriteLine("Trojuhelnik nelze sestrojit.");
            return false;
        }
        public double delkaStrany(Bod2D bod1, Bod2D bod2)
        {
            return Math.Sqrt((bod1.X - bod2.X) * (bod1.X - bod2.X) + (bod1.Y - bod2.Y) * (bod1.Y - bod2.Y));
        }
        public void Parametry()
        {
            Console.WriteLine();
            Console.WriteLine("------ parametry trojuhelnika ------");
            Console.WriteLine();
            double s = Obvod() / 2;
            double obsah = Math.Sqrt(s * (s - StranaA) * (s - StranaB) * (s - StranaC));
            Console.WriteLine($"Obsah trojuhelnika S = {Math.Round(obsah, 2)} j^2.");
            Console.WriteLine($"Strana a = {StranaA:f2} j");
            Console.WriteLine($"Strana b = {StranaB:f2} j");
            Console.WriteLine($"Strana c = {StranaC:f2} j");
            if ((StranaA*StranaA == StranaC*StranaC + StranaB*StranaB)||(StranaB * StranaB == StranaC * StranaC + StranaA * StranaA) ||(StranaC * StranaC == StranaA * StranaA + StranaB * StranaB))
            {
                Console.WriteLine("Trojuhelnik je pravouhly.");
            }
            else Console.WriteLine("Trojuhelnik neni pravouhly.");
        }
        public double Obvod()
        {
            double obvod = StranaA + StranaB + StranaC;
            Console.WriteLine($"Obvod trojuhelnika O = {Math.Round(obvod,2)} j.");
            return obvod;
        }
    }
}
