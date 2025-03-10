using cat.itb.M6NF2EA1.Connections;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2EA1.Cruds
{
    public class NotasCRUD
    {
        public void GetAllNotas()
        {
            CloudConnection db = new();
            NpgsqlConnection conn = db.GetConnection();
			var SQL = "SELECT * FROM notas";
			using var cmd = new NpgsqlCommand(SQL, conn);

			using NpgsqlDataReader dataReader = cmd.ExecuteReader();
			printNotasData(dataReader);
			conn.Close();
		}

		public void GetNotasByDNI(string alumnoDNI)
		{
			CloudConnection db = new();
			NpgsqlConnection conn = db.GetConnection();

			var SQL = "SELECT * FROM notas Where dni = @dni";
			using var cmd = new NpgsqlCommand( SQL, conn);

			cmd.Parameters.AddWithValue("dni", alumnoDNI);
			cmd.Prepare();

			NpgsqlDataReader dataReader = cmd.ExecuteReader();
			printNotasData(dataReader);
			conn.Close();
		}

		public void printNotasData(NpgsqlDataReader dataReader)
		{
			Console.WriteLine($"{dataReader.GetName(0),-10} " +
							$"{dataReader.GetName(1),-4} " +
							$"{dataReader.GetName(2),-4} ");
			while (dataReader.Read())
			{
				Console.WriteLine($"{dataReader.GetString(0),-10} " +
					$"{dataReader.GetInt64(1),-4} " +
					$"{dataReader.GetInt64(2),-4} ");
			}
		}
    }
}
