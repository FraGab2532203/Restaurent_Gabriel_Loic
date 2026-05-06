using ANSIConsole;
using Google.Protobuf.WellKnownTypes;
using Lab_11_trycatch_dll;
using Lab_12_Projet.DataAccess;
using Lab_12_Projet.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_Projet
{
    internal class resto
    {
        //attributs
        private List<Serveur> serveurs = new List<Serveur>();
        private decimal banque = 1000;
        //Constructeur

        //Méthode
        public void AcheterServeur()
        {

            ANSIConsole.ANSIString[] options = { "Boîte commun -> 250$".Color(Color.White), "Boîte rare -> 500$".Color(Color.Cyan), "boite épique -> 1000$".Color(Color.Violet), "Quitter".Color(Color.IndianRed) };
            int index = 0;
            bool running = true;

            while (running)
            {
                Console.Clear();
                CustomConsole.WriteMessage("******** Menu Des Boîtes ********",ConsoleColor.Yellow);

                // Affichage du menu
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == index)
                    {
                        CustomConsole.WriteMessage("> " + options[i], ConsoleColor.Yellow);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("  " + options[i]);
                    }
                }

                // Lecture des touches
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0) index = options.Length - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        index++;
                        if (index >= options.Length) index = 0;
                        break;

                    case ConsoleKey.Enter:
                        if (index == 0)
                        {
                            running = false;
                        }
                        else if (index == 1)
                        {
                            running = false;
                        }
                        else if (index == 2)
                        {
                            running = false;
                        }
                        else if (index == 3)
                        {
                            running = false;
                        }
                        break;
                }
            }
        }

        public void AcheterIngredient()
        {
            string reponce = "";
            List<Ingredient> listIngredient = new List<Ingredient>();
            GestionnaireBd gestionnaireBd = new GestionnaireBd("server=localhost;database=restaurant;uid=root;pwd=;");
            var ingredients = gestionnaireBd.GetIngredient();
            foreach (Ingredient ingredient in ingredients)
            {
                CustomConsole.WriteSuccess(ingredient.ToString());
                listIngredient.Add(ingredient);
            }
            reponce = Console.ReadLine();
            foreach (Ingredient ingredient in listIngredient)
            {
                if (ingredient.Nom == reponce)
                {
                    if(ingredient.Prix <= banque)
                    {
                        Console.WriteLine(ingredient);
                        banque-=ingredient.Prix;
                        ingredient.AcheterIngredients();
                        Console.WriteLine(ingredient);
                        Console.WriteLine(banque);
                        Console.ReadLine();
                    }
                }
            }
        }
        public void AfficherMenu()
        {
            GestionnaireBd gestionnaireBd = new GestionnaireBd("server=localhost;database=restaurant;uid=root;pwd=;");
            var plats = gestionnaireBd.GetPlats();
            foreach (Plat plat in plats)
                CustomConsole.WriteSuccess(plat.ToString());
            Console.ReadLine();
        }

    }
}
