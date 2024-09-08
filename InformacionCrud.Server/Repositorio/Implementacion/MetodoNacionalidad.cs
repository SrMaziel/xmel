using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoNacionalidad : IMetodoNacionalidad
    {
        private readonly InformacionpublicaContext _context;

        public MetodoNacionalidad(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Nacionalidad>> ListarNacionalidad()
        {
            List<Nacionalidad> nacionalidad = await _context.Nacionalidads.ToListAsync();

            return nacionalidad;
        }
    }
}
