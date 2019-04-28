using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3MaD
{
    /*!
     * \brief Stuktura pro vytvoření bodu
     * \param X
     * \param Y
     */
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


    /*!
     * \brief Pomocná struktura k ověření sestrojitelnosti trojúhelníka
     * \param u1
     * \param u2
     */
    struct Vektor2D
    {
        public double u1; /*!< Souřadnice vektoru počáteční */
        public double u2; /*!< Souřadnice vektoru koncová*/

        /*!
         * \brief Vrací velikost vektoru
         * \return Velikost
         */
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
