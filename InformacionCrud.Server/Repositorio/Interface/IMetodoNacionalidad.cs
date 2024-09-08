using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoNacionalidad
    {
        Task<List<Nacionalidad>> ListarNacionalidad();
    }
}
