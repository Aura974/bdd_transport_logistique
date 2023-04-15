using MySql.Data.MySqlClient;
using System.Collections.Generic;
using transport.Data.Entity;

namespace transport.Data.Repository
{
	class EntrepotsRepository
	{
		public List<Entrepots> FindAll()
		{
			var list = new List<Entrepots>();
			MySqlConnection? connection = null;
			try
			{
				connection = DBConnection.GetConnection();
				connection.Open();
				var request = new MySqlCommand("SELECT * FROM entrepots", connection);
				var result = request.ExecuteReader();
				while (result.Read())
				{
					var entrepots = new Entrepots(result.GetString("nom_entrepot"), result.GetString("adresse"), result.GetString("ville"), result.GetString("pays"), result.GetString("continent"), result.GetInt32("id"));
					list.Add(entrepots);
				}
			}
			catch (MySqlException ex)
			{
				Console.WriteLine("EntrepotsRepository error : " + ex.Message);
			} finally { 
				connection?.Close(); 
			}
			return list;
		}

		public Entrepots Find(int id)
		{
            MySqlConnection? connection = null;
			try
			{
                connection = DBConnection.GetConnection();
                connection.Open();

				var request = new MySqlCommand("SELECT * FROM entrepots WHERE id=@id", connection);
				request.Parameters.AddWithValue("@id", id);
				var result = request.ExecuteReader();

				if (result.Read())
				{
                    var entrepots = new Entrepots(result.GetString("nom_entrepot"), result.GetString("adresse"), result.GetString("ville"), result.GetString("pays"), result.GetString("continent"), result.GetInt32("id"));
                    return entrepots;
                }
            }
            catch (MySqlException ex)
			{
                Console.WriteLine("EntrepotsRepository error : " + ex.Message);
            } finally {
				connection? .Close();
			}
			return null;
        }

		public void Save(Entrepots entrepots)
		{
            MySqlConnection? connection = null;
			try
			{
				connection = DBConnection.GetConnection();
				connection.Open();
				var request = new MySqlCommand("INSERT INTO entrepots (nom_entrepot, adresse, ville, pays, continent) VALUES (@nomentrepot, @adresse, @ville, @pays, @continent)", connection);
				request.Parameters.AddWithValue("@nomentrepot", entrepots.NomEntrepot);
                request.Parameters.AddWithValue("@adresse", entrepots.Adresse);
                request.Parameters.AddWithValue("@ville", entrepots.Ville);
                request.Parameters.AddWithValue("@pays", entrepots.Pays);
                request.Parameters.AddWithValue("@continent", entrepots.Continent);

				var result = request.ExecuteNonQuery();
				entrepots.Id = (int?)request.LastInsertedId;
            }catch (MySqlException ex)
			{
                Console.WriteLine("EntrepotsRepository error : " + ex.Message);
            }
			finally { 
				connection?.Close(); 
			}
        }

		public bool Update(Entrepots entrepots)
		{
			MySqlConnection? connection = null;
			try
			{
				connection = DBConnection.GetConnection();

				connection.Open();

				var request = new MySqlCommand("UPDATE entrepots SET nom_entrepot=@nomentrepot, adresse=@adresse, ville=@ville,pays=@pays, continent=@continent WHERE id=@id", connection);
				request.Parameters.AddWithValue("@nomentrepot", entrepots.NomEntrepot);
				request.Parameters.AddWithValue("@adresse", entrepots.Adresse);
				request.Parameters.AddWithValue("@ville", entrepots.Ville);
				request.Parameters.AddWithValue("@pays", entrepots.Pays);
				request.Parameters.AddWithValue("@continent", entrepots.Continent);
				request.Parameters.AddWithValue("@id", entrepots.Id);

				if (request.ExecuteNonQuery()>0)
				{
					return true;
				}

			}
			catch (MySqlException ex)
			{
				Console.WriteLine("EntrepotRepository error : " + ex.Message);
			}
			finally
			{
				connection?.Close();
			}
			return false;
		}

		public bool Delete(Entrepots entrepots)
		{
			MySqlConnection? connection = null;
			try
			{
				connection = DBConnection.GetConnection();

				connection.Open();

				var request = new MySqlCommand("DELETE entrepots WHERE id=@id", connection);
				request.Parameters.AddWithValue("@id", entrepots.Id);

				if (request.ExecuteNonQuery()>0)
				{
					return true;
				}

			}
			catch (MySqlException ex)
			{
				Console.WriteLine("EntrepotRepository error : " + ex.Message);
			}
			finally
			{
				connection?.Close();
			}
			return false;
		}
		private Entrepots sqlToEntrepots(MySqlDataReader result)
		{
			return new Entrepots(result.GetString("nom_entrepot"), result.GetString("adresse"), result.GetString("ville"), result.GetString("pays"), result.GetString("continent"), result.GetInt32("id"));
		}

	}
}