using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoTipoCiudadano
    {
        Task<List<Tiposciudadano>> ListarTipoCiudadano();
    }
}
