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
    public class Asignar_MedicoModel : PageModel
    {
        private readonly IRepositorioMedico repositorioMedico;
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public string pacienteDocumento { get; set; }
        public Asignar_MedicoModel(IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioMedico = repositorioMedico;
            this.repositorioPaciente = repositorioPaciente;
        }
        public IActionResult OnGet(string pacienteDocumento)
        {
            this.pacienteDocumento = pacienteDocumento;
            Medico = new Medico();
            Paciente = new Paciente();
            Paciente = repositorioPaciente.GetPaciente(pacienteDocumento);
            if (Paciente == null)
            {
                return RedirectToPage("../Error");
            }
            else
            {
                if (Paciente.MedicoId == null)
                {
                    return Page();
                }
                else
                {
                    return RedirectToPage("../Tiene_Familiar/Tiene_Familiar");
                }
            }
            return RedirectToPage("../Error");
        }

        public IActionResult OnPost(string pacienteDocumento)
        {
            Paciente = repositorioPaciente.GetPaciente(pacienteDocumento);
            Medico = repositorioMedico.GetMedico(Medico.DocumentoIdentidad);
            if (Medico != null && Paciente != null)
            {
                repositorioPaciente.UpdateMedico(Paciente, Medico);
            }
            else
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}
