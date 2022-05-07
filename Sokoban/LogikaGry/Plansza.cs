using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Sokoban
{
    public class Plansza
    {
        TypPola[,] plansza;
        bool[,] cele;

        int wysokosc;
        int szerokosc;
        Gracz gracz;

        public Gracz Wczytaj(string nazwa)
        {
            StreamReader plik = new StreamReader(nazwa);
            string line = plik.ReadLine();
            string[] elementy = line.Split(' ');
            //"Jan Kowalski 32"
            //elementy = {"Jan","Kowalski","32"}
            wysokosc = int.Parse(elementy[0]);
            szerokosc = int.Parse(elementy[1]);
            plansza = new TypPola[szerokosc, wysokosc];
            cele = new bool[szerokosc, wysokosc];
            for (int y = 0; y < wysokosc; y++)
            {
                line = plik.ReadLine();
                for (int x = 0; x < szerokosc; x++)
                {
                    plansza[x,y] = DajTypPola(line[x]);
                    if (line[x] == '%')
                    {
                        gracz = new Gracz(x, y);
                    }
                    cele[x,y] = (line[x] == '.');
                }
            }
            return gracz;
        }

        

        public TypPola[,] PolaPlanszy
        {
            get
            {
                return plansza;
            }
        }


        public TypPola DajPole(Point punkt)
        {
            return plansza[punkt.X, punkt.Y];
        }
        public void UstawPole(Point punkt, TypPola pole)
        {
            plansza[punkt.X, punkt.Y] = pole;
        }


        public bool Cel(Point puntk)
        {
            return cele[puntk.X, puntk.Y];
        }

        public int Wysokosc
        {
            get
            {
                return wysokosc;
            }
        }

        public int Szerokosc
        {
            get
            {
                return szerokosc;
            }
        }


        public bool Wygrana
        {
            get
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    for (int x = 0; x < szerokosc; x++)
                    {
                        if (cele[x,y])
                        {
                            if (plansza[x,y] !=  TypPola.becka)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            
        }
        private TypPola DajTypPola(char znak)
        {
            switch (znak)
            {
                case '#':
                    return TypPola.sciana;
                case '_':
                    return TypPola.podloga;
                case 'O':
                    return TypPola.becka;
                case '%':
                    return TypPola.gracz;
                case '.':
                    return TypPola.cel;
            }
            return TypPola.sciana;
        }

    }
}
