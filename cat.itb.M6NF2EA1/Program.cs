using cat.itb.M6NF2EA1.Cruds;

public class Program
{
	static void Main(string[] args)
	{
		List<string> alumno1 = ["11101", "santiago", "riera blanca", "Barcelona", "678758521"];
        List<string> alumno2 = ["22210", "prachi", "riera blanca", "Barcelona", "678857545"];
        List<string> alumno3 = ["33310", "tasnim", "santa coloma", "Barcelona", "578451264"];
        AlumnosCRUD crudAlumnos = new AlumnosCRUD();
		NotasCRUD crudNotas = new();

		//crudAlumnos.GetAlumnoByDNI("56882942");
		//crudAlumnos.InsertAlumnos("111", "santiago", "Riera Blanca 186", "Barcelona", "678758521");
		//crudNotas.GetAllNotas();
		//crudNotas.GetNotasByDNI("56882942");
		//crudAlumnos.DeleteAlumnoByDNI("1110");
		crudAlumnos.InsertAlumnos([alumno1, alumno2, alumno3]);
		crudAlumnos.GetAllAlumnos();
	}
}