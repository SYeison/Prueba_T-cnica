using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVotaciones.Models;
using System.Web;

namespace SistemaVotaciones.Clases
{
    public class clsVote
    {
        // Instancia del contexto de base de datos para acceder a las tablas
        DBSistemaVotacionEntities db = new DBSistemaVotacionEntities();

        // Objeto de tipo Voto que se usa como entrada para registrar un nuevo voto
        public Voto voto { get; set; }

        // Método para emitir un voto
        public string EmitirVoto()
        {
            try
            {
                // Buscar al votante por su ID
                var votante = db.Votantes.FirstOrDefault(v => v.Id == voto.VotanteId);
                if (votante == null)
                    return "Votante no encontrado.";

                // Verificar si el votante ya ha votado
                if (votante.HasVoted)
                    return "Este votante ya ha votado.";

                // Buscar al candidato por su ID
                var candidato = db.Candidatoes.FirstOrDefault(c => c.Id == voto.CandidatoId);
                if (candidato == null)
                    return "Candidato no válido.";

                // Registrar el voto
                votante.HasVoted = true;       // Marcar al votante como que ya votó
                candidato.Votos += 1;          // Aumentar el conteo de votos del candidato

                db.Votoes.Add(voto);           // Agregar el voto a la base de datos
                db.SaveChanges();              // Guardar los cambios

                return "Voto registrado correctamente.";
            }
            catch (Exception ex)
            {
                // En caso de error, devolver el mensaje de la excepción
                return ex.Message;
            }
        }

        // Método para consultar todos los votos registrados
        public List<Voto> ConsultarVotos()
        {
            return db.Votoes.ToList();
        }

        // Método para obtener estadísticas de la votación
        public object ObtenerEstadisticas()
        {
            // Contar la cantidad total de votos
            int totalVotos = db.Votoes.Count();

            // Obtener los resultados de cada candidato con su porcentaje de votos
            var resultados = db.Candidatoes
                .Select(c => new
                {
                    c.Nombre,
                    c.Votos,
                    Porcentaje = totalVotos > 0 ? (double)c.Votos / totalVotos * 100 : 0
                })
                .OrderByDescending(c => c.Votos) // Ordenar de mayor a menor por cantidad de votos
                .ToList()
                .Select(c => new
                {
                    c.Nombre,
                    c.Votos,
                    Porcentaje = c.Porcentaje.ToString("F2") + "%" // Formatear porcentaje con 2 decimales
                }).ToList();

            // Contar cuántos votantes ya han votado
            int totalVotantes = db.Votantes.Count(v => v.HasVoted);

            // Devolver objeto con el resumen de estadísticas
            return new
            {
                TotalVotos = totalVotos,
                Resultados = resultados,
                TotalVotantes = totalVotantes
            };
        }
    }
}
