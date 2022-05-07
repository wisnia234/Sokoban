using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Gracz
    {
        private int x;
        private int y;

        public Gracz(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Move(Move move)
        {
            switch(move)
            {
                case Sokoban.Move.up:
                    y--; break;
                case Sokoban.Move.down:
                    y++; break;
                case Sokoban.Move.letf:
                    x--; break;
                case Sokoban.Move.right:
                    x++; break;
            }
        }
    
        public Point DajPunktPrzed(int ile, Move move)
        {
            switch (move)
            {
                case Sokoban.Move.up:
                    return new Point(x, y - ile);
                case Sokoban.Move.down:
                    return new Point(x,y+ile);
                case Sokoban.Move.letf:
                    return new Point(x - ile,y);
                case Sokoban.Move.right:
                    return new Point(x + ile,y);
            }
            return new Point(0,0);
        }
        public Point Polozenie
        {
            get
            {
                return new Point(x, y);
            }
        }
      
    }
}
