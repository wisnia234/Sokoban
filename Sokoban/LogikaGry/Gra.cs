using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Gra
    {
        private Plansza plansza;
        private Gracz gracz;
        private IView konsola;
        
        public Gra(IView konsola, string nazwaPlanszy)
        {
            this.konsola = konsola;
            plansza = new Plansza();
            gracz = plansza.Wczytaj(nazwaPlanszy);
            konsola.Wysokosc = plansza.Wysokosc;
            konsola.Szerokosc = plansza.Szerokosc;
        }

        public void WypiszPlansze()
        {
            konsola.StworzPlansze(plansza.PolaPlanszy);
        }

        public void Idz()
        {
            Move roch = konsola.PobierzRuch();
            if (!MoznaZrobicRuch(roch))
            {
                return;
            }
            
            if (plansza.Cel(gracz.Polozenie))
            {
                plansza.UstawPole(gracz.Polozenie, TypPola.cel);
                konsola.WypiszPole(TypPola.cel, gracz.Polozenie);
            }
            else
            {
                plansza.UstawPole(gracz.Polozenie, TypPola.podloga);
                konsola.WypiszPole(TypPola.podloga, gracz.Polozenie);
            }
            PrzesunBeczke(roch);

            gracz.Move(roch);
            plansza.UstawPole(gracz.Polozenie, TypPola.gracz);
            konsola.WypiszPole(TypPola.gracz, gracz.Polozenie);

            if (plansza.Wygrana)
            {
                konsola.WypiszKomunikat("BRAWO!!!!!!!!!!!!!!!!!!!!!");
            }

        }


        private void PrzesunBeczke(Move roch)
        {
            if (plansza.DajPole(gracz.DajPunktPrzed(1, roch)) == TypPola.becka)
            {
                plansza.UstawPole(gracz.DajPunktPrzed(2, roch), TypPola.becka);
                konsola.WypiszPole(TypPola.becka, gracz.DajPunktPrzed(2, roch));
            }
        }
        private bool MoznaZrobicRuch(Move roch)
        {
            if (plansza.DajPole(gracz.DajPunktPrzed(1, roch)) == TypPola.sciana)
            {
                return false;
            }
            else if (plansza.DajPole(gracz.DajPunktPrzed(1, roch)) == TypPola.becka)
            {
                return plansza.DajPole(gracz.DajPunktPrzed(2, roch)) != TypPola.sciana
                    && plansza.DajPole(gracz.DajPunktPrzed(2, roch)) != TypPola.becka;
            }
            return true;
        }


    }
}
