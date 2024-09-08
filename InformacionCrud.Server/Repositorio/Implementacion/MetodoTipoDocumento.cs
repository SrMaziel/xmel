using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoTipoDocumento : IMetodoTipoDocumento
    {
        private readonly InformacionpublicaContext _context;

        public MetodoTipoDocumento(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Tipodocumento>> ListarTipoDocumento()
        {
            List<Tipodocumento> tipoDocumento = await _context.Tipodocumentos.ToListAsync();

            return tipoDocumento;
        }
    }
}
