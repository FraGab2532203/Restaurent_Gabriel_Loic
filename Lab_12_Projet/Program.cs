using Lab_11_trycatch_dll;
using Lab_12_Projet.DataAccess;
using Lab_12_Projet.Model;
using MySql.Data.MySqlClient;
using PersonLibrary;
using PersonLibrary.Model;
using System.Data;
using ANSIConsole;
using System.Drawing;

namespace Lab_12_Projet
{
    internal class Program
    {

        static void Menu()
        {
            Console.Clear();
            ChoixMenu();
        }

        static void Main(string[] args)
        {

            PersonGenerator.LoadPeople();
            Person p = PersonGenerator.GetRandomPerson();
            Console.WriteLine(p.GetInfo("fr"));
            Console.WriteLine(p.GetInfo("en"));

            GestionnaireBd gestionnaireBd = new GestionnaireBd("server=localhost;database=restaurant;uid=root;pwd=;");

            var plats = gestionnaireBd.GetPlats();

            foreach (Plat plat in plats)
                CustomConsole.WriteSuccess(plat.ToString());
            Choix();
        }

        static void Choix()
        {
            ANSIConsole.ANSIString[] options = { "Aller au resto".Color(Color.White), "Quitter".Color(Color.IndianRed) };
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
        static void ChoixMenu()
        {
            resto restaurent = new resto();
            string[] options = { "Acheter un serveur", "Servir les clients", "Changer le menu", "Achter des ingrédients", "Achter une nouvelle recette" };
            int index = 0;
            bool running = true;

            while (running)
            {
                Console.Clear();

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
                            restaurent.AcheterServeur();
                        }
                        else if (index == 1)
                        {
                            running = false;
                            Console.WriteLine("Client");
                        }
                        else if (index ==2)
                        {
                            running = false;
                            Console.WriteLine("ingrédients");
                        }
                        else if (index == 3)
                        {
                            running = false;
                            Console.WriteLine("ingrédients");
                        }
                        else if (index == 4)
                        {
                            running = false;
                            Console.WriteLine("ingrédients");
                        }
                        break;
                }
            }
        }
        static void ImageResto()
        {
            ANSIConsole.ANSIString reto = "RESTAURANT".Color(Color.Green);
            CustomConsole.WriteMessage("********** Bienvenue au Resto ! **********\n",ConsoleColor.Yellow);

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
            Console.WriteLine($"     |   {reto}  |  |  |");
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

            CustomConsole.WriteMessage("******** Entrez dans le restaurent ********",ConsoleColor.Yellow);
        }
    }
}

