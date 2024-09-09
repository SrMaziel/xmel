using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IInfraccionesService
    {
        Task<List<InfraccionesDTO>> Lista();
    }
}
