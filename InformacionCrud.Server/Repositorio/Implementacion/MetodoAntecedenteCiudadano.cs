using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoAntecedenteCiudadano : IMetodoAntecedenteCiudadano
    {
        private readonly InformacionpublicaContext _context;

        public MetodoAntecedenteCiudadano(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Antecedentesciudadano>> ListarAntecedenteCiudadano()
        {
            List<Antecedentesciudadano> antecedentesciudadanos = await _context.Antecedentesciudadanos
                                                            .Include(C => C.CiudadanoNavigation)
                                                            .Include(d => d.DelitosNavigation)
                                                            .Include(TD => TD.TiposdelitosNavigation)
                                                            .Include(PI => PI.PenaimpuestaNavigation)
                                                            .Include(DT => DT.DetencionesNavigation)
                                                            
                                                            .ToListAsync();

            return antecedentesciudadanos;
        }
        public async Task<List<Antecedentesciudadano>> ListarAntecedentesPorBusqueda(string datos)
        {
            List<Antecedentesciudadano> antecedentesciudadanos = await _context.Antecedentesciudadanos
                                                            .Include(c => c.CiudadanoNavigation)
                                                            .Include(td => td.TiposdelitosNavigation)
                                                            .Include(d => d.DelitosNavigation)
                                                            .Include(d => d.DetencionesNavigation)
                                                            .Include(P => P.PenaimpuestaNavigation)
                                                            .ToListAsync();

            if (!String.IsNullOrEmpty(datos))
            {
                antecedentesciudadanos = await _context.Antecedentesciudadanos.Where(

                    c => c.CiudadanoNavigation.Nombre!.Contains(datos) ||
                         c.DelitosNavigation.Delitos!.Contains(datos) ||
                         c.TiposdelitosNavigation.Tiposdelitos!.Contains(datos) ||
                         c.DetencionesNavigation.Detencion!.Contains(datos) ||
                         c.PenaimpuestaNavigation.Penaimpuesta!.Contains(datos)

                    ).ToListAsync();
            }

            return antecedentesciudadanos;
        }

        public async Task<Antecedentesciudadano> BuscarAntecedenteCiudadano(int ID)
        {
            return await _context.Antecedentesciudadanos.FindAsync(ID);
        }

        public async Task<Antecedentesciudadano> CrearAntecedenteCiudadano(Antecedentesciudadano antecedentesciudadanos)
        {
            try
            {
                await _context.Antecedentesciudadanos.AddAsync(antecedentesciudadanos);
                await _context.SaveChangesAsync();

                return antecedentesciudadanos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Antecedentesciudadano> EditarAntecedenteCiudadano(Antecedentesciudadano antecedentesciudadanos)
        {
            try
            {
                _context.Antecedentesciudadanos.Update(antecedentesciudadanos);
                await _context.SaveChangesAsync();

                return antecedentesciudadanos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarAntecedenteCiudadano(Antecedentesciudadano antecedentesciudadanos)
        {
            try
            {
                _context.Antecedentesciudadanos.Remove(antecedentesciudadanos);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
