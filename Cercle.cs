using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Final
{
    class Cercle : Figure,Itranslatable
    {
        //Attribut
        private Point pt_centre;
        private int rayon;     

        //Constructeur
        public Cercle(int id, Point pt_centre, int rayon, Couleur figure_couleur, int ordre) : base(id, figure_couleur, ordre)
        {
            this.pt_centre = new Point(pt_centre.X,pt_centre.Y);
            this.Figure_Couleur = new Couleur(figure_couleur.R, figure_couleur.G, figure_couleur.B);
            this.rayon = rayon;
        }

        //Accesseur
        public Point Pt_Centre
        {
            get { return this.pt_centre; }
            set { this.pt_centre = value; }
        }

        public int Rayon
        {
            get { return this.rayon; }
            set { this.rayon = value; }
        }

        //Méthode

        //ToString
        public override string ToString()
        {
            string message_cercle = null;
            message_cercle = base.ToString() + "<circle cx=\"" + this.pt_centre.X + " cy=\"" + this.pt_centre.Y + " r=\"" + this.rayon + " style=\"fill:rgb(" + this.Figure_Couleur.R + "," + this.Figure_Couleur.G + "," + this.Figure_Couleur.B + ") /> ";
            return message_cercle;
        }
    }
}
