using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_Projet
{
    internal class LeCheap : Serveur
    {
        //Constructeur
        public LeCheap(string nom) : base(nom)
        {

        }
        //Méthode
        public override decimal Bonus(decimal argent)
        {
            argent *= 1.05m;
            return argent;
        }
    }
}
