using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoDenuncia
    {
        Task<List<Denuncium>> ListarDenuncia();

        Task<Denuncium> BuscarDenuncia(int ID);

        Task<Denuncium> CrearDenuncia(Denuncium denuncium);

        Task<Denuncium> EditarDenuncia(Denuncium denuncium);

        Task BorrarDenuncia(Denuncium denuncium);
    }
}

