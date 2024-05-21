using EventosDeportivos.Models.evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static EventosDeportivos.Models.evento.CsEstructuraEvento;

namespace EventosDeportivos.Controllers
{
    public class EventosController : ApiController
    {
        [HttpPost]
        [Route("api/rest/insertarEvento")]
        public IHttpActionResult InsertarEvento(RequestEvento model)
        {
            return Ok(new CsEvento().InsertarEvento(model.idEvento, model.idDeporte, model.nombre, model.fechaIn, model.fechaFin, model.costo, model.cupo));
        }
        [HttpPost]
        [Route("api/rest/actualizarEvento")]
        public IHttpActionResult ActualizarEvento(RequestEvento model)
        {
            return Ok(new CsEvento().ActualizarEvento(model.idEvento, model.idDeporte, model.nombre, model.fechaIn, model.fechaFin, model.costo, model.cupo));
        }
        [HttpPost]
        [Route("api/rest/eliminarEvento")]
        public IHttpActionResult EliminarEvento(RequestEventoEliminar model)
        {
            return Ok(new CsEvento().EliminarEvento(model.idEvento));
        }
        [HttpGet]
        [Route("api/rest/listarEvento")]
        public IHttpActionResult ListarEvento()
        {
            return Ok(new CsEvento().ListarEvento());
        }
        [HttpGet]
        [Route("api/rest/obtenerEvento")]
        public IHttpActionResult ObtenerEvento(string idEvento)
        {
            return Ok(new CsEvento().ObtenerEvento(idEvento));
        }
    }
}