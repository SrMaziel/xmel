using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InformacionCrud.Shared
{
    public class CiudadanoDTO
    {
        public int Idciudadano { get; set; }

       
        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(20, ErrorMessage = "La longitud debe estar entre 4 y 20 caracteres. ", MinimumLength = 4)]
        public string? Nombre { get; set; }



        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(20, ErrorMessage = "La longitud debe estar entre 4 y 20 caracteres. ", MinimumLength = 4)]
        public string? Apellido { get; set; }

        


        public DateOnly? Fechanacimiento { get; set; }




        [Required(ErrorMessage = "Numero DUI obligatorio")]
        [RegularExpression(@"^\d{8}-\d{1}$", ErrorMessage = "Ingresar el numero de DUI correctamente. Debe ser 8 digitos seguidos de un guion y un digito.")]

        public string? Dui { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]

        public int? Tiposciudadanos { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]

        public int? Nacionalidad { get; set; }




        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]

        public int? Tipodedocumento { get; set; }

      


        public string? Telefonofijio { get; set; }


        [RegularExpression(@"^[267]\d{3}-\d{4}$", ErrorMessage = "El número de teléfono no es válido. Formato esperado: ####-####")]
        public string? Telefonomovil { get; set; }



        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Los espacios no estan permitidos.")]
        [StringLength(150, ErrorMessage = "La longitud debe ser entre 5 y 150 caracteres.", MinimumLength = 5)]

        public string? Correoelectronico { get; set; }

       
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string? Direccionciudadano { get; set; }


      

        public int? Bienes { get; set; }

        public byte? Estado { get; set; }

       
        
        
        public BienesDTO? BienesNavigation { get; set; }

        public TipodocumentoDTO? TipodedocumentoNavigation { get; set; }

        public TiposciudadanoDTO? TiposciudadanosNavigation { get; set; }

        public NacionalidadDTO? NacionalidadNavigation { get; set; }

    }
}
