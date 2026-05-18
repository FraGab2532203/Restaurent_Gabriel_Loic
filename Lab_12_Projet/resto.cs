using ANSIConsole;
using Google.Protobuf.WellKnownTypes;
using Lab_11_trycatch_dll;
using Lab_12_Projet.DataAccess;
using Lab_12_Projet.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using PersonLibrary;
using PersonLibrary.Model;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_Projet
{
    internal class resto
    {
        //attributs
        static Random rng = new Random();
        private List<Serveur> serveurs = new List<Serveur>();
        private decimal banque = 1000;
        static GestionnaireBd gestionnaireBd = new GestionnaireBd("server=localhost;database=restaurant;uid=root;pwd=;");
        private List<Plat> recetteDeblo = gestionnaireBd.GetPlats();

        //Parametre
        public List<Serveur> Serveurs
        {
            get { return serveurs; }
            set { serveurs = value; }
        }
        public decimal Banque
        {
            get { return banque; }
            set { banque = value; }
        }
        public List<Plat> RecetteDeblo
        {
            get { return recetteDeblo; }
            set { recetteDeblo = value; }
        }
        //Constructeur

        //Méthode
        public void MarcheNoir()
        {

            Console.Clear();
            /*LeChien nue = new LeChien("Loïc");
            decimal argent = 100m;
            argent = nue.Bonus(argent);
            Console.WriteLine(argent);*/
            for (int i = 0; i < serveurs.Count; i++)
                Console.WriteLine($"{serveurs[i].Nom} est votre serveur");
            string serveurChoisit = Console.ReadLine();
            if (serveurChoisit == "Joseph")
            {
                Console.WriteLine("Vous ne pouvez pas vendre le clochard, personne n'en veut");
                Console.ReadLine();
            }
            else
                for (int i = 0; i < serveurs.Count; i++)
                    if (serveurChoisit == serveurs[i].Nom)
                        serveurs.Remove(serveurs[i]);
        }
        public void AcheterServeur()
        {
            ANSIConsole.ANSIString[] options = { "Boîte commun -> 250$".Color(Color.White), "Boîte rare -> 500$".Color(Color.Cyan), "boite épique -> 1000$".Color(Color.Violet), "Quitter".Color(Color.IndianRed) };
            int index = 0;
            bool running = true;
            if (serveurs.Count == 3)
                return;
            while (running)
            {
                Console.Clear();
                CustomConsole.WriteMessage("******** Menu Des Boîtes ********", ConsoleColor.Yellow);
                // Affichage du menu
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == index)
                    {
                        CustomConsole.WriteMessage("> " + options[i], ConsoleColor.Yellow);
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine("  " + options[i]);
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
                        if (index == 0 && banque >= 250)
                        {
                            banque -= 250;
                            int nombre = rng.Next(1, 100);
                            if (nombre < 50)
                                serveurs.Add(new LeClochard("Joseph"));
                            else if (nombre < 80)
                                serveurs.Add(new LeCheap("Gabriel"));
                            else
                                serveurs.Add(new HommeNue("Justin"));
                            running = false;
                        }
                        else if (index == 1 && banque >= 500)
                        {
                            banque -= 500;
                            int nombre = rng.Next(1, 100);
                            if (nombre < 10)
                                serveurs.Add(new LeClochard("Joseph"));
                            else if (nombre < 80)
                                serveurs.Add(new HommeNue("Justin"));
                            else
                                serveurs.Add(new HommeGambling("Victor"));
                            running = false;
                        }
                        else if (index == 2 && banque >= 1000)
                        {
                            banque -= 1000;
                            int nombre = rng.Next(1, 100);
                            if (nombre < 5)
                                serveurs.Add(new LeClochard("Joseph"));
                            else if (nombre < 20)
                                serveurs.Add(new HommeNue("Justin"));
                            else if (nombre < 70)
                                serveurs.Add(new HommeGambling("Victor"));
                            else
                                serveurs.Add(new LeChien("Loïc"));
                            running = false;
                        }
                        else if (index == 3)
                            running = false;
                        break;
                }
            }
        }
        public void FairePlat(Plat plat)
        {
            foreach (Ingredient ingre in plat.listIngredient)
            {
                ingre
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
                    if (ingredient.Prix <= banque)
                    {
                        Console.WriteLine(ingredient);
                        banque -= ingredient.Prix;
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
            List<Plat> plats = gestionnaireBd.GetPlats();
            for (int i = 0; i < plats.Count; i++)
                Console.WriteLine(plats[i]);
            Console.ReadLine();

        }
        public void AfficherClient()
        {
            Console.Clear();
            GestionnaireBd gestionnaireBd = new GestionnaireBd("server=localhost;database=restaurant;uid=root;pwd=;");
            List<Plat> plats = gestionnaireBd.GetPlats();
            List<Plat> platsPersonne = new List<Plat>();
            List<Person> persons = new List<Person>();
            decimal prixTotal = 0;
            int nbPersonne = rng.Next(0, 5);
            for (int i = 0; i < nbPersonne; i++)
            {
                platsPersonne.Add(plats[rng.Next(plats.Count)]);
                PersonGenerator.LoadPeople();
                persons.Add(PersonGenerator.GetRandomPerson());
                prixTotal += platsPersonne[i].Prix;
                Console.WriteLine(persons[i].GetInfo("fr") + " " + platsPersonne[i]);
            }
            decimal bonusTotal = 0;
            Console.WriteLine("sans bonus " + prixTotal);
            AppliquerBonus(bonusTotal, prixTotal);

        }
        public void AppliquerBonus(decimal bonusTotal,decimal prixTotal)
        {
            if (serveurs.Count != 0)
                for (int i = 0; i < serveurs.Count; i++)
                    bonusTotal += serveurs[i].Bonus(prixTotal);
            if (bonusTotal == 0)
                banque += prixTotal;
            else
            {
                Console.WriteLine("Avec bonus " + bonusTotal);
                banque += bonusTotal;
            }
            Console.ReadLine();
        }
        public void AcheterDesRecettes()
        {
            GestionnaireBd gestionnaireBd = new GestionnaireBd("server=localhost;database=restaurant;uid=root;pwd=;");
            List<Plat> plats = gestionnaireBd.GetToutPlats();
            for (int i = 0; i < plats.Count; i++)
                Console.WriteLine(plats[i]);
            Console.WriteLine("Quelle recettes voulez-vous acheter ?");
            int nombre = 0;
            int.TryParse(Console.ReadLine(), out nombre);
            for (int i = 0; i < plats.Count; i++)
                if (plats[i].Id == nombre && plats[i].Prix < banque)
                {
                    recetteDeblo.Add(plats[i]);
                    banque -= recetteDeblo[i].Prix;
                }
        }
        public void RecetteDeverouiller()
        {
            for (int i = 0; i < recetteDeblo.Count; i++)
                Console.WriteLine(recetteDeblo[i]);
            Console.ReadLine();

        }
    }
}
