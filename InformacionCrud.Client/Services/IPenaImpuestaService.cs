using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IPenaImpuestaService
    {
        Task<List<PenaimpuestaDTO>> Lista();
    }
}
