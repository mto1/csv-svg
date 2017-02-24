using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Final
{
    class Ellipse : Figure,Itranslatable,Irotationnable
    {
        //Attributs
        private Point pt_ellipse;
        private int r_x;
        private int r_y;

        //Constructeur
        public Ellipse(int id, Point pt_ellipse, int r_x, int r_y, Couleur figure_couleur, int ordre) : base(id, figure_couleur, ordre)
        {
            this.pt_ellipse = new Point(pt_ellipse.X, pt_ellipse.Y);
            base.Figure_Couleur = new Couleur(figure_couleur.R, figure_couleur.G, figure_couleur.B);
            this.r_x = r_x;
            this.r_y = r_y;
        }

        //Accesseur
        public Point Pt_Ellipse
        {
            get { return this.pt_ellipse; }
            set { this.pt_ellipse = value; }
        }
        public int R_x
        {
            get { return this.r_x; }
            set { this.r_x = value; }
        }
        public int R_y
        {
            get { return this.r_y; }
            set { this.r_y = value; }
        }

        //Méthode
        //ToString
        public override string ToString()
        {
            string message = "<ellipse cx=\"" + this.pt_ellipse.X + " cy=\"" + this.pt_ellipse.Y + " rx=\"" + this.r_x + " ry=\"" + this.r_y + " style=\"fill:rgb(" + this.Figure_Couleur.R + "," + this.Figure_Couleur.G + "," + this.Figure_Couleur.B + ") />";
            return base.ToString()+ message;
        }
    }
}
