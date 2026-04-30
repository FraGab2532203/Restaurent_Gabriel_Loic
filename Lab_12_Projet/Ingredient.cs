using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_Projet
{
    internal class Ingredient
    {
        private int id;
        private string nom;
        private decimal prix;
        private decimal quantite;
        private string type;

        public int Id
        {
            get { return id; }
        }
        public string Nom
        {
            get { return nom; }
        }
        public string Type
        {
            get { return type; }
        }
        public decimal Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        public decimal Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
        
        public Ingredient(int id, string nom, decimal quantite, string type)
        {
            this.id = id;
            this.nom = nom;
            this.quantite = quantite;
            this.type = type;

        }

        public override string ToString()
        {
            return $"{nom}, {quantite} {type}";
        }
    }
}
