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
    public class Registrar_SignoVitalModel : PageModel
    {
        private readonly IRepositorioSignoVital repositorioSignoVital;
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public SignoVital SignoVital {get;set;}
        public Paciente Paciente {get;set;}
        public string pacienteDocumento {get;set;}
        public Registrar_SignoVitalModel(IRepositorioSignoVital repositorioSignoVital, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioSignoVital = repositorioSignoVital;
            this.repositorioPaciente = repositorioPaciente;
        }
        public IActionResult OnGet(string pacienteDocumento)
        {
            this.pacienteDocumento = pacienteDocumento;
            SignoVital = new SignoVital();
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
            Paciente = repositorioPaciente.GetPaciente(pacienteDocumento);
            if (SignoVital != null && Paciente != null)
            {
                SignoVital.FechaHora = DateTime.Now;
                repositorioSignoVital.AddSignoVital(SignoVital);
                repositorioPaciente.UpdateSignoVital(Paciente,SignoVital);
            }
            else
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}
