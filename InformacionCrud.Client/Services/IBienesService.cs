using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IBienesService
    {
        Task<List<BienesDTO>> Lista();
    }
}
