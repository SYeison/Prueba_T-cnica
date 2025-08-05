using SistemaVotaciones.Clases;
using SistemaVotaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace SistemaVotaciones.Controllers
{


    [RoutePrefix("api/voters")]
    public class VotantesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Votante votante)
        {
            clsVoter cls = new clsVoter { votante = votante };
            return cls.Insertar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Votante votante)
        {
            clsVoter cls = new clsVoter { votante = votante };
            return cls.Eliminar();
        }

        [HttpGet]
        [Route("Consultar")]
        public List<Votante> Consultar()
        {
            clsVoter cls = new clsVoter();
            return cls.ConsultarTodos();
        }
    }
}
