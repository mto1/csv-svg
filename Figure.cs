using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Final
{
    class Figure:IComparable<Figure> // on implémente l'interface IComparable afin de pouvoir comparer les figures entre elles. Cela sera utile lors de la sauvegarde
    {
        //Attribut
        private int ordre;
        private int id;
        private Couleur figure_couleur;
        private string Message_SVG;

        //Constructeur
        public Figure(int id, Couleur figure_couleur, int ordre)
        {
            this.ordre = ordre;
            this.id = id;
            this.figure_couleur = new Couleur(figure_couleur.R,figure_couleur.G,figure_couleur.B);
            this.Message_SVG = null;
        }

        //Accesseur
        public int Ordre
        {
            get { return this.ordre; }
            set { this.ordre = value; }
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Couleur Figure_Couleur
        {
            get { return this.figure_couleur; }
            set { this.figure_couleur = value; }
        }

        public string MESSAGE_SVG
        {
            get { return this.Message_SVG; }
            set { this.Message_SVG = value; }
        }

        //ToString
        public override string ToString()
        {
            string message_Figure = null;
            message_Figure = "Ordre : " + this.ordre + " id : " + this.id+ " ";
            return message_Figure;
        }

        public int CompareTo(Figure other) // méthode réutilisé d'un ancien TD (TD2) qui permet le tri de la liste
        {

            int Result = 0;
            if (this.ordre == other.ordre)
            {
                return Result;
            }
            else
            {
                if (this.ordre.CompareTo(other.ordre) == -1)
                {
                    Result = -1;
                    return Result;
                }
                Result = 1;
                return Result;
            }
        }
    }
}
