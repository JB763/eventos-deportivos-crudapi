using EventosDeportivos.Models.inscripcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static EventosDeportivos.Models.inscripcion.CsEstructuraInscripcion;

namespace EventosDeportivos.Controllers
{
    public class InscripcionController : ApiController
    {
        [HttpPost]
        [Route("api/rest/insertarInscripcion")]
        public IHttpActionResult InsertarInscripcion(RequestInscripcion model)
        {
            return Ok(new CsInscripcion().InsertarInscripcion(model.idInscripcion, model.idEvento,
                model.idParticipante, model.idFormaDePago, model.fechaIn, model.fechaFin));
        }
        [HttpPost]
        [Route("api/rest/actualizarInscripcion")]
        public IHttpActionResult ActualizarInscripcion(RequestInscripcion model)
        {
            return Ok(new CsInscripcion().ActualizarInscripcion(model.idInscripcion, model.idEvento,
                               model.idParticipante, model.idFormaDePago, model.fechaIn, model.fechaFin));
        }
        [HttpPost]
        [Route("api/rest/eliminarInscripcion")]
        public IHttpActionResult EliminarInscripcion(RequestEliminarInscripcion model)
        {
            return Ok(new CsInscripcion().EliminarInscripcion(model.idInscripcion));
        }
        [HttpGet]
        [Route("api/rest/listarInscripcion")]
        public IHttpActionResult ListarInscripcion()
        {
            return Ok(new CsInscripcion().ListarInscripcion());
        }
        [HttpGet]
        [Route("api/rest/obtenerInscripcion")]
        public IHttpActionResult ObtenerInscripcion(string idInscripcion)
        {
            return Ok(new CsInscripcion().ObtenerInscripcion(idInscripcion));
        }
    }
}