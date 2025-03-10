using Npgsql;

namespace cat.itb.M6NF2EA1.Connections
{
    public class CloudConnection
    {
        public string HOST = "postgresql-santiagovr.alwaysdata.net";
        public string DB = "santiagovr_school";
        public string USER = "santiagovr";
        public string PASSWORD = "Chistrees69@";

        public NpgsqlConnection? conn = null;

        public NpgsqlConnection GetConnection() 
        { 
            NpgsqlConnection conn = new(
                "Host=" + HOST + ";" + "Username=" + USER + ";" + "Password=" + PASSWORD + ";" + "Database=" + DB + ";");
            conn.Open();
            return conn;
        }
    }
}
