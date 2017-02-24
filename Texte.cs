using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Final
{
    class Texte : Figure,Itranslatable,Irotationnable
    {
        //Attribut

        private Point pt_texte;
        private string contenu ;

        //Constructeur
        public Texte(int id, Point pt_texte, string contenu, Couleur figure_couleur, int ordre) : base(id, figure_couleur, ordre)
        {
            this.pt_texte = new Point(pt_texte.X, pt_texte.Y);
            base.Figure_Couleur = new Couleur(figure_couleur.R, figure_couleur.G, figure_couleur.B);
            this.contenu = contenu;
        }

        //Accesseur
        public Point Pt_Texte
        {
            get { return this.pt_texte; }
            set { this.pt_texte = value; }
        }

        public string Contenu
        {
            get { return this.contenu; }
            set { this.contenu = value; }
        }

        //Méthode
        //ToString
        public override string ToString()
        {
            string message = base.ToString() + "<text x = " + pt_texte.X + " y = " + pt_texte.Y + " fill = \"rgb(" + Figure_Couleur.R + ", " + Figure_Couleur.G + ", " + Figure_Couleur.B + ")\" >" + this.contenu+ ".</ text >";
            return message;
        }
        
    }
}