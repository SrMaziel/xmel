using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoBienes : IMetodoBienes
    {
        private readonly InformacionpublicaContext _context;

        public MetodoBienes(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Biene>> ListarBienes()
        {
            List<Biene> bienes = await _context.Bienes.ToListAsync();

            return bienes;
        }
    }
}
