using cat.itb.M6NF2EA1.Connections;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cat.itb.M6NF2EA1.Cruds
{
    public class AlumnosCRUD
    {
		public void UpdateAlumno(string alumnoDNI, string newTelef)
		{
			CloudConnection db = new();
			NpgsqlConnection conn = db.GetConnection();

			var SQL = "UPDATE alumnos SET telef = @newTelef WHERE dni = @alumnoDNI";
			using var cmd = new NpgsqlCommand(SQL, conn);

			cmd.Parameters.AddWithValue("alumnoDNI", alumnoDNI);
			cmd.Parameters.AddWithValue("newTelef", newTelef);

			cmd.Prepare();
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		public void DeleteAlumnoPobla(string pobla)
		{
            CloudConnection db = new();
            NpgsqlConnection conn = db.GetConnection();

            var SQL = "DELETE FROM alumnos Where pobla = @pobla";
            using var cmd = new NpgsqlCommand(SQL, conn);

            cmd.Parameters.AddWithValue("pobla", pobla);
            cmd.ExecuteNonQuery();

            Console.WriteLine("row deleted");
            conn.Close();
        }
		public void DeleteAlumnoByDNI(string alumnoDNI)
		{
			CloudConnection db = new();
			NpgsqlConnection conn = db.GetConnection();

			var SQL = "DELETE FROM alumnos Where dni = @dni";
			using var cmd = new NpgsqlCommand(SQL, conn);

			cmd.Parameters.AddWithValue("dni", alumnoDNI);
			cmd.ExecuteNonQuery();

			Console.WriteLine("row deleted");
			conn.Close();
		}

		public void InsertAlumnos(
			List<List<string>> alumnos
			)
		{
			CloudConnection db = new();
			NpgsqlConnection conn = db.GetConnection();

			var SQL = "INSERT INTO alumnos(dni, apenom, direc, pobla, telef) VALUES(@dni, @apenom, @direc, @pobla, @telef)";
			using var cmd = new NpgsqlCommand( SQL, conn );

			foreach ( var item in alumnos )
			{
				cmd.Parameters.AddWithValue("dni", item[0]);
				cmd.Parameters.AddWithValue("apenom", item[1]);
				cmd.Parameters.AddWithValue("direc", item[2]);
				cmd.Parameters.AddWithValue("pobla", item[3]);
				cmd.Parameters.AddWithValue("telef", item[4]);

				cmd.ExecuteNonQuery();
				cmd.Parameters.Clear();
			}
			conn.Close();
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
