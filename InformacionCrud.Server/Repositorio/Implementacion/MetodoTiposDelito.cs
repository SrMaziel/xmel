using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoTiposDelito : IMetodoTiposDelito
    {
        private readonly InformacionpublicaContext _context;
    
        public MetodoTiposDelito(InformacionpublicaContext context)
        {
            _context = context;
        }
        public async Task<List<Tiposdelito>> ListarTiposDelitos()
        {
            List<Tiposdelito> tiposdelitos = await _context.Tiposdelitos.ToListAsync();

            return tiposdelitos;
        }
    }
    }

