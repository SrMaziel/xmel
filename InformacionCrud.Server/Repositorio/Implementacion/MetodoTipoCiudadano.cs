using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoTipoCiudadano : IMetodoTipoCiudadano
    {
        private readonly InformacionpublicaContext _context;

        public MetodoTipoCiudadano(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Tiposciudadano>> ListarTipoCiudadano()
        {
            List<Tiposciudadano> tiposciudadanos = await _context.Tiposciudadanos.ToListAsync();

            return tiposciudadanos;
        }
    }
}
