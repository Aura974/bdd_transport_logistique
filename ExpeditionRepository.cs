using System.Data;

using Npgsql;
using transport_logistique.Entity;
using transport_logistique.Repository;

namespace transport_logistique.Repository
{
    class ExpeditionRepository
    {
        public List<Expedition> FindAll()
        {
            var list = new List<Expedition>();
            NpgsqlConnection? connection = null;
            try
            {
                connection = DbConnection.GetConnection();

                connection.Open();

                var request = new NpgsqlCommand("SELECT * FROM expeditions", connection);

                var result = request.ExecuteReader();

                while (result.Read())
                {
                    var expedition = new Expedition(
                        result.GetDateTime(result.GetOrdinal("date_expedition")),
                        result.GetDateTime(result.GetOrdinal("date_livraison_prevue")),
                        result.GetDateTime(result.GetOrdinal("date_livraison_reelle")),
                        result.GetInt32(result.GetOrdinal("id_entrepot_source")),
                        result.GetInt32(result.GetOrdinal("id_entrepot_destination")),
                        result.GetDecimal(result.GetOrdinal("poids")),
                        result.GetString(result.GetOrdinal("statut")),
                        result.GetInt32(result.GetOrdinal("id")));
                    list.Add(expedition);
                }

            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("expeditionRepository error : " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }

            return list;
        }

        public void Save(Expedition expedition)
        {
            NpgsqlConnection? connection = null;
            try
            {
                connection = DbConnection.GetConnection();

                connection.Open();

                var request = new Npgsql.NpgsqlCommand(
                    "INSERT INTO expeditions (date_expedition, date_livraison_prevue, date_livraison_reelle, id_entrepot_source, id_entrepot_destination, poids, statut) VALUES (@expedition, @livraison_prevue, @livraison, @expediteur, @destinataire, @poids, @statut)", connection);
                request.Parameters.AddWithValue("@expedition", expedition.Date_expedition);
                request.Parameters.AddWithValue("@livraison_prevue", expedition.Date_livraison_prevue);
                request.Parameters.AddWithValue("@livraison", expedition.Date_livraison_reelle);
                request.Parameters.AddWithValue("@expediteur", expedition.Id_entrepot_source);
                request.Parameters.AddWithValue("@destinataire", expedition.Id_entrepot_destination);
                request.Parameters.AddWithValue("@poids", expedition.Poids);
                request.Parameters.AddWithValue("@statut", expedition.Statut);


                var result = request.ExecuteNonQuery();
                expedition.Id = (int?)request.ExecuteScalar();


            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("transportRepo error : " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }
        }
    
        public void Update(Expedition expedition)
        {
            NpgsqlConnection? connection = null;
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                var request = new NpgsqlCommand(
                    "UPDATE expedition SET date_expedition=@expedition, date_livraison_prevue=@livraison_prevue, date_livraison_reelle=@livraison, id_entrepot_source=@expediteur, id_entrepot_destination=@destinataire, poids=@poids, statut=@statut WHERE id=@id", connection);
                request.Parameters.AddWithValue("@expedition", expedition.Date_expedition);
                request.Parameters.AddWithValue("@livraison_prevue", expedition.Date_livraison_prevue);
                request.Parameters.AddWithValue("@livraison", expedition.Date_livraison_reelle);
                request.Parameters.AddWithValue("@expediteur", expedition.Id_entrepot_source);
                request.Parameters.AddWithValue("@destinataire", expedition.Id_entrepot_destination);
                request.Parameters.AddWithValue("@poids", expedition.Poids);
                request.Parameters.AddWithValue("@statut", expedition.Statut);
            }

            catch (NpgsqlException ex)
            {
                Console.WriteLine("ExpeditionsRepository error : " + ex.Message);
            }

            finally 
            { 
                connection?.Close(); 
            }
        }


             public bool Delete(Expedition expeditions) 
        {
            NpgsqlConnection? connection = null;
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();
                var request = new NpgsqlCommand("DELETE FROM expeditions WHERE id=@id", connection);
                request.Parameters.AddWithValue("@id", expeditions.Id);

                if(request.ExecuteNonQuery()>0)
                {
                    return true;
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("ExpeditionsRepository error : " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }
            return false;

        }
    }
}
