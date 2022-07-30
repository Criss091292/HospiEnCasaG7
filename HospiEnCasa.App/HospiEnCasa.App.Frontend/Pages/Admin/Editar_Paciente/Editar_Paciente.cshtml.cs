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
    public class Editar_PacienteModel : PageModel
    {
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public Paciente Paciente {get;set;}
        public string pacienteDocumento {get;set;}
        public Editar_PacienteModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }
        public IActionResult OnGet(string pacienteDocumento)
        {
            this.pacienteDocumento = pacienteDocumento;
            Paciente = new Paciente();
            Paciente = repositorioPaciente.GetPaciente(pacienteDocumento);
            if(Paciente == null)
            {
                return RedirectToPage("../Error");
            }
            else
            {
                return Page();
            }
            return RedirectToPage("../Error");
        }

        public IActionResult OnPost(string pacienteDocumento)
        {
            Paciente PacienteEncontrado = repositorioPaciente.GetPaciente(pacienteDocumento);
            if (PacienteEncontrado != null)
            {
                PacienteEncontrado.Telefono = Paciente.Telefono;
                PacienteEncontrado.Direccion = Paciente.Direccion;
                PacienteEncontrado.Ciudad = Paciente.Ciudad;
                PacienteEncontrado.Latitud = Paciente.Latitud;
                PacienteEncontrado.Longitud = Paciente.Longitud;
                repositorioPaciente.UpdatePaciente(PacienteEncontrado);
            }
            else
            {
                return RedirectToPage("../Error");
            }
            return RedirectToPage("../Listar_Pacientes/HU-04");;
        }
    }
}
