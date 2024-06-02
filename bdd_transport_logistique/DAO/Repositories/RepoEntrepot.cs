using MySql.Data.MySqlClient;
using repository.Entities;

namespace repository.Repositories
{
    public class RepoEntrepot
    {
        public List<Entrepots> FindAll()
        {
            var listeEntrepots = new List<Entrepots>();

            MySqlConnection? connection = null;

            try
            {
                connection = DbConnection.GetConnection();

                connection.Open();

                var request = new MySqlCommand("select * from entrepots", connection);

                var result = request.ExecuteReader();

                while (result.Read())
                {
                    var entrepot = sqlToEntrepots(result);

                    listeEntrepots.Add(entrepot);
                }

            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur RepoEntrepot : " + ex.Message);
            }

            finally
            {
                connection?.Close();
            }

            return listeEntrepots;
        }

        private Entrepots sqlToEntrepots(MySqlDataReader result)
        {
            return new Entrepots(result.GetString("nom_entrepot"), result.GetString("adresse"), result.GetString("ville"), result.GetString("pays"), result.GetString("continent"), result.GetInt32("id"));
        }
    }
}
