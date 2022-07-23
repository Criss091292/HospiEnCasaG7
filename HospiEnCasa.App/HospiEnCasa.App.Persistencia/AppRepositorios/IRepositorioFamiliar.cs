using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioFamiliar
    {
        IEnumerable<FamiliarDesignado> GetAllFamiliar();
        FamiliarDesignado AddFamiliar(FamiliarDesignado familiar);
        FamiliarDesignado UpdateFamiliar(FamiliarDesignado familiar);
        void DeleteFamiliar(int idFamiliar);
        FamiliarDesignado GetFamiliar(string DocumentoIdentidad);
    }
}