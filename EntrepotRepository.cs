
using Npgsql;
using transport_logistique.Entity;
using transport_logistique.Repository;

namespace transport_logistique.Repository
{
    class EntrepotRepository
    {
        public List<Entrepot> FindAll()
        {
            var list = new List<Entrepot>();
            NpgsqlConnection? connection = null;
            try
            {
                connection = DbConnection.GetConnection();

                connection.Open();

                var request = new NpgsqlCommand("SELECT * FROM entrepots", connection);

                var result = request.ExecuteReader();

                while (result.Read())
                {
                    var entrepot = new Entrepot(result.GetString(result.GetOrdinal("nom_entrepot")),
                    result.GetString(result.GetOrdinal("adresse")),
                    result.GetString(result.GetOrdinal("ville")), result.GetString(result.GetOrdinal("pays")),
                    result.GetString(result.GetOrdinal("continent")), result.GetInt32(result.GetOrdinal("id")));
                    list.Add(entrepot);
                }

            }
            catch (NpgsqlException ex)
            {

                Console.WriteLine("transportRepo error : " + ex.Message);

            }
            finally
            {
                connection?.Close();
            }

            return list;
        }

        public void Save(Entrepot entrepot)
        {

            NpgsqlConnection? connection = null;
            try
            {

                connection = DbConnection.GetConnection();

                connection.Open();

                var request = new Npgsql.NpgsqlCommand("INSERT INTO entrepots (nom_entrepot, adresse, ville, pays, continent) VALUES (@nom, @adresse, @ville, @pays, @continent)", connection);
                request.Parameters.AddWithValue("@nom", entrepot.Nom_entrepot);
                request.Parameters.AddWithValue("@adresse", entrepot.Adresse);
                request.Parameters.AddWithValue("@ville", entrepot.Ville);
                request.Parameters.AddWithValue("@pays", entrepot.Pays);
                request.Parameters.AddWithValue("@continent", entrepot.Continent);



                var result = request.ExecuteNonQuery();
                entrepot.Id = (int?)request.ExecuteScalar();


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
    

        public void Update(Entrepot entrepot)
        {
            NpgsqlConnection? connection = null;
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                var request = new NpgsqlCommand(
                    "UPDATE entrepots SET nom_entrepot=@entrepot, adresse=@adresse, ville=@ville, pays=@pays, continent=@continent", connection);
                request.Parameters.AddWithValue("@entrepot", entrepot.Nom_entrepot);
                request.Parameters.AddWithValue("@adresse", entrepot.Adresse);
                request.Parameters.AddWithValue("@ville", entrepot.Ville);
                request.Parameters.AddWithValue("@pays", entrepot.Pays);
                request.Parameters.AddWithValue("@continent", entrepot.Continent);

            }

            catch (NpgsqlException ex)
            {
                Console.WriteLine("EntrepotsRepository error : " + ex.Message);
            }

            finally 
            { 
                connection?.Close(); 
            }
        }


        public bool Delete(Entrepot entrepot) 
        {
            NpgsqlConnection? connection = null;
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();
                var request = new NpgsqlCommand("DELETE FROM entrepot WHERE id=@id", connection);
                request.Parameters.AddWithValue("@id", entrepot.Id);

                if(request.ExecuteNonQuery()>0)
                {
                    return true;
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("EntrepotRepository error : " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }
            return false;
        }
    }
}
