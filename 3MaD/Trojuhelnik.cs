using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3MaD
{
    /*!
     * \brief Třída pro práci s trojúhelníkem
     * \param BoDA
     * \param BodB
     * \param BodC
     */
    class Trojuhelnik
    {
        private readonly Bod2D BodA; /*!< Bod A trojúhleníku definován pomocí struktury BoD2D */
        private readonly Bod2D BodB; /*!< Bod B trojúhleníku definován pomocí struktury BoD2D */
        private readonly Bod2D BodC; /*!< Bod C trojúhleníku definován pomocí struktury BoD2D */

        public double StranaA { get; private set; }
        public double StranaB { get; private set; }
        public double StranaC { get; private set; }

        public Trojuhelnik(Bod2D bod1, Bod2D bod2, Bod2D bod3)
        {
            BodA = bod1;
            BodB = bod2;
            BodC = bod3;
        }
        /*!
         * \brief Funkce ke zjištění sestrojitelnosti
         * \return True nebo False
         */
        public bool Existuje()
        {
            /*!
            * \brief Zjištění zda neleží na jedné přímce
            */
            bool neleziNaPrimce = false; /*!< Nastavení na false */
            Vektor2D u = new Vektor2D(BodA, BodB); /*!< Vektor u bodů AB */

            /*!
            * \brief Parametrická rovnice přímky X = A + t*u
            */
            double t1 = (BodC.X - BodA.X) / (u.u1); /*!< Hodnota parametru přímky t1 */
            double t2 = (BodC.Y - BodA.Y) / (u.u2); /*!< Hodnota parametru přímky t2 */
            neleziNaPrimce = t1 != t2;

            /*!
            * \brief Pokud neleží na jedné přímce dojde k vykonání
            */

            if (neleziNaPrimce)
            {
                StranaA = delkaStrany(BodB, BodC);
                StranaB = delkaStrany(BodA, BodC);
                StranaC = delkaStrany(BodA, BodB);


                /*! Ověření kritéria pro trojúhelníkovou nerovnost*/

                if ((StranaA + StranaB > StranaC) && (StranaB + StranaC > StranaA) && (StranaC + StranaA > StranaB))
                {
                    Console.WriteLine("Trojuhelnik je sestrojitelny.");
                    return true;
                }
            }
            Console.WriteLine("Trojuhelnik nelze sestrojit.");
            return false;
        }

        /*!
         * \brief Výpočet délky strany
         * \return Délka strany
         */
        public double delkaStrany(Bod2D bod1, Bod2D bod2)
        {
            /*!
             * \brief Vzorec pro výpočet délky strany z analytické geometrie (vzdálenost dvou bodů)
             */
            return Math.Sqrt((bod2.X - bod1.X) * (bod2.X - bod1.X) + (bod2.Y - bod1.Y) * (bod2.Y - bod1.Y));
        }

        /*!
         * \brief Výpis parametrů na konzoli
         */
        public void Parametry()
        {
            Console.WriteLine();
            Console.WriteLine("------ parametry trojuhelnika ------");
            Console.WriteLine();
            /*!
            * \brief Heronův vzorec pro výpočet obsahu trojúhelníka
            */
            double s = Obvod() / 2; /*!< Hodnota obvodu */
            double obsah = Math.Sqrt(s * (s - StranaA) * (s - StranaB) * (s - StranaC)); /*!< Hodnota obsahu */
            Console.WriteLine($"Obsah trojuhelnika S = {Math.Round(obsah, 2)} j^2.");

            // vypis delek stran
            Console.WriteLine($"Strana a = {StranaA:f2} j");
            Console.WriteLine($"Strana b = {StranaB:f2} j");
            Console.WriteLine($"Strana c = {StranaC:f2} j");

            // podminka pro pravouhlost vychazi z platnosti Pythagorovy vety
            if ((StranaA*StranaA == StranaC*StranaC + StranaB*StranaB)||(StranaB * StranaB == StranaC * StranaC + StranaA * StranaA) ||(StranaC * StranaC == StranaA * StranaA + StranaB * StranaB))
            {
                Console.WriteLine("Trojuhelnik je pravouhly.");
            }
            else Console.WriteLine("Trojuhelnik neni pravouhly.");
        }

        /*!
         * \brief Výpočet obvodu
         * \return Obvod
         */
        public double Obvod()
        {
            double obvod = StranaA + StranaB + StranaC;
            Console.WriteLine($"Obvod trojuhelnika O = {Math.Round(obvod,2)} j.");
            return obvod;
        }
    }
}
