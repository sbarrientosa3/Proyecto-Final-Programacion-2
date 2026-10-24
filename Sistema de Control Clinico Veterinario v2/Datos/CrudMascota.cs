using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaVeterinario.Clases;

namespace SistemaVeterinario.Datos
{
    public class CrudMascota
    {
        private const string connectionString = "Data Source=veterinaria.db";

        public static void CrearMascota(Mascota mascota)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Mascotas (Nombre, Especie, ClienteId) 
                                        VALUES ($nombre, $especie, $clienteId)";
                command.Parameters.AddWithValue("$nombre", mascota.Nombre);
                command.Parameters.AddWithValue("$especie", mascota.Especie);
                command.Parameters.AddWithValue("$clienteId", mascota.ClienteId);
                command.ExecuteNonQuery();
            }
        }

        public static List<Mascota> LeerMascotas()
        {
            var lista = new List<Mascota>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Nombre, Especie, ClienteId FROM Mascotas";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Mascota
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Especie = reader.GetString(2),
                            ClienteId = reader.GetInt32(3)
                        });
                    }
                }
            }
            return lista;
        }

        public static void EliminarMascota(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Mascotas WHERE Id = $id";
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}