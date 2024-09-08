using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class DelitosDTO
    {
        public int Iddelitos { get; set; }

        public string? Delitos { get; set; }

        public int? Tiposdelitos { get; set; }

        public ulong? Estado { get; set; }



        public TiposdelitoDTO? TiposdelitosNavigation { get; set; }
    }
}
