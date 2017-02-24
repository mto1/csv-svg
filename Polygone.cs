using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Final
{
    class Polygone : Figure,Irotationnable
    {
        //Attribut

        private List<Point> liste_points;


        //Constructeur
        public Polygone(int id, List<Point> liste_points, Couleur figure_couleur, int ordre) : base(id, figure_couleur, ordre)
        {
            this.liste_points = new List<Point>(liste_points); 
                   
        }

        //Accesseur
        public List<Point> Liste_Points
        {
            get { return this.liste_points; }
            set { this.liste_points = value; }
        }

        //Méthode
        //ToString
        public override string ToString()
        {
            string message = "<polygon points = \"";
            int i;
            for (i = 0; i < Liste_Points.Count; i++)
            {
                message += Liste_Points[i].X + ",";
                message += Liste_Points[i].Y;
                if (i < (Liste_Points.Count - 2))
                {
                    message += " ";
                }

            }
            message += "\" style=\"fill:rgb(" + this.Figure_Couleur.R + "," + this.Figure_Couleur.G + "," + this.Figure_Couleur.B + ") /> ";
            return base.ToString() + message;
        }
    }
}
