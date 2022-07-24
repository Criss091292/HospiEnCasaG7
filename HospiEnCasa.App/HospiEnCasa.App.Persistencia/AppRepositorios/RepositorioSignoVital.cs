using HospiEnCasa.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSignoVital : IRepositorioSignoVital
    {
        private readonly AppContext _appContext;
        public RepositorioSignoVital(AppContext appContext)
        {
            _appContext = appContext;
        }
        SignoVital IRepositorioSignoVital.AddSignoVital(SignoVital signoVital)
        {
            var signoVitalAdicionado = _appContext.SignosVitales.Add(signoVital);
            _appContext.SaveChanges();
            return signoVitalAdicionado.Entity;
        }
        IEnumerable<SignoVital> IRepositorioSignoVital.GetAllSignoVital()
        {
            return _appContext.SignosVitales;
        }
        SignoVital IRepositorioSignoVital.GetSignoVital(int idsignoVital)
        {
            return _appContext.SignosVitales.FirstOrDefault(s => s.Id == idsignoVital);
        }
        SignoVital IRepositorioSignoVital.UpdateSignoVital(SignoVital signoVital)
        {
            var signoVitalEncontrado = _appContext.SignosVitales.FirstOrDefault(s => s.Id == signoVital.Id);
            if (signoVitalEncontrado != null)
            {
                signoVitalEncontrado.FechaHora = signoVital.FechaHora;
                signoVitalEncontrado.Valor = signoVital.Valor;
                signoVitalEncontrado.Signo = signoVital.Signo;
                
                _appContext.SaveChanges();

            }
            return signoVitalEncontrado;
        }
    }
}