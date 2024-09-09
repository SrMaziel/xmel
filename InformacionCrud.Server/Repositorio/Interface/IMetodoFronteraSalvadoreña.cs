using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoFronteraSalvadoreña
    {
        Task<List<Fronterasalvadoreña>> ListarFronteras();
    }
}
