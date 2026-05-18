using Lab_11_trycatch_dll;
using Lab_12_Projet.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

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
                    List<Dictionary<string, object>> rows = ExecuteSelect((
                        "SELECT ingredients.id AS idP, ingredients.nom AS nomP, unites.nom AS nom_uniteP, inventaire.quantite_stock, ingredients.prix, "+
                        "plats.id AS id, plats.nom AS nom, plats.description, plats.prix, categories.nom AS nomC, plat_ingredients.quantite AS qnt " +
                        "FROM plats left JOIN plat_ingredients ON plat_ingredients.plat_id = plats.id "+
                        "left JOIN ingredients ON plat_ingredients.ingredient_id = ingredients.id "+
                        "left JOIN categories on categories.id = plats.id "+
                        "left JOIN unites ON unites.id = ingredients.unite_id "+
                        "left JOIN inventaire ON inventaire.ingredient_id = ingredients.id "));
                        foreach (var row in rows)
                    {
                        plats.Add(new Plat(
                            Convert.ToInt32(row["id"]),
                            row["nom"].ToString(),
                            row["description"].ToString(),
                            Convert.ToDecimal(row["prix"]),
                            row["nomC"].ToString()
                            ));
                        foreach (Plat platss in plats)
                        {
                            if (row["nom"] == platss.Nom)
                            {
                                platss.ListIngredientAdd(new Ingredient(
                                    Convert.ToInt32(row["idP"]),
                                row["nomP"].ToString(),
                                Convert.ToDecimal(row["qnt"]),
                                row["nom_uniteP"].ToString(),
                                Convert.ToDecimal(row["prix"])
                                ));
                            }
                        }

                        
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
                        "SELECT ingredients.id AS id, ingredients.nom AS nom, unites.nom AS nom_unite, inventaire.quantite_stock, ingredients.prix " +
                        "FROM ingredients left JOIN inventaire ON inventaire.ingredient_id = ingredients.id " +
                        "left JOIN unites ON unites.id = ingredients.unite_id");
                    foreach (var row in rows)
                    {
                        ingredient.Add(new Ingredient(
                            Convert.ToInt32(row["id"]),
                            row["nom"].ToString(),
                            Convert.ToDecimal(row["quantite_stock"]),
                            row["nom_unite"].ToString(),
                            Convert.ToDecimal(row["prix"])
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
