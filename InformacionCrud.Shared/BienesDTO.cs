using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InformacionCrud.Shared
{
    public class BienesDTO
    {
        public int Idbienes { get; set; }

        public string? Bienes { get; set; }

        public ulong? Estado { get; set; }
    }
}
