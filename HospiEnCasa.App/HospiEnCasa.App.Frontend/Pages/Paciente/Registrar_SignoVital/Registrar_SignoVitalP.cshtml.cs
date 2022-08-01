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
    public class Registrar_SignoVitalPModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositorioSignoVital repositorioSignoVital;
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public SignoVital SignoVital {get;set;}
        public Paciente Paciente {get;set;}
        public string pacienteDocumento {get;set;}
        public Registrar_SignoVitalPModel(UserManager<IdentityUser> userManager, IRepositorioSignoVital repositorioSignoVital, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioSignoVital = repositorioSignoVital;
            this.repositorioPaciente = repositorioPaciente;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            this.pacienteDocumento = user.UserName;
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

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            this.pacienteDocumento = user.UserName;
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
