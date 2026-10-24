using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SistemaVeterinario.Clases;

namespace SistemaVeterinario.Datos
{
    public class CrudCliente
    {
        private const string connectionString = "Data Source=veterinaria.db";

        public static void CrearCliente(Cliente cliente)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Clientes (Documento, Nombre, Telefono) 
                                        VALUES ($documento, $nombre, $telefono)";
                command.Parameters.AddWithValue("$documento", cliente.Documento);
                command.Parameters.AddWithValue("$nombre", cliente.Nombre);
                command.Parameters.AddWithValue("$telefono", cliente.Telefono);
                command.ExecuteNonQuery();
            }
        }

        public static List<Cliente> LeerClientes()
        {
            var lista = new List<Cliente>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Documento, Nombre, Telefono FROM Clientes";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cliente
                        {
                            Id = reader.GetInt32(0),
                            Documento = reader.GetString(1),
                            Nombre = reader.GetString(2),
                            Telefono = reader.GetString(3)
                        });
                    }
                }
            }
            return lista;
        }

        public static void ActualizarCliente(Cliente cliente)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE Clientes SET Nombre = $nombre, Telefono = $telefono 
                                        WHERE Documento = $documento";
                command.Parameters.AddWithValue("$documento", cliente.Documento);
                command.Parameters.AddWithValue("$nombre", cliente.Nombre);
                command.Parameters.AddWithValue("$telefono", cliente.Telefono);
                command.ExecuteNonQuery();
            }
        }

        public static void EliminarCliente(string documento)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Clientes WHERE Documento = $documento";
                command.Parameters.AddWithValue("$documento", documento);
                command.ExecuteNonQuery();
            }
        }
    }
}