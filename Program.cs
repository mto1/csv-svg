using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TD_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Dessin MonDessin = new Dessin();
            string chemin = @"../../../csv_svg/ExempleTout.csv"; //emplacement du fichier à convertir. chemin relatif par rapport à dossier bin/debug.
            string cheminSortie = @"../../../csv_svg/Mon_SVG.svg"; //emplacement du fichier de sortie. chemin relatif par rapport au dossier bin/debug.
            MonDessin.Convertion_CSV_SVG(chemin,cheminSortie);
            Console.ReadLine();
        }
    }
}
