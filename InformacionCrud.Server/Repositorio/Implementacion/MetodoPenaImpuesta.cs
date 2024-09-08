using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoPenaImpuesta : IMetodoPenaImpuesta
    {
        private readonly InformacionpublicaContext _context;

        public MetodoPenaImpuesta(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Penaimpuestum>> ListarPenaImpuesta()
        {
            List<Penaimpuestum> penaimpuesta = await _context.Penaimpuesta
                                                            .Include(TP => TP.TiposdelitosNavigation)
                                                            .Include(d => d.DelitosNavigation)
                                                            .ToListAsync();

            return penaimpuesta;
        }
    }
}
