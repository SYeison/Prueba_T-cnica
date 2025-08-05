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


    [RoutePrefix("api/Votes")]
    public class VotosController : ApiController
    {
        [HttpPost]
        [Route("Emitir")]
        public string Emitir([FromBody] Voto voto)
        {
            clsVote cls = new clsVote { voto = voto };
            return cls.EmitirVoto();
        }

        [HttpGet]
        [Route("Consultar")]
        public List<Voto> Consultar()
        {
            clsVote cls = new clsVote();
            return cls.ConsultarVotos();
        }

        [HttpGet]
        [Route("Estadisticas")]
        public object Estadisticas()
        {
            clsVote cls = new clsVote();
            return cls.ObtenerEstadisticas();
        }
    }
}
    
