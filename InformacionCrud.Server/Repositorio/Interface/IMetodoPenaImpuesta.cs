using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoPenaImpuesta
    {
        Task<List<Penaimpuestum>> ListarPenaImpuesta();
    }
}
