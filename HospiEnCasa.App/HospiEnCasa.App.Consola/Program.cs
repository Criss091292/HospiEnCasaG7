using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{

    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Entity Framework");
            //AddMedico();
            BuscarPaciente("1007240264");
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

        public static void AddMedico()
        {
            var medico = new Medico()
            {
                DocumentoIdentidad = "1007240264",
                Nombre = "JuanMedico",
                Apellidos = "Perez Prieto",
                Telefono = "300000000",
                Genero = Genero.masculino,
                Especialidad = "Ginecologo",
                Codigo = "001",
                RegistroRethus = "AA2323"
            };
            _repoMedico.AddMedico(medico);
        }

        private static void BuscarPaciente(string DocumentoIdentidad)
        {
            var paciente = _repoPaciente.GetPaciente(DocumentoIdentidad);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos + " " + paciente.Genero);
        }
    }
}
