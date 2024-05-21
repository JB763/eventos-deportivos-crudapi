using EventosDeportivos.Models.formaDePago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static EventosDeportivos.Models.formaDePago.CsEstructuraFormaDePago;

namespace EventosDeportivos.Controllers
{
    public class FormaDePagoController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarFormaDePago")]
        public IHttpActionResult InsertarFormaDePago(RequestFormaDePago model)
        {
            return Ok(new CsFormaDePago().InsertarFormaDePago(model.idFormaDePago, model.tipoPago));           
        }
        [HttpPost]
        [Route("rest/api/actualizarFormaDePago")]
        public IHttpActionResult ActualizarFormaDePago(RequestFormaDePago model)
        {
            return Ok(new CsFormaDePago().ActualizarFormaDePago(model.idFormaDePago, model.tipoPago));
        }
        [HttpPost]
        [Route("rest/api/eliminarFormaDePago")]
        public IHttpActionResult EliminarFormaDePago(RequestEliminarFormaDePago model)
        {
            return Ok(new CsFormaDePago().EliminarFormaDePago(model.idFormaDePago));
        }
        [HttpGet]
        [Route("rest/api/listarFormaDePago")]
        public IHttpActionResult ListarFormaDePago()
        {
            return Ok(new CsFormaDePago().ListarFormaDePago());
        }
        [HttpGet]
        [Route("rest/api/obtenerFormaDePago")]
        public IHttpActionResult ObtenerFormaDePago(string idFormaDePago)
        {
            return Ok(new CsFormaDePago().ObtenerFormaDePago(idFormaDePago));
        }
    }
}