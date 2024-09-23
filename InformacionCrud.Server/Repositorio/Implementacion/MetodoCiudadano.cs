using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoCiudadano : IMetodoCiudadano
    {
        private readonly InformacionpublicaContext _context;

        public MetodoCiudadano(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Ciudadano>> ListarCiudadanos()
        {
            List<Ciudadano> ciudadanos = await _context.Ciudadanos
                                                            .Include(b => b.BienesNavigation)
                                                            .Include(tc => tc.TiposciudadanosNavigation)
                                                            .Include(td => td.TipodedocumentoNavigation)
                                                            .Include(n => n.NacionalidadNavigation)
                                                            .ToListAsync();

            return ciudadanos;
        }

        public async Task<List<Ciudadano>> ListarCiudadanosPorBusqueda(string datos)
        {
            List<Ciudadano> ciudadanos = await _context.Ciudadanos
                                                            .Include(b => b.BienesNavigation)
                                                            .Include(tc => tc.TiposciudadanosNavigation)
                                                            .Include(td => td.TipodedocumentoNavigation)
                                                            .Include(n => n.NacionalidadNavigation)
                                                            .ToListAsync();

            if (!String.IsNullOrEmpty(datos))
            {
                ciudadanos = await _context.Ciudadanos.Where(
                    
                    c => c.Nombre!.Contains(datos) ||
                         c.Apellido!.Contains(datos) ||
                         c.Dui!.Contains(datos) ||
                         c.Telefonomovil!.Contains(datos) ||
                         c.Telefonofijio!.Contains(datos) ||
                         c.Correoelectronico!.Contains(datos) ||
                         c.TiposciudadanosNavigation.Tiposciudadanos!.Contains(datos) ||
                         c.NacionalidadNavigation.Nacionalidad1!.Contains(datos) ||
                         c.BienesNavigation.Bienes!.Contains(datos)

                    ).ToListAsync();
            }

            return ciudadanos;
        }

        public async Task<Ciudadano> BuscarCiudadano(int ID)
        {
            return await _context.Ciudadanos.FindAsync(ID);
        }

        public async Task<Ciudadano> CrearCiudadano(Ciudadano ciudadano)
        {
            try
            {
                await _context.Ciudadanos.AddAsync(ciudadano);
                await _context.SaveChangesAsync();

                return ciudadano;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Ciudadano> EditarCiudadano(Ciudadano ciudadano)
        {
            try
            {
                _context.Ciudadanos.Update(ciudadano);
                await _context.SaveChangesAsync();

                return ciudadano;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarCiudadano(Ciudadano ciudadano)
        {
            try
            {
                _context.Ciudadanos.Remove(ciudadano);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
