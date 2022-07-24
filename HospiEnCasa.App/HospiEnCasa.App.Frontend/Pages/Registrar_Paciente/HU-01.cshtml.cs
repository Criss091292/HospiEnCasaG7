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
        public HU_01Model(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente=repositorioPaciente;
        }
        public IActionResult OnGet()
        {
            Paciente = new Paciente();
            return Page();
        }

        public IActionResult OnPost()
        {
            if(Paciente != null)
            {
                repositorioPaciente.AddPaciente(Paciente);
            }
            else
            {
                return RedirectToPage("../Error");
            }
            return RedirectToPage("../Listar_Pacientes/HU-04");
        }
    }
}
