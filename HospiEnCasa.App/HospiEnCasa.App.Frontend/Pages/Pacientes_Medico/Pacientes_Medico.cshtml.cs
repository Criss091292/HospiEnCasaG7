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
    public class Pacientes_MedicoModel : PageModel
    {
        private readonly IRepositorioMedico repositorioMedico;
        public IEnumerable<Medico> Medicos {get;set;}
        public Medico Medico = new Medico();
        public Pacientes_MedicoModel(IRepositorioMedico repositorioMedico)
        {
            this.repositorioMedico = repositorioMedico;
        }
        public void OnGet(string medicoDocumento)
        {
            Medico = repositorioMedico.GetMedico(medicoDocumento);
        }
    }
}
