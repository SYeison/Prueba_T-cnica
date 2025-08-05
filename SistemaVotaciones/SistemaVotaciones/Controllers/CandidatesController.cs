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


    [RoutePrefix("api/candidates")]
    public class CandidatesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Candidato candidato)
        {
            clsCandidate cls = new clsCandidate();
            cls.candidato = candidato;
            return cls.Insertar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Candidato candidato)
        {
            clsCandidate cls = new clsCandidate { candidato = candidato };
            return cls.Eliminar();
        }

        [HttpGet]
        [Route("Consultar")]
        public List<Candidato> Consultar()
        {
            clsCandidate cls = new clsCandidate();
            return cls.ConsultarTodos();
        }
    }
}

