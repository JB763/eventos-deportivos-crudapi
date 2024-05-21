﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace EventosDeportivos.Models.usuario
{
    public class CsEstructuraUsuario
    {
        public class RequestUsuario
        {
            public string idUsuario { get; set; }
            public string idParticipante { get; set; }          
            public string correo { get; set; }
            public string contraseña { get; set; }
        }
        public class ResponseUsuario
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
        public class RequestEliminarUsuario
        {
            public string idUsuario { get; set; }
        }
    }
}