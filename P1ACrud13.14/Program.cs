


using P1ACrud13._14.Clases;
using P1ACrud13._14.Clases.Servicios;

ServicioAlumno alu = new();

//string cuer = "select * from tb_alumnos where carnet='21-11951'";
//alu.lee(cuerito);
//Console.WriteLine("antes de cambiar");
//Console.ReadLine();
//alu.cambia();
//Console.WriteLine("Despues de cambiar");
//Console.ReadLine();
//alu.lee(cuer);

string cuer = "select * from tb_alumnos where seccion='C'";
//alu.lee(cuer);
//Console.WriteLine("antes de cambiar");
//Console.ReadLine();

//string nombre = "Juan Perez";
//string carnet = "2023-1";
//string correo = "xx@xx.com";
//string clase = "Progra";
//string seccion = "C";



//Console.Write("Ingrese su nombre");
//nombre = Console.ReadLine();


//Console.Write("Carnet");
//carnet = Console.ReadLine();



//alu.inserta(nombre,carnet,correo,clase,seccion);
//alu.lee(cuer);


MdAlumnos oAlumno = new();

//oAlumno.nombre = "Gabriel Garcia";
//oAlumno.carnet = "2023-8";
//oAlumno.seccion = "c";
//oAlumno.correo = "gg@xx.com";
//oAlumno.clase = "Progra avanzada";

//alu.CrearAlumno(oAlumno);

//Console.WriteLine(oAlumno.ToString());

//alu.lee(cuer);



oAlumno = alu.ObtenerAlumno("21-3901");

if (oAlumno == null)
{
    Console.WriteLine($"Ese compañero no existe");
}
else
{




    Console.WriteLine($"nombre: {oAlumno.nombre}");

    //Console.WriteLine(oAlumno.ToString());
    //oAlumno.clase = "Electronica";
    //alu.actualizarAlumno(oAlumno);
}