using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InformacionCrud.Shared
{
    public class AntecentesciudadanoDTO
    {
        public int Idantecedentesciudadano { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Delitos { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tiposdelitos { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Detenciones { get; set; }



        public DateOnly? Fechadelito { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Penaimpuesta { get; set; }


        public ulong? Estado { get; set; }


        public CiudadanoDTO? CiudadanoNavigation { get; set; }

        public DelitosDTO? DelitosNavigation { get; set; }

        public DetencionesDTO? DetencionesNavigation { get; set; }

        public PenaimpuestaDTO? PenaimpuestaNavigation { get; set; }

        public TiposdelitoDTO? TiposdelitosNavigation { get; set; }
    }
}
