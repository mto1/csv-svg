using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Final
{
    class Chemin : Figure,Irotationnable
    {
        //Attribut

        private string path;

        //Constructeur
        public Chemin(int id, string path, Couleur figure_couleur, int ordre) : base(id, figure_couleur, ordre)
        {
            this.path = path;
        }

        //Accesseur
        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        //Méthode
        //ToString
        public override string ToString()
        {
            string message = base.ToString() + "<path d=" + this.path + " style=\"fill:rgb(" + Figure_Couleur.R + ", " + Figure_Couleur.G + ", " + Figure_Couleur.B + ")\" />";
            return message;
        }

    }
}