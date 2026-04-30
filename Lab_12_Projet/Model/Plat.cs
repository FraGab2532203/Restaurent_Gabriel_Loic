using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_Projet.Model
{
    internal class Plat
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public Decimal Prix { get; set; }
        public string Categorie { get; set; }

        public Plat(int id, string nom, string description, decimal prix, string categorie)
        {
            Id = id;
            Nom = nom;
            Description = description;
            Prix = prix;
            Categorie = categorie;
        }

        public override string ToString()
        {
            return $"{Id} - {Nom} - {Description} - {Prix} - {Categorie}";
        }
    }
}
