using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventosDeportivos.Models.inscripcion
{
    public class CsEstructuraInscripcion
    {
        public class RequestInscripcion
        {
            public string idInscripcion { get; set; }
            public string idEvento { get; set; }
            public string idParticipante { get; set; }
            public string idFormaDePago { get; set; }
            public DateTime fechaIn { get; set; }
            public DateTime fechaFin { get; set; }
        }
        public class ResponseInscripcion
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
        public class RequestEliminarInscripcion
        {
            public string idInscripcion { get; set; }
        }
    }
}