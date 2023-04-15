using MySql.Data.MySqlClient;

namespace transport.Data.Repository
{
    class DBConnection
    {
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection("server=localhost;uid=root;pwd=;database=transport_logistique");
        }
    }
}
