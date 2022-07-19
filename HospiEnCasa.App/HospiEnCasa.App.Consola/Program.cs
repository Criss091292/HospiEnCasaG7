using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{

    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Entity Framework");
            //AddPaciente();
            BuscarPaciente("Perez Prieto");
        }
        public static void AddPaciente()
        {
            var paciente = new Paciente()
            {
                Nombre = "Pepito",
                Apellidos = "Perez Prieto",
                Telefono = "300000000",
                Genero = Genero.masculino,
                Direccion = "Calle 8",
                Longitud = 9.54f,
                Latitud = 45.55f,
                Ciudad = "Santa Marta",
                FechaNacimiento = new DateTime(1972, 11, 08)
            };
            _repoPaciente.AddPaciente(paciente);
        }

        private static void BuscarPaciente(string apellido)
        {
            var paciente = _repoPaciente.GetPaciente(apellido);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos + " " + paciente.Genero);
        }
    }
}
