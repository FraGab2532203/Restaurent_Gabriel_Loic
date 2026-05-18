using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_Projet
{
    internal class HommeGambling : Serveur
    {
        private Random rng = new Random();
        //Constructeur
        public HommeGambling(string nom) : base(nom)
        {

        }
        //Méthode
        public override decimal Bonus(decimal argent)
        {
            int nombre = rng.Next(0, 2);
            if (nombre == 1)
                argent *= 2;
            else
                argent = 0;
            return argent;
        }
    }
}
