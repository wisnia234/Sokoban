using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Konsola : IView
    {
        private int wysokosc;
        private int szerokosc;
        private ConsoleKey znak;
        public void StworzPlansze(TypPola[,] plansza)
        {
            for (int y = 0; y < wysokosc; y++)
            {
                for (int x = 0; x < szerokosc; x++)
                {
                    WypiszPole(plansza[x,y],new Point(x,y));
                }
            }
        }

        public void WypiszPole(TypPola pole, Point p)
        {
            Console.SetCursorPosition(p.X * 2, p.Y);
            switch (pole)
            {
                case TypPola.sciana:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("##");
                    break;
                case TypPola.podloga:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("..");
                    break;
                case TypPola.becka:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("[]");
                    break;
                case TypPola.gracz:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("}{");
                    break;
                case TypPola.cel:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("xx");
                    break;



            }
            Console.SetCursorPosition(0, wysokosc + 1);
        }

        public void WypiszKomunikat(string text)
        {
            Console.SetCursorPosition(0, wysokosc);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
        }


        public int Wysokosc
        {
            set
            {
                wysokosc = value;
            }
        }

        public int Szerokosc
        {
            set
            {
                szerokosc = value;
            }
        }

        public void CzytajZnak()
        {
            znak = Console.ReadKey().Key;
        }

        public Move PobierzRuch()
        {

            switch (znak)
            {
                case ConsoleKey.Escape: return Move.escape;
                case ConsoleKey.LeftArrow: return Move.letf;
                case ConsoleKey.RightArrow: return Move.right;
                case ConsoleKey.UpArrow: return Move.up;
                case ConsoleKey.DownArrow: return Move.down;
            }
            return Move.none;

        }
    }
}
