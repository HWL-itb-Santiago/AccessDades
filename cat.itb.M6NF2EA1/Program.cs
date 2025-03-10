using cat.itb.M6NF2EA1.Cruds;

public class Program
{
	static void Main(string[] args)
	{
		AlumnosCRUD crudAlumnos = new AlumnosCRUD();
		NotasCRUD crudNotas = new();

		//crudAlumnos.GetAlumnoByDNI("56882942");
		//crudAlumnos.InsertAlumnos("111", "santiago", "Riera Blanca 186", "Barcelona", "678758521");
		crudAlumnos.GetAllAlumnos();
		//crudNotas.GetAllNotas();
		//crudNotas.GetNotasByDNI("56882942");
	}
}