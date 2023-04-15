using MySql.Data.MySqlClient;
using transport.Data.Entity;

namespace transport.Data.Repository
{
    class ExpeditionsRepository
    {
        public List<Expeditions> FindAll()
        {
            var list = new List<Expeditions>();
            MySqlConnection? connection = null;
            try
            {
                connection = DBConnection.GetConnection();
                connection.Open();
                var request = new MySqlCommand("SELECT * FROM expeditions", connection);
                var result = request.ExecuteReader();
                while (result.Read())
                {
                    var expeditions = new Expeditions(
                        result.GetDateTime("date_expedition"),
                        result.GetDateTime("date_livraison_prevue"),
                        result.GetDateTime("date_livraison_reelle"),
                        result.GetInt32("id_entrepot_destination"),
                        result.GetString("statut"),
                        result.GetInt32("id_entrepot_source"),
                        result.GetInt32("pois"), result.GetInt32("id"));
                    list.Add(expeditions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EntrepotsRepository error : " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }
            return list;
        }
        public void Save(Expeditions expeditions)
        {
            MySqlConnection? connection = null;
            try
            {
                connection = DBConnection.GetConnection();
                connection.Open();

                var request = new MySqlCommand("INSER INTO expeditions(date_expedition, date_livraison_prevue, date_livraison_reelle, pois, statut) VALUES (@dateexpedition, @datelivraisonprevue, @datelivraisonreelle, @pois, @statut)", connection);
                request.Parameters.AddWithValue("@dateexpedition", expeditions.DateExpedition);
                request.Parameters.AddWithValue("@datelivraisonprevue", expeditions.DateLivraisonPrevue);
                request.Parameters.AddWithValue("@datelivraisonreelle", expeditions.DateLivraisonReelle);
                request.Parameters.AddWithValue("@pois", expeditions.Pois);
                request.Parameters.AddWithValue("@statut", expeditions.Statut);

                request.ExecuteNonQuery();
                expeditions.Id = (int?)request.LastInsertedId;
                expeditions.IdEntrepotSource = (int?)request.LastInsertedId;
                expeditions.IdEntrepotDestination = (int?)request.LastInsertedId;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ExpeditionsRepository error : " + ex.Message);
            }finally { 
                connection?.Close(); 
            }
        }
        public bool  Update(Expeditions expeditions)
        {
            MySqlConnection? connection = null;
            try
            {
                connection = DBConnection.GetConnection();
                connection.Open();
                var request = new MySqlCommand("UPDATE expeditions SET date_expedition=@dateexpedition, date_livraison_prevue=@datelivraisonprevue, date_livraison_reelle=@datelivraisonreelle, pois=@pois, statut=@statut)", connection);
                request.Parameters.AddWithValue("@dateexpedition", expeditions.DateExpedition);
                request.Parameters.AddWithValue("@datelivraisonprevue", expeditions.DateLivraisonPrevue);
                request.Parameters.AddWithValue("@datelivraisonreelle", expeditions.DateLivraisonReelle);
                request.Parameters.AddWithValue("@pois", expeditions.Pois);
                request.Parameters.AddWithValue("@statut", expeditions.Statut);
                request.Parameters.AddWithValue("@id", expeditions.Id);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ExpeditionsRepository error : " + ex.Message);
            }
            finally 
            { 
                connection?.Close(); 
            }
            return false;
        }
        public bool Delete(Expeditions expeditions) 
        {
            MySqlConnection? connection = null;
            try
            {
                connection = DBConnection.GetConnection();
                connection.Open();
                var request = new MySqlCommand("DELETE FROM expeditions WHERE id=@id", connection);
                request.Parameters.AddWithValue("@id", expeditions.Id);

                if(request.ExecuteNonQuery()>0)
                {
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ExpeditionsRepository error : " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }
            return false;

        }
        private Expeditions sqlToDog(MySqlDataReader result)
        {
            return new Expeditions(
                result.GetDateTime("date_expedition"), 
                result.GetDateTime("date_livraison_prevue"), 
                result.GetDateTime("date_livraison_reelle"), 
                result.GetInt32("pois"), 
                result.GetString("statut"), 
                result.GetInt32("id_entrepot_source"), 
                result.GetInt32("id_entrepot_destination"), 
                result.GetInt32("id"));
        }
    }
    
}