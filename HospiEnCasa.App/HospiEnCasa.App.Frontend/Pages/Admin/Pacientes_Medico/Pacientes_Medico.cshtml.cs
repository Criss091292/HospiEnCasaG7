using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace MyApp.Namespace
{
    public class Pacientes_MedicoModel : PageModel
    {
        private readonly IRepositorioMedico repositorioMedico;
        private readonly IRepositorioPaciente repositorioPaciente;
        public IEnumerable<Paciente> Pacientes {get;set;}
        public Medico Medico = new Medico();
        public Paciente Paciente = new Paciente();
        public Pacientes_MedicoModel(IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioMedico = repositorioMedico;
            this.repositorioPaciente = repositorioPaciente;
        }
        public void OnGet(string medicoDocumento)
        {
            Medico = repositorioMedico.GetMedico(medicoDocumento);
            Pacientes = repositorioPaciente.GetAllPacientes();
        }
    }
}
