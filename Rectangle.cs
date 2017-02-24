using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Final
{
    class Rectangle : Figure,Itranslatable,Irotationnable
    {
        //Attribut
        private Point pt_high_left;
        private int hauteur;
        private int largeur;

        //Constructeur
        public Rectangle(int id, Point pt_high_left, int largeur, int hauteur, Couleur figure_couleur, int ordre) : base(id, figure_couleur, ordre)
        {
            this.pt_high_left = new Point(pt_high_left.X, pt_high_left.Y);
            base.Figure_Couleur = new Couleur(figure_couleur.R, figure_couleur.G, figure_couleur.B);
            this.largeur = largeur;
            this.hauteur = hauteur;

        }

        //Accesseur
        public Point Pt_High_Left
        {
            get { return this.pt_high_left; }
            set { this.pt_high_left = value; }
        }

        public int Largeur
        {
            get { return this.largeur; }
            set { this.largeur = value; }
        }

        public int Hauteur
        {
            get { return this.hauteur; }
            set { this.hauteur = value; }
        }

        //Méthode

        //ToString
        public override string ToString()
        {
            string M = base.ToString() + "<rectangle x=\"" + this.pt_high_left.X + " y=\"" + this.pt_high_left.Y + " width=\"" + this.largeur+ " height=\"" + this.hauteur + " style=\"fill:rgb(" + this.Figure_Couleur.R + "," + this.Figure_Couleur.G + "," + this.Figure_Couleur.B + ") />";
            return M;
        }
    }
}
