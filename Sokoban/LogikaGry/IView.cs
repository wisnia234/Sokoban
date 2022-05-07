using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public interface IView
    {
        void StworzPlansze(TypPola[,] plansza);
        void WypiszPole(TypPola pole, Point p);
        void WypiszKomunikat(string text);
        int Wysokosc
        {
            set;
        }

        int Szerokosc
        {
            set;
        }
        Move PobierzRuch();
    }
}
