using MySql.Data.MySqlClient;


namespace repository.Repositories
{
    class DbConnection
    {

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection("server=localhost;uid=group1;pwd=1234;database=transport_logistique");
        }
    }
}
