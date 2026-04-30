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
        }
    }
}
