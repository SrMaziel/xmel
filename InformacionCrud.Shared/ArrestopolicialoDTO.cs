using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;

namespace InformacionCrud.Shared
{
    public class ArrestopolicialoDTO
    {

        public int Idarrestopolicial { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]

        public int? Tipociudadano { get; set; }




        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]

        public int? Ciudadano { get; set; }




        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Delitos { get; set; }



       
        public string? Denunciantes { get; set; }



      
        public string? Denunciado { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Detencione { get; set; }



       
        public int? Denuncia { get; set; }

        public ulong? Estado { get; set; }


        public virtual CiudadanoDTO? CiudadanoNavigation { get; set; }


        public TiposciudadanoDTO? TipociudadanoNavigation { get; set; }

        public virtual DelitosDTO? DelitosNavigation { get; set; }


        public virtual DetencionesDTO? DetencionesNavigation { get; set; }

        public virtual DenunciaDTO? DenunciaNavigation { get; set; }
    }
}