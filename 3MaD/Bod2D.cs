using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3MaD
{
    struct Bod2D
    {     
            public double X;
            public double Y;

            public Bod2D(double x, double y)
            {
                X = x;
                Y = y;
            }
    }
    struct Vektor2D
    {
        public double u1;
        public double u2;
        public double Velikost()
        {
            return Math.Sqrt(u1 * u1 + u2 * u2);
        }
        public Vektor2D(Bod2D zacatek, Bod2D konec)
        {
            u1 = konec.X - zacatek.X;
            u2 = konec.Y - zacatek.Y;
        }
    }
}
