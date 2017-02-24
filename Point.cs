using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Final
{
    class Point
    {
        //Attribut
        private int x;
        private int y;

        //Constructeur
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //Accesseur
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        //ToString
        public override string ToString()
        {
            string message;
            message = "Point de coordonné ( x: " + this.X + "; Y: " + this.Y + " ) ";
            return message;
        }
    }
}
