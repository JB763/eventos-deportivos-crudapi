using EventosDeportivos.Models.usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static EventosDeportivos.Models.usuario.CsEstructuraUsuario;

namespace EventosDeportivos.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("api/rest/insertarUsuario")]
        public IHttpActionResult InsertarUsuario(RequestUsuario model)
        {
            return Ok(new CsUsuario().InsertarUsuario(model.idUsuario,
                               model.idParticipante, model.correo, model.contraseña));
        }
        [HttpPost]
        [Route("api/rest/actualizarUsuario")]
        public IHttpActionResult ActualizarUsuario(RequestUsuario model)
        {
            return Ok(new CsUsuario().ActualizarUsuario(model.idUsuario,
                                              model.idParticipante, model.correo, model.contraseña));
        }
        [HttpPost]
        [Route("api/rest/eliminarUsuario")]
        public IHttpActionResult EliminarUsuario(RequestEliminarUsuario model)
        {
            return Ok(new CsUsuario().EliminarUsuario(model.idUsuario));
        }
        [HttpGet]
        [Route("api/rest/listarUsuarios")]
        public IHttpActionResult ListarUsuarios()
        {
            return Ok(new CsUsuario().ListarUsuarios());
        }
        [HttpGet]
        [Route("api/rest/obtenerUsuario")]
        public IHttpActionResult ObtenerUsuario(string idUsuario)
        {
            return Ok(new CsUsuario().ObtenerUsuario(idUsuario));
        }
    }
}