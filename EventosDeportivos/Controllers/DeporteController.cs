using EventosDeportivos.Models.deporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static EventosDeportivos.Models.deporte.CsEstructuraDeporte;

namespace EventosDeportivos.Controllers
{
    public class DeporteController : ApiController
    {
        [HttpPost]
        [Route("api/rest/insertarDeporte")]
        public IHttpActionResult InsertarDeporte(RequestDeporte model)
        {
            return Ok(new CsDeporte().InsertarDeporte(model.idDeporte, model.tipoDeporte, model.categoria));
        }
        [HttpPost]
        [Route("api/rest/actualizarDeporte")]
        public IHttpActionResult ActualizarDeporte(RequestDeporte model)
        {
            return Ok(new CsDeporte().ActualizarDeporte(model.idDeporte, model.tipoDeporte, model.categoria));
        }
        [HttpPost]
        [Route("api/rest/eliminarDeporte")]
        public IHttpActionResult EliminarDeporte(RequestEliminarDeporte model)
        {
            return Ok(new CsDeporte().EliminarDeporte(model.idDeporte));
        }
        [HttpGet]
        [Route("api/rest/listarDeportes")]
        public IHttpActionResult ListarDeportes()
        {
            return Ok(new CsDeporte().ListarDeportes());
        }
        [HttpGet]
        [Route("api/rest/obtenerDeporte")]
        public IHttpActionResult ObtenerDeporte(string idDeporte)
        {
            return Ok(new CsDeporte().ObtenerDeporte(idDeporte));
        }
    }

}