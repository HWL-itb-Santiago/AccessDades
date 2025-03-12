using cat.itb.M6NF2EA1.Connections;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2EA1.Cruds
{
    public class GeneralCRUD
    {
        public void CreateTables()
        {
            string createCommand = "";
            try
            {
                using StreamReader reader = new("../../../school.sql");

                createCommand = reader.ReadToEnd();

                CloudConnection db = new();
                NpgsqlConnection conn = db.GetConnection();

                using var cmd = new NpgsqlCommand(createCommand, conn);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    Console.WriteLine("Tablas Creadas con éxito");
                }
                conn.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteTables()
        {
            CloudConnection db = new();
            NpgsqlConnection conn = db.GetConnection();

            var SQL = "DROP TABLE alumnos, notas, asignaturas";
            using var cmd = new NpgsqlCommand(SQL, conn);

            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("Tablas Eliminadas con éxito");
            }
            conn.Close();
        }
    }
}
