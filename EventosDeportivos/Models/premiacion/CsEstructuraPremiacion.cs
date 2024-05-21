using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventosDeportivos.Models.premiacion
{
    public class CsEstructuraPremiacion
    {
        public class Requestpremiacion
        {
            public string idPremiacion { get; set; }
            public string idEvento { get; set; }
            public int posicion { get; set; }
            public string descripcion { get; set; }
            public DateTime fecha { get; set; }
        }
        public class ResponsePremiacion 
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
        public class RequestEliminarPremiacion
        {
            public string idPremiacion { get; set; }
        }

    }
}