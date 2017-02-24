using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Final
{
    class Couleur
    {
        //Attribut
        private int r;
        private int g;
        private int b;

        //Constructeur
        public Couleur(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        
        //Accesseur
        public int R
        {
            get { return this.r; }
            set { this.r = value; }
        }

        public int G
        {
            get { return this.g; }
            set { this.g = value; }
        }

        public int B
        {
            get { return this.b; }
            set { this.b = value; }
        }

        //Méthodes

        //ToString
        public override string ToString()
        {
            string message = "Couleur RGB : R=" + this.r + " G=" + this.g + " B=" + this.b+ " ";
            return message;
        }

    }
}
