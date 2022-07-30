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
    public class Listar_FamiliarModel : PageModel
    {
        private readonly IRepositorioFamiliar repositorioFamiliar;
        public IEnumerable<FamiliarDesignado> FamiliaresDesignados {get;set;}
        public FamiliarDesignado familiarDesignado = new FamiliarDesignado();
        public Listar_FamiliarModel(IRepositorioFamiliar repositorioFamiliar)
        {
            this.repositorioFamiliar=repositorioFamiliar;
        }
        public void OnGet()
        {
            FamiliaresDesignados = repositorioFamiliar.GetAllFamiliar();
        }


    }
}
