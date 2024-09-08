using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class ResponseAPI<TEntity>
    {
        public HttpStatusCode CodigoEstado { get; set; }

        public bool EsExitoso { get; set; }

        public TEntity Resultado { get; set; }

        //_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

        // propiedades fallidas

        public string? MensajeError { get; set; }

        public List<string>? MensajesError { get; set; }
    }
}
