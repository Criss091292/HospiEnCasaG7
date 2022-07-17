using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class HU_01Model : PageModel
    {
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public Paciente Paciente {get; set; }
        public void OnGet()
        {
            Paciente = new Paciente();
        }

        public IActionResult OnPost()
        {
            
            repositorioPaciente.AddPaciente(Paciente);
            return Page();
        }
    }
}
