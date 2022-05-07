using Sokoban;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SokobanOkienkowy
{
    public partial class Form1 : Form, IView
    {
        Image podloga;
        Image sciana;
        Image cel;
        Image becka;
        Image gracz;
        int wysokosc;
        int szerokosc;
        private Keys znak;
        PictureBox[,] pixele;
        Gra gra;
        public Form1()
        {
            InitializeComponent();
            podloga = Image.FromFile("podloga.bmp");
            sciana = Image.FromFile("sciana.bmp");
            cel = Image.FromFile("cel.bmp");
            becka = Image.FromFile("beczka.bmp");
            gracz = Image.FromFile("gracz.bmp");

            gra = new Gra(this, "plansza.txt");
            gra.WypiszPlansze();

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

        public Move PobierzRuch()
        {
            switch (znak)
            {
                case Keys.Escape: return Sokoban.Move.escape;
                case Keys.Left: return Sokoban.Move.letf;
                case Keys.Right: return Sokoban.Move.right;
                case Keys.Up: return Sokoban.Move.up;
                case Keys.Down: return Sokoban.Move.down;
            }
            return Sokoban.Move.none;
        }

        public void StworzPlansze(TypPola[,] plansza)
        {
            pixele = new PictureBox[szerokosc, wysokosc];
            for (int y = 0; y < wysokosc; y++)
            {
                for (int x = 0; x < szerokosc; x++)
                {
                    pixele[x,y] = StworzPixel(x, y, plansza[x, y]);
                }
            }
            
        }

        public void WypiszKomunikat(string text)
        {
            MessageBox.Show(text);
        }

        public void WypiszPole(TypPola pole, Point p)
        {
            pixele[p.X, p.Y].Image = DajObrazek(pole);
        }

        Image DajObrazek(TypPola typPola)
        {
            switch(typPola)
            {
                case TypPola.podloga: return podloga;
                case TypPola.sciana: return sciana;
                case TypPola.cel: return cel;
                case TypPola.becka: return becka;
                case TypPola.gracz: return gracz;
            }
            return null;
        }




        PictureBox StworzPixel(int x, int y, TypPola typPola)
        {
            PictureBox picture = new PictureBox();
            picture.Image = DajObrazek(typPola);
            picture.Location = new Point(x * 32, y * 32);
            picture.Name = "pictureBox";
            picture.Size = new Size(32, 32);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.TabIndex = 0;
            picture.TabStop = false;
            this.Controls.Add(picture);
            return picture;
        }

      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            znak = e.KeyCode;
            gra.Idz();

        }

       
    }
}
