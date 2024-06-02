using MySql.Data.MySqlClient;
using repository.Entities;

namespace repository.Repositories
{
    public class RepoExpedition
    {
        public List<Expeditions> FindAll()
        {
            var listeExpeditions = new List<Expeditions>();

            MySqlConnection? connection = null;

            try
            {
                connection = DbConnection.GetConnection();

                connection.Open();

                var request = new MySqlCommand("select * from expeditions", connection);

                var result = request.ExecuteReader();

                while (result.Read())
                {
                    var expedition = sqlToExpeditions(result);

                    listeExpeditions.Add(expedition);
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

            return listeExpeditions;
        }

        private Expeditions sqlToExpeditions(MySqlDataReader result)
        {
            return new Expeditions(
                result.GetDateTime("date_expedition"),
                result.GetDateTime("date_livraison_prevue"),
                result.GetString("poids"),
                result.GetString("statut"),
                result.GetInt32("id_entrepot_source"),
                result.GetInt32("id_entrepot_destination"),
                result.GetInt32("id"),
                result.GetDateTime("date_livraison_reelle")
                );
        }
    }
}
