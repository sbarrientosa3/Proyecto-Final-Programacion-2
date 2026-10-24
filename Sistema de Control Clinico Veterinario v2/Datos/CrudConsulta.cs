using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaVeterinario.Clases;

namespace SistemaVeterinario.Datos
{
    public class CrudConsulta
    {
        private const string connectionString = "Data Source=veterinaria.db";

        public static void CrearConsulta(Consulta consulta)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Consultas (Fecha, Diagnostico, Peso, MascotaId) 
                                        VALUES ($fecha, $diagnostico, $peso, $mascotaId)";
                command.Parameters.AddWithValue("$fecha", consulta.Fecha);
                command.Parameters.AddWithValue("$diagnostico", consulta.Diagnostico);
                command.Parameters.AddWithValue("$peso", consulta.Peso);
                command.Parameters.AddWithValue("$mascotaId", consulta.MascotaId);
                command.ExecuteNonQuery();
            }
        }

        public static List<Consulta> LeerConsultasPorMascota(int mascotaId)
        {
            var lista = new List<Consulta>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Fecha, Diagnostico, Peso, MascotaId FROM Consultas WHERE MascotaId = $mascotaId";
                command.Parameters.AddWithValue("$mascotaId", mascotaId);
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Consulta
                        {
                            Id = reader.GetInt32(0),
                            Fecha = reader.GetString(1),
                            Diagnostico = reader.GetString(2),
                            Peso = reader.GetDouble(3),
                            MascotaId = reader.GetInt32(4)
                        });
                    }
                }
            }
            return lista;
        }
    }
}