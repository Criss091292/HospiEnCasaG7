using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Frontend
{
    public class HU_04Model : PageModel
    {
        private readonly IRepositorioPaciente repositorioPacientes;
        public IEnumerable<Paciente> Pacientes {get;set;}
        public Paciente Paciente = new Paciente();
        public HU_04Model(IRepositorioPaciente repositorioPacientes)
        {
            this.repositorioPacientes=repositorioPacientes;
        }
        public void OnGet()
        {
            Pacientes = repositorioPacientes.GetAllPacientes();
        }


    }
}
