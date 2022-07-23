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
    public class Asignar_FamiliarModel : PageModel
    {
        private readonly IRepositorioFamiliar repositorioFamiliar;
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public FamiliarDesignado FamiliarDesignado {get;set;}
        public Paciente Paciente {get;set;}
        public string pacienteDocumento {get;set;}
        public Asignar_FamiliarModel(IRepositorioFamiliar repositorioFamiliar, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioPaciente = repositorioPaciente;
        }
        public IActionResult OnGet(string pacienteDocumento)
        {
            this.pacienteDocumento = pacienteDocumento;
            FamiliarDesignado = new FamiliarDesignado();
            Paciente = new Paciente();
            Paciente = repositorioPaciente.GetPaciente(pacienteDocumento);
            if(Paciente == null)
            {
                return RedirectToPage("../Error");
            }
            else
            {
                if(Paciente.FamiliarDesignadoId == null)
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
            Console.WriteLine(pacienteDocumento);
            Paciente = repositorioPaciente.GetPaciente(pacienteDocumento);
            if (FamiliarDesignado != null && Paciente != null)
            {
                repositorioFamiliar.AddFamiliar(FamiliarDesignado);
                repositorioPaciente.UpdateFamiliar(Paciente,FamiliarDesignado);
            }
            else
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}
