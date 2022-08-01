using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class HU_01Model : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HU_01Model> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public Paciente Paciente {get; set; }
        public HU_01Model(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<HU_01Model> logger,
            RoleManager<IdentityRole> roleManager,
            IRepositorioPaciente repositorioPaciente
            )
        {
            this.repositorioPaciente=repositorioPaciente;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
        }
        public IActionResult OnGet()
        {
            Paciente = new Paciente();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(Paciente != null)
            {
                repositorioPaciente.AddPaciente(Paciente);
                var user = new IdentityUser { UserName = Paciente.DocumentoIdentidad};
                var result = await _userManager.CreateAsync(user, "Hospi" + Paciente.DocumentoIdentidad + "*");
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    if((await _roleManager.RoleExistsAsync("paciente")) != true)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("paciente")); 
                        _logger.LogInformation("rol creado");
                    }
                    await _userManager.AddToRoleAsync(user,"paciente");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                return RedirectToPage("../Error");
            }
            return Redirect("/Admin/Listar_Pacientes/HU-04");
        }
    }
}
