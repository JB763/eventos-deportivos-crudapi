using EventosDeportivos.Models.premiacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static EventosDeportivos.Models.premiacion.CsEstructuraPremiacion;

namespace EventosDeportivos.Controllers
{
    public class PremiacionController : ApiController
    {
        [HttpPost]
        [Route("api/rest/insertarPremiacion")]
        public IHttpActionResult InsertarPremiacion(Requestpremiacion model)
        {
            return Ok(new CsPremiacion().InsertarPremiacion(model.idPremiacion, model.idEvento, model.posicion, model.descripcion, model.fecha));
        }
        [HttpPost]
        [Route("api/rest/actualizarPremiacion")]
        public IHttpActionResult ActualizarPremiacion(Requestpremiacion model)
        {
            return Ok(new CsPremiacion().ActualizarPremiacion(model.idPremiacion, model.idEvento, model.posicion, model.descripcion, model.fecha));
        }
        [HttpPost]
        [Route("api/rest/eliminarPremiacion")]
        public IHttpActionResult EliminarPremiacion(RequestEliminarPremiacion model)
        {
            return Ok(new CsPremiacion().EliminarPremiacion(model.idPremiacion));
        }
        [HttpGet]
        [Route("api/rest/listarPremiacion")]
        public IHttpActionResult ListarPremiacion()
        {
            return Ok(new CsPremiacion().ListarPremiacion());
        }
        [HttpGet]
        [Route("api/rest/obtenerPremiacion")]
        public IHttpActionResult ObtenerPremiacion(string idPremiacion)
        {
            return Ok(new CsPremiacion().ObtenerPremiacion(idPremiacion));
        }

    }
}