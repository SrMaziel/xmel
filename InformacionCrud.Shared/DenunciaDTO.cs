using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InformacionCrud.Shared
{
    public class DenunciaDTO
    {
        public int Iddenuncia { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]

        public string? Denuncia { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        
        public string? Tipodenuncia { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
       
        public string? Denunciante { get; set; }


        
        public string? Denunciado { get; set; }

        public ulong? Estado { get; set; }
    }
}
