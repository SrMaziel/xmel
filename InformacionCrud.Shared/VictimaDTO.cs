using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InformacionCrud.Shared
{
	public class VictimaDTO
	{
		public int Idvictimas { get; set; }


		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
		public int? Ciudadano { get; set; }

		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string? Accidente { get; set; }

		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string? Heridas { get; set; }

		public ulong? Estado { get; set; }


		public CiudadanoDTO? CiudadanoNavigation { get; set; }
	}
}
