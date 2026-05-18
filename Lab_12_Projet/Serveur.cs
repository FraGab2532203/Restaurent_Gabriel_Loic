using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_Projet
{
    public abstract class Serveur
    {
        //Attributs
        private string nom;
        private decimal fondRecup;
        //Paramêtre
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public decimal FondRecup
        {
            get { return fondRecup; }
            set { fondRecup = value; }
        }
        //Constructeur
        public Serveur(string nom)
        {
            this.nom = nom;
        }
        //Méthode
        public abstract decimal Bonus(decimal argent);
    }
}
