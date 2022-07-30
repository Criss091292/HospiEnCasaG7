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
    public class Editar_FamiliarModel : PageModel
    {
        private readonly IRepositorioFamiliar repositorioFamiliar;
        [BindProperty]
        public FamiliarDesignado FamiliarDesignado {get;set;}
        public string familiarDocumento {get;set;}
        public Editar_FamiliarModel(IRepositorioFamiliar repositorioFamiliar)
        {
            this.repositorioFamiliar = repositorioFamiliar;
        }
        public IActionResult OnGet(string familiarDocumento)
        {
            this.familiarDocumento = familiarDocumento;
            FamiliarDesignado = new FamiliarDesignado();
            FamiliarDesignado = repositorioFamiliar.GetFamiliar(familiarDocumento);
            if(FamiliarDesignado == null)
            {
                return RedirectToPage("../Error");
            }
            else
            {
                return Page();
            }
            return RedirectToPage("../Error");
        }

        public IActionResult OnPost(string familiarDocumento)
        {
            FamiliarDesignado FamiliarEncontrado = repositorioFamiliar.GetFamiliar(familiarDocumento);
            if (FamiliarEncontrado != null)
            {
                FamiliarEncontrado.Telefono = FamiliarDesignado.Telefono;
                FamiliarEncontrado.Correo = FamiliarDesignado.Correo;
                repositorioFamiliar.UpdateFamiliar(FamiliarEncontrado);
            }
            else
            {
                return RedirectToPage("../Error");
            }
            return RedirectToPage("../Listar_Familiar/Listar_Familiar");;
        }
    }
}
