using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoFronteraSalvadoreña : IMetodoFronteraSalvadoreña
    {
        private readonly InformacionpublicaContext _context;

        public MetodoFronteraSalvadoreña(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Fronterasalvadoreña>> ListarFronteras()
        {
            List<Fronterasalvadoreña> bienes = await _context.Fronterasalvadoreñas.ToListAsync();

            return bienes;
        }
    }
}
