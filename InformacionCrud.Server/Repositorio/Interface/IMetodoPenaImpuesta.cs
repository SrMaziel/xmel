using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoPenaImpuesta
    {
        Task<List<Penaimpuestum>> ListarPenaimpuesta();

        Task<Penaimpuestum> BuscarPenaimpuesta(int ID);

        Task<Penaimpuestum> CrearPenaimpuesta(Penaimpuestum penaimpuestum);

        Task<Penaimpuestum> EditarPenaimpuesta(Penaimpuestum penaimpuestum);

        Task BorrarPenaimpuesta(Penaimpuestum penaimpuestum);
    }
}
