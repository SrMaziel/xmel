using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoInfracciones : IMetodoInfracciones
    {
         private readonly InformacionpublicaContext _context;

        public MetodoInfracciones(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Infraccione>> ListarInfracciones()
        {
            List<Infraccione> infracciones = await _context.Infracciones.ToListAsync();

            return infracciones;
        }
    }
}
