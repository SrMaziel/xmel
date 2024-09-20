using AutoMapper;
using InformacionCrud.Server.Models;
using InformacionCrud.Shared;

namespace InformacionCrud.Server
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<Ciudadano, CiudadanoDTO>().ReverseMap();
            CreateMap<Tiposciudadano, TiposciudadanoDTO>().ReverseMap();
            CreateMap<Nacionalidad, NacionalidadDTO>().ReverseMap();
            CreateMap<Tipodocumento, TipodocumentoDTO>().ReverseMap();
            CreateMap<Biene, BienesDTO>().ReverseMap();
            

            CreateMap<Denuncium, DenunciaDTO>().ReverseMap();

            CreateMap<Tiposdelito, TiposdelitoDTO>().ReverseMap();
            CreateMap<Delito, DelitosDTO>().ReverseMap();

           

            CreateMap<Detencione, DetencionesDTO>().ReverseMap();

            CreateMap<Penaimpuestum, PenaimpuestaDTO>().ReverseMap();

            CreateMap<Antecedentesciudadano, AntecentesciudadanoDTO>().ReverseMap();
            CreateMap<Documentosciudadano, DocumentoCiudadanoDTO>().ReverseMap();
            
            CreateMap<Infraccione, InfraccionesDTO>().ReverseMap();

           

            CreateMap<Infraccionesciudadano, InfraccionesCiudadanoDTO>().ReverseMap();

			CreateMap<Victima, VictimaDTO>().ReverseMap();
			CreateMap<Arrestopolicial, ArrestopolicialoDTO>().ReverseMap();

		}
    }
}
