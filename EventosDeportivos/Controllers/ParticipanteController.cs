using EventosDeportivos.Models.participante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static EventosDeportivos.Models.participante.CsEstructuraParticipante;

namespace EventosDeportivos.Controllers
{
    public class ParticipanteController : ApiController
    {
        [HttpPost]
        [Route("api/rest/insertarParticipante")]
        public IHttpActionResult InsertarParticipante(RequestParticipante model)
        {
            return Ok(new CsParticipante().InsertarParticipante(model.idParticipante,
                model.nombre, model.apellido, model.sexo, model.edad, model.telefono));
        }
        [HttpPost]
        [Route("api/rest/actualizarParticipante")]
        public IHttpActionResult ActualizarParticipante(RequestParticipante model)
        {
            return Ok(new CsParticipante().ActualizarParticipante(model.idParticipante,
                               model.nombre, model.apellido, model.sexo, model.edad, model.telefono));
        }
        [HttpPost]
        [Route("api/rest/eliminarParticipante")]
        public IHttpActionResult EliminarParticipante(RequestEliminarParticipante model)
        {
            return Ok(new CsParticipante().EliminarParticipante(model.idParticipante));
        }
        [HttpGet]
        [Route("api/rest/listarParticipantes")]
        public IHttpActionResult ListarParticipantes()
        {
            return Ok(new CsParticipante().ListarParticipantes());
        }
        [HttpGet]
        [Route("api/rest/obtenerParticipante")]
        public IHttpActionResult ObtenerParticipante(string idParticipante)
        {
            return Ok(new CsParticipante().ObtenerParticipante(idParticipante));
        }
    }
}