using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_Projet
{
    internal class HommeNue : Serveur
    {
        private Random rng = new Random();

        //Constructeur
        public HommeNue(string nom) : base(nom)
        {

        }
        //Méthode
        public override decimal Bonus(decimal argent)
        {
            int nombre = rng.Next(0, 3);
            if (nombre == 2)
                argent *= 1;
            else if (nombre == 1)
                argent *= 1.50m;
            else
                argent *= 0;
            return argent;
        }
    }
}
