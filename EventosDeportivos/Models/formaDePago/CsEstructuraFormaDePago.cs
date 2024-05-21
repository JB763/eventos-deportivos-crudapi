using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventosDeportivos.Models.formaDePago
{
    public class CsEstructuraFormaDePago
    {
        public class RequestFormaDePago
        {
            public string idFormaDePago { get; set; }
            public string tipoPago { get; set; }

        }
        public class ResponseFormaDePago
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
        public class RequestEliminarFormaDePago
        {
            public string idFormaDePago { get; set; }
        }       
    }
}