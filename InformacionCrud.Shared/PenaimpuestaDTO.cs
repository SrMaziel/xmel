using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class PenaimpuestaDTO
    {
        public int Idpenaimpuesta { get; set; }

        public int? Delitos { get; set; }

        public int? Tiposdelitos { get; set; }

        public string? Penaimpuesta { get; set; }

        public ulong? Estado { get; set; }

        public TiposdelitoDTO? TiposdelitosNavigation { get; set; }

        public DelitosDTO? DelitosNavigation { get; set; }
    }
}
