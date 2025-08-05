using SistemaVotaciones.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SistemaVotaciones.Clases
{
    public class clsCandidate
    {
        // Instancia del contexto de base de datos
        private DBSistemaVotacionEntities db = new DBSistemaVotacionEntities();

        // Propiedad para recibir los datos del candidato desde fuera
        public Candidato candidato { get; set; }

        // Método para insertar un nuevo candidato
        public string Insertar()
        {
            try
            {
                // Verifica si ya existe un votante con el mismo nombre
                if (db.Votantes.Any(v => v.Nombre == candidato.Nombre))
                    return "Este nombre ya está registrado como votante.";

                // Guarda el nuevo candidato si no hay conflictos
                db.Candidatoes.Add(candidato);
                db.SaveChanges();
                return "Candidato registrado: " + candidato.Nombre;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Método para consultar todos los candidatos ordenados por nombre
        public List<Candidato> ConsultarTodos()
        {
            return db.Candidatoes.OrderBy(c => c.Nombre).ToList();
        }

        // Método para actualizar los datos de un candidato
        public string Actualizar()
        {
            try
            {
                db.Candidatoes.AddOrUpdate(candidato);
                db.SaveChanges();
                return "Se actualizó el candidato con ID: " + candidato.Id;
            }
            catch (Exception ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        // Método para eliminar un candidato por su ID
        public string Eliminar()
        {
            Candidato _candidato = Consultar(candidato.Id);

            if (_candidato == null)
                return "El candidato no existe.";

            db.Candidatoes.Remove(_candidato);
            db.SaveChanges();
            return "Candidato eliminado: " + _candidato.Nombre;
        }

        // Método para consultar un candidato específico por su ID
        public Candidato Consultar(int id)
        {
            return db.Candidatoes.FirstOrDefault(c => c.Id == id);
        }
    }
}
