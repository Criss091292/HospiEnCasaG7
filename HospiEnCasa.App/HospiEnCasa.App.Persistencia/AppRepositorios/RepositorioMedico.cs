using HospiEnCasa.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly AppContext _appContext;
        public RepositorioMedico(AppContext appContext)
        {
            _appContext = appContext;
        }
        Medico IRepositorioMedico.AddMedico(Medico medico)
        {
            var medicoAdicionado = _appContext.Medicos.Add(medico);
            _appContext.SaveChanges();
            return medicoAdicionado.Entity;
        }

        void IRepositorioMedico.DeleteMedico(int idMedico)
        {
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(p => p.Id == idMedico);
            if (medicoEncontrado == null)
               {return;} 
            _appContext.Medicos.Remove(medicoEncontrado);
            _appContext.SaveChanges();
        }
        IEnumerable<Medico> IRepositorioMedico.GetAllMedico()
        {
            return _appContext.Medicos;
        }
        Medico IRepositorioMedico.GetMedico(string DocumentoIdentidad)
        {
            return _appContext.Medicos.FirstOrDefault(p => p.DocumentoIdentidad == DocumentoIdentidad);
        }
        Medico IRepositorioMedico.UpdateMedico(Medico medico)
        {
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(p => p.Id == medico.Id);
            if (medicoEncontrado != null)
            {
                medicoEncontrado.DocumentoIdentidad = medico.DocumentoIdentidad;
                medicoEncontrado.Nombre = medico.Nombre;
                medicoEncontrado.Apellidos = medico.Apellidos;
                medicoEncontrado.Telefono = medico.Telefono;
                medicoEncontrado.Genero = medico.Genero;
                
                
                _appContext.SaveChanges();

            }
            return medicoEncontrado;
        }
    }
}