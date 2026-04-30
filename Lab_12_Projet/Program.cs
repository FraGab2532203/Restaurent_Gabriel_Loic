using Lab_11_trycatch_dll;
using Lab_12_Projet.DataAccess;
using Lab_12_Projet.Model;
using MySql.Data.MySqlClient;
using PersonLibrary;
using PersonLibrary.Model;
using System.Data;

namespace Lab_12_Projet
{
    internal class Program
    {

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu");
        }

        static void Main(string[] args)
        {

            PersonGenerator.LoadPeople();
            Person p = PersonGenerator.GetRandomPerson();
            Console.WriteLine(p.GetInfo("fr"));
            Console.WriteLine(p.GetInfo("en"));

            GestionnaireBd gestionnaireBd = new GestionnaireBd("server=localhost;database=restaurant;uid=root;pwd=;");

            var plats = gestionnaireBd.GetPlats();
            var ingredients = gestionnaireBd.GetIngredient();

            foreach (Plat plat in plats)
                CustomConsole.WriteSuccess(plat.ToString());
            foreach (Ingredient ingredient in ingredients)
                CustomConsole.WriteSuccess(ingredient.ToString());
            Choix();
        }
        static void Choix()
        {
            string[] options = { "🍽 Aller au resto", "🚪 Quitter" };
            int index = 0;
            bool running = true;

            while (running)
            {
                Console.Clear();
                ImageResto();

                // Affichage du menu
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("> " + options[i]);
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
                            Menu();
                        }
                        else if (index == 1)
                        {
                            running = false;
                        }
                        break;
                }
            }
        }
        static void ImageResto()
        {
            Console.WriteLine("********** Bienvenue au Resto ! **********\n");

            Console.WriteLine("              (  )   (   )");
            Console.WriteLine("               ) (   )  (");
            Console.WriteLine("              (   ) (   )");
            Console.WriteLine("               |||||");
            Console.WriteLine("           ____|||||________");
            Console.WriteLine("          /    |||||      /|");
            Console.WriteLine("         /     |||||     / |");
            Console.WriteLine("        /_______________/  |");
            Console.WriteLine("       /               /|  |");
            Console.WriteLine("      /               / |  |");
            Console.WriteLine("     /_______________/  |  |");
            Console.WriteLine("     |   RESTAURANT  |  |  |");
            Console.WriteLine("     |---------------|  |  |");
            Console.WriteLine("     |   []    []    |  |  |");
            Console.WriteLine("     |               |  |  |");
            Console.WriteLine("     |     ____      |  |  |");
            Console.WriteLine("     |    |MENU|     |  |  |");
            Console.WriteLine("     |    |____|     |  |  |");
            Console.WriteLine("     |               |  | /");
            Console.WriteLine("     |   [      ]    |  |/");
            Console.WriteLine("     |   [PORTE ]    | /");
            Console.WriteLine("     |_______________|/");

            Console.WriteLine("******** Entrez dans le restaurent ********");


            /*string entrer = "";
            do
            {
                entrer = Console.ReadLine();
                if (entrer == "entrer")
                    Menu();
                else
                   CustomConsole.WriteError("Saisi invalide, veuiller *entrer* ou *partir*");
            } while (entrer != "entrer" || entrer != "partir");*/
        }
    }
}

