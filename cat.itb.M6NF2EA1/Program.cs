using cat.itb.M6NF2EA1.Cruds;

public class Program
{
    static void Main(string[] args)
	{
        List<string> alumno1 = new List<string> { "11101", "santiago", "riera blanca", "Barcelona", "678758521" };
        List<string> alumno2 = new List<string> { "22210", "prachi", "riera blanca", "Barcelona", "678857545" };
        List<string> alumno3 = new List<string> { "33310", "tasnim", "santa coloma", "Barcelona", "578451264" };
        AlumnosCRUD crudAlumnos = new AlumnosCRUD();
        NotasCRUD crudNotas = new();
        GeneralCRUD generalCRUD = new();
        int option = 1;

        while (true)
        {
            option = 0;
            Console.Clear();
            Console.WriteLine("----------------------- MENU DE BASE DE DATOS ----------------------");
            Console.WriteLine("1.- Mostrar les dades de la taula ALUMNOS.");
            Console.WriteLine("2.- Mostrar totes les dades de la taula NOTAS");
            Console.WriteLine("3.- Mostrar les notes de l’alumne amb DNI 4448242 de la taula NOTAS utilitzant el Prepared Statement.");
            Console.WriteLine("4.- Insertar 3 alumnes nous. Inventat les dades dels alumnes nous.");
            Console.WriteLine("5.- Insertar les notes per aquests 3 nous alumnes de les assignatures FOL i RET. Tots han tret un 8 en les dues\r\nassignatures. Utilitza el Prepared Statement.");
            Console.WriteLine("6.- Modificar les notes de l’alumne \"Cerrato Vela, Luis\" de FOL i RET, ha tret un 9.");
            Console.WriteLine("7.- Modificar el teléfon de l’alumne amb DNI = 12344345, el nou teléfon és 934885237.");
            Console.WriteLine("8.- Eliminar l’alumne que viu a \"Mostoles\".");
            Console.WriteLine("9 - Delete Tables");
            Console.WriteLine("0 - Create Tables");
            Console.WriteLine("Ingrese la opcion a desear: ");
            // Correct input reading
            string input = Console.ReadLine();
            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Por favor ingrese una opción válida.");
                continue;
            }
            switch (option)
            {
                case 1:
                    {
                        Console.Clear();
                        crudAlumnos.GetAllAlumnos();
                        ClearBuffer();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        crudNotas.GetAllNotas();
                        Console.Read();
                        ClearBuffer();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        crudNotas.GetNotasByDNI("4448242");
                        Console.Read();
                        ClearBuffer();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        crudAlumnos.InsertAlumnos([alumno1, alumno2, alumno3]);
                        Console.Read();
                        ClearBuffer();
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        crudNotas.InsertNotas([alumno1[0], alumno2[0], alumno3[0]], 8);
                        Console.Read();
                        ClearBuffer();
                        break;
                    }
                case 6:
                    {
                        Console.Clear();
                        crudNotas.UpdateNotas("Cerrato Vela, Luis", 9);
                        Console.Read();
                        ClearBuffer();
                        break;
                    }
                case 7:
                    {
                        Console.Clear();
                        crudAlumnos.UpdateAlumno("12344345", "934885237.");
                        Console.Read();
                        ClearBuffer();
                        break;
                    }
                case 8:
                    {
                        Console.Clear();
                        crudAlumnos.DeleteAlumnoPobla("Mostoles");
                        Console.Read();
                        ClearBuffer();
                        break;
                    }
                case 9:
                    {
                        Console.Clear();
                        generalCRUD.DeleteTables();
                        Console.Read();
                        ClearBuffer();
                        break;
                    }
                case 10:
                    {
                        Console.Clear();
                        generalCRUD.CreateTables();
                        Console.Read();
                        ClearBuffer();
                        break;
                    }
            }
        }
    }

    static void ClearBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true); // Lee cualquier tecla en el buffer sin mostrarla
        }
    }
}