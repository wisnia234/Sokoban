using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
           


            Konsola konsola = new Konsola();
            Gra gra = new Gra(konsola, "plansza.txt");
            gra.WypiszPlansze();
            while (true)
            {

                konsola.CzytajZnak();
                gra.Idz();
            }

        }
    }
}
