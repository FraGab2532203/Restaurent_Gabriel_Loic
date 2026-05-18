using Lab_12_Projet.DataAccess;
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
        public List<Ingredient> listIngredient = new List<Ingredient>();
        public List<Ingredient> ListIngredient
        {
            get {  return listIngredient; }
            set { listIngredient = value; }
        }


        public Plat(int id, string nom, string description, decimal prix, string categorie)
        {
            Id = id;
            Nom = nom;
            Description = description;
            Prix = prix;
            Categorie = categorie;
            
        }
        public void ListIngredientAdd(Ingredient ingredient)
        {
            listIngredient.Add(ingredient);
        }

        public override string ToString()
        {
            string text = "";
            foreach (Ingredient ingredient in listIngredient)
            {
                text += $"{ingredient.Nom} {ingredient.Quantite}";
            }
            return $"{Categorie} - {Id} - {Nom} - {Description} - {Prix} - {text}";
        }
    }
}
