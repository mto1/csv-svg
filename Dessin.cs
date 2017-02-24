using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TD_Final
{
    class Dessin
    {
        //attribut
        private List<Figure> Liste_figure;
        
        //constructeur
        public Dessin()
        {
            Liste_figure = new List<Figure>();
        }
        //accesseur

        //méthode
        public void Afficher_liste_figure()
        {
            foreach (Figure Fig in Liste_figure)
            {
                Console.WriteLine(Fig.ToString());
            }
        }

        public void Ajout_Figure_au_Dessin(Figure to_add)
        {
            Liste_figure.Add(to_add);
        }

        public void Trier_Les_Figures_Selon_Ordre()
        {
            Liste_figure.Sort();
        }

        public void Sauvegarder_en_SVG(string chemin)
        {
            Console.WriteLine("\n Debut de la sauvegarde ");
            /* 
            A ce stade, la liste des figures contient toutes les figures du fichier CSV dans l'ordre de lecture du fichier.
            Il faut considerer que les figures ne sont pas forcément décrire dans l'ordre dans lequel elles doivent être inscrite dans le fichier svg.
            Nous allons donc trier la "liste_figure" afin que celle-ci contienne les figures dans le bon ordre.
            */
            Console.WriteLine("\n Tri de la liste des figures .... ");
            Trier_Les_Figures_Selon_Ordre();
            Console.WriteLine("\n Liste triée avec succès! ");
            /*
            On a ici la lifste_figure qui contient toutes les figures dans le bon ordre; on peut donc commencer à écrire le fichier svg.
            Avoir Réaliser ce try permet de géré nombre d'exception :
                - il y a des ordres manquant (par exemple aucune figure ne porte l'information ordre=3 )
                - plusieures figures ont un ordre identique ( PAr exemple un Rectangle et un Cercle ont tous les deux leurs ordre égal à 11)
                - en cas d'ordre manquant cela permet de ne pas aoir à parcourir tous les ordres et obtimiser le nombre d'opération 
                    (par exemple si dans le csv il y a un trou entre l'ordre 10 et 50000; on n'a donc pas besoin de parcourir les ordres 11 à 4999 pour ce rendre compte qu'ils sont absent)
            */
            StreamWriter Writer = new StreamWriter(chemin);

            Writer.WriteLine("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">"); // entête du fichier svg

            Console.WriteLine("\n Ecriture du fichier svg... ");
            foreach (Figure F in Liste_figure)
            {
                Writer.WriteLine("  "+F.MESSAGE_SVG);
            }
            Writer.WriteLine("</svg>");                       // fin du fichier svg
            Writer.Close();                                   // on n'oublie pas de fermer le streamwriter pour physiquement écrire le fichier sur le disque.
            Console.WriteLine(" Fin de l'écriture du fichier svg...");
            Console.WriteLine("\n\n Sauvegarde completée avec succès");
        }

        public void Convertion_CSV_SVG(string Chemin, string CheminSortie)
        {
            Point Point_tmp = new Point(0, 0);
            Couleur Couleur_tmp = new Couleur(0, 0, 0);

            StreamReader monStreamReader = new StreamReader(Chemin);
            string ligne = monStreamReader.ReadLine();
            while (ligne != null)
            {
                string[] tab = ligne.Split(';');

                string caseSwitch = tab[0];
                switch (caseSwitch)
                {
                    case "Cercle":
                        #region
                        Console.WriteLine("CERCLE");
                        try
                        {
                            Point_tmp.X = Convert.ToInt32(tab[2]);
                            Point_tmp.Y = Convert.ToInt32(tab[3]); // on récupère les coordonné du point x et Y;

                            Couleur_tmp.R = Convert.ToInt32(tab[5]);
                            Couleur_tmp.G = Convert.ToInt32(tab[6]);
                            Couleur_tmp.B = Convert.ToInt32(tab[7]); // on met à jours la couleurs_temporaire

                            Cercle New_Cercle = new Cercle(Convert.ToInt32(tab[1]), Point_tmp, Convert.ToInt32(tab[4]), Couleur_tmp, Convert.ToInt32(tab[8]));  // on crée le cercle avec le point et la couleur
                            New_Cercle.MESSAGE_SVG = "<circle cx=\"" + New_Cercle.Pt_Centre.X + "\" cy=\"" + New_Cercle.Pt_Centre.Y + "\" r=\"" + New_Cercle.Rayon + "\" style=\"fill:rgb(" + New_Cercle.Figure_Couleur.R + "," + New_Cercle.Figure_Couleur.G + "," + New_Cercle.Figure_Couleur.B + ")\" />";
                            Ajout_Figure_au_Dessin(New_Cercle);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erreur" + e.Message);
                        }
                        #endregion
                        break;

                    case "Ellipse":
                        #region
                        Console.WriteLine("ELLIPSE");
                        try
                        {
                            Point_tmp.X = Convert.ToInt32(tab[2]);
                            Point_tmp.Y = Convert.ToInt32(tab[3]); // on récupère les coordonné du point x et Y;

                            Couleur_tmp.R = Convert.ToInt32(tab[6]);
                            Couleur_tmp.G = Convert.ToInt32(tab[7]);
                            Couleur_tmp.B = Convert.ToInt32(tab[8]); // on met à jours la couleurs_temporaire; // on crée la couleur RGB
                            Ellipse New_Ellipse = new Ellipse(Convert.ToInt32(tab[1]), Point_tmp, Convert.ToInt32(tab[4]), Convert.ToInt32(tab[5]), Couleur_tmp, Convert.ToInt32(tab[9]));
                            New_Ellipse.MESSAGE_SVG = "<ellipse cx=\"" + New_Ellipse.Pt_Ellipse.X + "\" cy=\"" + New_Ellipse.Pt_Ellipse.Y + "\" rx=\"" + New_Ellipse.R_x + "\" ry=\"" + New_Ellipse.R_y + "\" style=\"fill:rgb(" + New_Ellipse.Figure_Couleur.R + "," + New_Ellipse.Figure_Couleur.G + "," + New_Ellipse.Figure_Couleur.B + ")\" />";
                            Ajout_Figure_au_Dessin(New_Ellipse);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erreur" + e.Message);
                        }
                        #endregion
                        break;

                    case "Rectangle":
                        #region
                        Console.WriteLine("RECTANGLE");
                        try
                        {
                            //for (int i = 1; i <= tab.Length - 1; i++)
                            //{
                            //    Console.WriteLine("        " + tab[i]);
                            //}

                            Point_tmp.X = Convert.ToInt32(tab[2]);
                            Point_tmp.Y = Convert.ToInt32(tab[3]); // on récupère les coordonné du point x et Y;

                            Couleur_tmp.R = Convert.ToInt32(tab[6]);
                            Couleur_tmp.G = Convert.ToInt32(tab[7]);
                            Couleur_tmp.B = Convert.ToInt32(tab[8]); // on met à jours la couleurs_temporaire

                            Rectangle New_Rectangle = new Rectangle(Convert.ToInt32(tab[1]), Point_tmp, Convert.ToInt32(tab[4]), Convert.ToInt32(tab[5]), Couleur_tmp, Convert.ToInt32(tab[9]));  // on crée le cercle avec le point et la couleur
                                                                                                                                                                                                  //edite le message svg
                            New_Rectangle.MESSAGE_SVG = "<rect x=\"" + New_Rectangle.Pt_High_Left.X + "\" y=\"" + New_Rectangle.Pt_High_Left.Y + "\" width=\"" + New_Rectangle.Largeur + "\" height=\"" + New_Rectangle.Hauteur + "\" style=\"fill:rgb(" + New_Rectangle.Figure_Couleur.R + "," + New_Rectangle.Figure_Couleur.G + "," + New_Rectangle.Figure_Couleur.B + ")\" />";
                            Ajout_Figure_au_Dessin(New_Rectangle);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erreur" + e.Message);
                        }
                        #endregion
                        break;

                    case "Texte":
                        #region
                        Console.WriteLine("TEXTE");
                        try
                        {
                            Point_tmp.X = Convert.ToInt32(tab[2]);
                            Point_tmp.Y = Convert.ToInt32(tab[3]); // on récupère les coordonné du point x et Y;

                            Couleur_tmp.R = Convert.ToInt32(tab[5]);
                            Couleur_tmp.G = Convert.ToInt32(tab[6]);
                            Couleur_tmp.B = Convert.ToInt32(tab[7]); // on met à jours la couleurs_temporaire

                            Texte New_Texte = new Texte(Convert.ToInt32(tab[1]), Point_tmp, tab[4], Couleur_tmp, Convert.ToInt32(tab[1]));
                            New_Texte.MESSAGE_SVG = "<text x=\"" + New_Texte.Pt_Texte.X + "\" y=\"" + New_Texte.Pt_Texte.Y + "\" fill=\"rgb(" + New_Texte.Figure_Couleur.R + "," + New_Texte.Figure_Couleur.G + "," + New_Texte.Figure_Couleur.B + ")\">" + New_Texte.Contenu + "</text>";

                            Ajout_Figure_au_Dessin(New_Texte);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erreur" + e.Message);
                        }
                        #endregion
                        break;

                    case "Polygone":
                        #region
                        Console.WriteLine("POLYGONE");
                        try
                        {
                            List<Point> Lst_Point_Polygone = new List<Point>();
                            string ligne_des_points = tab[2];               
                            
                            Couleur_tmp.R = Convert.ToInt32(tab[3]);
                            Couleur_tmp.G = Convert.ToInt32(tab[4]);
                            Couleur_tmp.B = Convert.ToInt32(tab[5]); // on met à jours la couleurs_temporaire

                            Polygone New_Polygone = new Polygone(Convert.ToInt32(tab[1]), Lst_Point_Polygone, Couleur_tmp, Convert.ToInt32(tab[6])); // on créer le polynome
                            New_Polygone.MESSAGE_SVG = "<polygon points=\"" + ligne_des_points + "\" style=\"fill:rgb(" + New_Polygone.Figure_Couleur.R + "," + New_Polygone.Figure_Couleur.G + "," + New_Polygone.Figure_Couleur.B + ")\" />"; ;
                            Ajout_Figure_au_Dessin(New_Polygone); // on l'ajoute au dessin
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erreur" + e.Message);

                        }
                        #endregion
                        break;

                    case "Chemin":
                        #region
                        Console.WriteLine("CHEMIN");
                        try
                        {
                            Couleur_tmp.R = Convert.ToInt32(tab[3]);
                            Couleur_tmp.G = Convert.ToInt32(tab[4]);
                            Couleur_tmp.B = Convert.ToInt32(tab[5]);

                            Chemin New_Chemin = new Chemin(Convert.ToInt32(tab[1]), tab[2], Couleur_tmp, Convert.ToInt32(tab[6]));
                            New_Chemin.MESSAGE_SVG = "<path d=\"" + New_Chemin.Path + "\" style=\"fill:rgb(" + New_Chemin.Figure_Couleur.R + "," + New_Chemin.Figure_Couleur.G + "," + New_Chemin.Figure_Couleur.B + ")\" />";
                            Ajout_Figure_au_Dessin(New_Chemin);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erreur" + e.Message);
                        }
                        #endregion
                        break;

                    case "Translation":
                        #region
                        Console.WriteLine("TRANSLATION");
                        try
                        {
                            for (int i = 0; i < Liste_figure.Count; i++)
                            {
                                if (Liste_figure[i].ID == Convert.ToInt32(tab[1])) // on parcours les figures jusqu'à toruver celle dont l'id correspond à celui sur laquelle s'applique la transformation
                                {
                                    if (Liste_figure[i] is Itranslatable) // on vérifie si la figure est translatable, car la translation n'est pas applicable à toutes les figures
                                    {
                                        if (Convert.ToString(Liste_figure[i].GetType()) == "TD_Final.Texte") // si c'est un cercle on traite la translation de façon particulière
                                        {
                                            Texte MonTexte = Liste_figure[i] as Texte;

                                            Liste_figure[i].MESSAGE_SVG = Liste_figure[i].MESSAGE_SVG.Substring(0, Liste_figure[i].MESSAGE_SVG.Length - 8 - MonTexte.Contenu.Length) + " transform=\"translate(" + tab[2] + "," + tab[3] + ")\" >" + MonTexte.Contenu + "</text>";
                                            Console.WriteLine(Liste_figure[i].MESSAGE_SVG);
                                        }
                                        else // ici la figure n'est pas un texte, on applique donc le traitement "classique"
                                        {
                                            if (Liste_figure[i].MESSAGE_SVG.Contains("transform")) // transform est présent dans le message, c'est donc la seconde transformation que l'on applique à cette figure, il ne faut pas oublier de marquer le "transform"
                                            {
                                                Liste_figure[i].MESSAGE_SVG = Liste_figure[i].MESSAGE_SVG.Substring(0, Liste_figure[i].MESSAGE_SVG.Length - 4) + " translate(" + tab[2] + "," + tab[3] + ")\" />";
                                                Console.WriteLine(Liste_figure[i].MESSAGE_SVG);
                                            }
                                            else // "transform" n'est pas présent dans le message c'est donc que c'ets la première transformation que l'on applique à cette figure. pas besoin de mettre transform.
                                            {
                                                Liste_figure[i].MESSAGE_SVG = Liste_figure[i].MESSAGE_SVG.Substring(0, Liste_figure[i].MESSAGE_SVG.Length - 3) + " transform=\"translate(" + tab[2] + "," + tab[3] + ")\" />";
                                                Console.WriteLine(Liste_figure[i].MESSAGE_SVG);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("La figure n'est pas translatable");
                                    }
                                }
                            }
                        }// fin du try
                        catch (Exception e)
                        {
                            Console.WriteLine("Erreur" + e.Message);
                        }
                        #endregion
                        break;

                    case "Rotation":
                        #region
                        Console.WriteLine("Rotation");

                        try
                        {
                            for (int i = 0; i < Liste_figure.Count; i++)
                            {
                                if (Liste_figure[i].ID == Convert.ToInt32(tab[1])) // on parcours les figures jusqu'à toruver celle dont l'id correspond à celui sur laquelle s'applique la transformation
                                {
                                    if (Liste_figure[i] is Irotationnable) // on vérifie que la figure est rotationnable.
                                    {
                                        if (Liste_figure[i].MESSAGE_SVG.Contains("transform")) // transform est présent dans le message, c'est donc la seconde transformation que l'on applique à cette figure, il ne faut pas oublier de marquer le "transform"
                                        {
                                            Liste_figure[i].MESSAGE_SVG = Liste_figure[i].MESSAGE_SVG.Substring(0, Liste_figure[i].MESSAGE_SVG.Length - 4) + " rotate(" + tab[2] + " " + tab[3] + "," + tab[4] + ")\" />";
                                            Console.WriteLine(Liste_figure[i].MESSAGE_SVG);
                                        }
                                        else // transform n'est pas présent dans le message c'est donc que c'ets la première transformation que l'on applique à cette figure. pas besoin de mettre transform.
                                        {
                                            Liste_figure[i].MESSAGE_SVG = Liste_figure[i].MESSAGE_SVG.Substring(0, Liste_figure[i].MESSAGE_SVG.Length - 3) + " transform=\"rotate(" + tab[2] + " " + tab[3] + "," + tab[4] + ")\" />";
                                            Console.WriteLine(Liste_figure[i].MESSAGE_SVG);
                                        }
                                    }
                                    else 
                                    {
                                        Console.WriteLine("La figure n'est pas Rotationnable");
                                    }
                                }
                            }                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erreur" + e.Message);
                        }
                        #endregion
                        break;

                    default:
                        Console.WriteLine("Default case : Le nom de la forme est mal orthographié ou bien n'est pas pri en compte par ce convertisseur ");
                        break;
                }
                ligne = monStreamReader.ReadLine();
            }

            /////////////////////////////////////////////////// Zone de Test ///////////////////////////////////////
            Console.WriteLine();
            Console.WriteLine("////////////////////////////////////////////////////////////////////");
            Console.WriteLine("/////////////////////////     TEST     /////////////////////////////");
            Console.WriteLine("///////////////////////// Les ToString /////////////////////////////");
            Console.WriteLine("////////////////////////////////////////////////////////////////////");
            Console.WriteLine();

            Afficher_liste_figure();
            Console.WriteLine(); Console.WriteLine();


            Console.WriteLine("////////////////////////////////////////////////////////////////////");
            Console.WriteLine("/////////////////////////     TEST      ////////////////////////////");
            Console.WriteLine("/////////////////////////  Message SVG  ////////////////////////////");
            Console.WriteLine("////////////////////////////////////////////////////////////////////");
            Console.WriteLine();

            for (int i = 0; i < Liste_figure.Count; i++)
            {
                Console.WriteLine(Liste_figure[i].MESSAGE_SVG);
            }

            Sauvegarder_en_SVG(CheminSortie);
        }

        //ToString
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
