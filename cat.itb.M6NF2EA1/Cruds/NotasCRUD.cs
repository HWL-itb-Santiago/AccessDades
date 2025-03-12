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

		public void UpdateNotas(string name, int newNota)
		{
			CloudConnection db = new();
			NpgsqlConnection conn = db.GetConnection();

			var SQL_FOL = "UPDATE notas SET nota = @newNota WHERE dni = (" +
                "SELECT dni FROM alumnos WHERE apenom = @name" +
				") AND (cod = 4 OR cod = 5)";
			using var cmd_FOL = new NpgsqlCommand(SQL_FOL, conn);
			cmd_FOL.Parameters.AddWithValue("newNota", newNota);
			cmd_FOL.Parameters.AddWithValue("name", name);

			cmd_FOL.Prepare();
			cmd_FOL.ExecuteNonQuery();
			conn.Close();
		}
		public void InsertNotas(List<string> alumnosDNI, int nota)
		{
			CloudConnection db = new();
			NpgsqlConnection conn = db.GetConnection();

			var SQL_FOL = "INSERT INTO notas(dni, cod, nota) VALUES(@dni, 4, @nota)";
			using var cmd_FOL = new NpgsqlCommand(SQL_FOL, conn);

			foreach (var item in alumnosDNI)
			{
				cmd_FOL.Parameters.AddWithValue("dni", item);
				cmd_FOL.Parameters.AddWithValue("nota", nota);

				cmd_FOL.ExecuteNonQuery();
				cmd_FOL.Parameters.Clear();
			}

            var SQL_RET = "INSERT INTO notas(dni, cod, nota) VALUES(@dni, 5, @nota)";
            using var cmd_RET = new NpgsqlCommand(SQL_RET, conn);

            foreach (var item in alumnosDNI)
            {
                cmd_RET.Parameters.AddWithValue("dni", item);
                cmd_RET.Parameters.AddWithValue("nota", nota);

                cmd_RET.ExecuteNonQuery();
                cmd_RET.Parameters.Clear();
            }
			conn.Close();
        }

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
