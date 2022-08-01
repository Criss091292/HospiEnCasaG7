using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace MyApp.Namespace
{
    public class Index_PacienteModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public Paciente Paciente {get;set;}
        public string pacienteDocumento {get;set;}

        public Index_PacienteModel(UserManager<IdentityUser> userManager,IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            this.pacienteDocumento = user.UserName;
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

    }
}
