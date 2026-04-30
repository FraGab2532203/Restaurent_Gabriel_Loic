using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Lab_12_Projet.Model;
using Lab_11_trycatch_dll;

namespace Lab_12_Projet
{
    namespace DataAccess
    {
        internal class GestionnaireBd
        {
            private readonly string connectionString;

            public GestionnaireBd(string connectionString)
            {
                this.connectionString = connectionString;
            }

            public List<Dictionary<string, object>> ExecuteSelect(string query, params MySqlParameter[] parameters)
            {
                var results = new List<Dictionary<string, object>>();

                using MySqlConnection connection = new MySqlConnection(connectionString);
                using MySqlCommand command = new MySqlCommand(query, connection);

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();

                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }

                    results.Add(row);
                }

                return results;
            }

            public List<Plat> GetPlats()
            {
                List<Plat> plats = new List<Plat>();
                try
                {
                    List<Dictionary<string, object>> rows = ExecuteSelect(("SELECT * FROM plats INNER JOIN categories on categories.id = plats.id"));
                    foreach(var row in rows)
                    {
                        plats.Add(new Plat(
                            Convert.ToInt32(row["id"]), 
                            row["nom"].ToString(), 
                            row["description"].ToString(), 
                            Convert.ToDecimal(row["prix"]), 
                            row["nom"].ToString()
                            ));
                    }
                }
                catch (Exception ex)
                {
                    CustomConsole.WriteError(ex.Message);
                }
                return plats;
            }

            public List<Ingredient> GetIngredient()
            {
                List<Ingredient> ingredient = new List<Ingredient>();
                try
                {
                    List<Dictionary<string, object>> rows = ExecuteSelect(
                        "SELECT ingredients.id AS id, ingredients.nom AS nom, unites.nom AS nom_unite, inventaire.quantite_stock " +
                        "FROM ingredients JOIN inventaire ON inventaire.ingredient_id = ingredients.id " +
                        "JOIN unites ON unites.id = ingredients.id");
                    foreach (var row in rows)
                    {
                        ingredient.Add(new Ingredient(
                            Convert.ToInt32(row["id"]),
                            row["nom"].ToString(),
                            Convert.ToDecimal(row["quantite_stock"]),
                            row["nom_unite"].ToString()
                            ));
                    }
                }
                catch (Exception ex)
                {
                    CustomConsole.WriteError(ex.Message);
                }
                return ingredient;
            }
        }
    }
}
