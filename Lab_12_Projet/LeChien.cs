using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_Projet
{
    internal class LeChien : Serveur
    {
        //Constructeur
        public LeChien(string nom) : base(nom)
        {

        }
        //Méthode
        public override decimal Bonus(decimal argent)
        {
            argent *= 1.1567m;
            return argent;
        }
    }
}
