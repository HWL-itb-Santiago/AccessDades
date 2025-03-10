using cat.itb.M6NF2EA1.Connections;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2EA1.Cruds
{
    public class AlumnosCRUD
    {
		public void DeleteAlumnoByDNI(string alumnoDNI)
		{
			CloudConnection db = new();
			NpgsqlConnection conn = db.GetConnection();

			var SQL = "DELETE FROM alumnos Where dni = @dni";
			using var cmd = new NpgsqlCommand(SQL, conn);

			cmd.ExecuteNonQuery();

			Console.WriteLine("row deleted");
			conn.Close();
		}
		public void InsertAlumnos(
			string dni,
			string name,
			string addres,
			string pobla,
			string cellphone
			)
		{
			CloudConnection db = new();
			NpgsqlConnection conn = db.GetConnection();

			var SQL = "INSERT INTO alumnos(dni, apenom, direc, pobla, telef) VALUES(@dni, @apenom, @direc, @pobla, @telef)";
			using var cmd = new NpgsqlCommand( SQL, conn );

			cmd.Parameters.AddWithValue("dni", dni);
			cmd.Parameters.AddWithValue("apenom", name);
			cmd.Parameters.AddWithValue("direc", addres);
			cmd.Parameters.AddWithValue("pobla", pobla);
			cmd.Parameters.AddWithValue("telef", cellphone);

			cmd.Prepare();
			if (cmd.ExecuteNonQuery() != 0)
			{
				Console.WriteLine($"Usuario con dni {dni} creado");
			}
			else
			{
				Console.WriteLine($"Usuario no creado");
			}
		}

        public void GetAlumnoByDNI(string alumnoDNI)
        {
            CloudConnection cloudConnection = new();
            NpgsqlConnection conn = cloudConnection.GetConnection();

            var SQL = "SELECT * FROM alumnos Where dni = @dni";
            using var cmd = new NpgsqlCommand(SQL, conn);

            cmd.Parameters.AddWithValue("dni", alumnoDNI);
            cmd.Prepare();

            using NpgsqlDataReader dataReader = cmd.ExecuteReader();
			printAlumnosData(dataReader);
			conn.Close();
        }

		public void GetAllAlumnos()
		{
			CloudConnection cloudConnection = new();
			NpgsqlConnection conn = cloudConnection.GetConnection();

			var SQL = "SELECT * FROM alumnos";
			using var cmd = new NpgsqlCommand(SQL, conn);

			using NpgsqlDataReader dataReader = cmd.ExecuteReader();
			printAlumnosData(dataReader);
			conn.Close();
		}

		public void printAlumnosData(NpgsqlDataReader dataReader)
		{
			Console.WriteLine($"{dataReader.GetName(0),-10} " +
				$"{dataReader.GetName(1),-30} " +
				$"{dataReader.GetName(2),-20} " +
				$"{dataReader.GetName(3),-20} " +
				$"{dataReader.GetName(4),-20}");
			while (dataReader.Read())
			{
				Console.WriteLine($"{dataReader.GetString(0),-10} " +
					$"{dataReader.GetString(1),-30} " +
					$"{dataReader.GetString(2),-20} " +
					$"{dataReader.GetString(3),-20} " +
					$"{dataReader.GetString(4),-20}");
			}
		}
	}
}
