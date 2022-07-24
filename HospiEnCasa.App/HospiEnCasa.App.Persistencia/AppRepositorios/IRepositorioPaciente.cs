using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        void DeletePaciente(int idPaciente);
        Paciente GetPaciente(string DocumentoIdentidad);
        Paciente UpdateFamiliar(Paciente paciente, FamiliarDesignado familiar);
        Paciente UpdateMedico(Paciente paciente, Medico medico);
        Paciente UpdateSignoVital(Paciente paciente,SignoVital signoVital);
    }
}