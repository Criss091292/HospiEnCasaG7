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
    public class HU_05Model : PageModel
    {
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public Paciente Paciente {get; set; }
        public HU_05Model(IRepositorioPaciente repositorioPaciente)
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
            if(Paciente.DocumentoIdentidad != null)
            {
               Paciente = repositorioPaciente.GetPaciente(Paciente.DocumentoIdentidad);
               if (Paciente != null){
                    return Page();

               }
               else{
                return RedirectToPage("../Error");

               }
            }
                           return Page();

        }   
     }
}
