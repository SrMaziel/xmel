using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoDetenciones : IMetodoDetenciones
    {
        private readonly InformacionpublicaContext _context;

        public MetodoDetenciones(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Detencione>> ListarDetenciones()
        {
            List<Detencione> detenciones = await _context.Detenciones.ToListAsync();

            return detenciones;
        }
    }
}
