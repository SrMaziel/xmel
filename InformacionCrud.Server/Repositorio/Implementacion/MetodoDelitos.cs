using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;


namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoDelitos : IMetodoDelitos
    {
        private readonly InformacionpublicaContext _context;

        public MetodoDelitos(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Delito>> ListarDelitos()
        {
            List<Delito> delitos = await _context.Delitos
                                                            .Include(TP => TP.TiposdelitosNavigation)
                                                            
                                                            .ToListAsync();

            return delitos;
        }

    }
}
