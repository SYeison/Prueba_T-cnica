using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using SistemaVotaciones.Models;

namespace SistemaVotaciones.Clases
{
    public class clsVoter
    {
        // Instancia del contexto de base de datos para acceder a las tablas
        DBSistemaVotacionEntities db = new DBSistemaVotacionEntities();

        // Propiedad para recibir los datos del votante desde la capa externa
        public Votante votante { get; set; }

        // Método para insertar un votante nuevo
        public string Insertar()
        {
            try
            {
                // Validar si ya hay un votante con el mismo correo
                if (db.Votantes.Any(v => v.Email == votante.Email))
                    return "Ya existe un votante registrado con este correo.";

                // Validar si el nombre ya está registrado como candidato
                if (db.Candidatoes.Any(c => c.Nombre == votante.Nombre))
                    return "Este nombre ya está registrado como candidato.";

                // Si pasa las validaciones, se guarda el votante
                db.Votantes.Add(votante);
                db.SaveChanges();

                return "Votante registrado: " + votante.Nombre;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Método para consultar todos los votantes ordenados por nombre
        public List<Votante> ConsultarTodos()
        {
            return db.Votantes.OrderBy(v => v.Nombre).ToList();
        }

        // Método para actualizar un votante ya existente
        public string Actualizar()
        {
            try
            {
                db.Votantes.AddOrUpdate(votante);
                db.SaveChanges();
                return "Se actualizó el votante con ID: " + votante.Id;
            }
            catch (Exception ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        // Método para eliminar un votante por su ID
        public string Eliminar()
        {
            Votante _votante = Consultar(votante.Id);

            if (_votante == null)
                return "El votante no existe.";

            db.Votantes.Remove(_votante);
            db.SaveChanges();

            return "Votante eliminado: " + _votante.Nombre;
        }

        // Método para consultar un votante específico por su ID
        public Votante Consultar(int id)
        {
            return db.Votantes.FirstOrDefault(v => v.Id == id);
        }
    }
}
