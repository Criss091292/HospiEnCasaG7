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
    public class Registrar_MedicoModel : PageModel
    {
        private readonly IRepositorioMedico repositorioMedico;
        [BindProperty]
        public Medico Medico {get; set; }
        public Registrar_MedicoModel(IRepositorioMedico repositorioMedico)
        {
            this.repositorioMedico=repositorioMedico;
        }
        public IActionResult OnGet()
        {
            Medico = new Medico();

            return Page();
        }

        public IActionResult OnPost()
        {
            if(Medico != null)
            {
                repositorioMedico.AddMedico(Medico);
            }
            return RedirectToPage("../Admin/Listar_Medico/Listar_Medico");
        }
    }
}
