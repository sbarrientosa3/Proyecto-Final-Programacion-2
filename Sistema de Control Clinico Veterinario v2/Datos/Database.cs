using System;
using Microsoft.Data.Sqlite;

namespace SistemaVeterinario.Datos
{
    public class Database
    {
        private const string connectionString = "Data Source=veterinaria.db";

        public static void InicializarTablas()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string tablaClientes = @"CREATE TABLE IF NOT EXISTS Clientes (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Documento TEXT UNIQUE,
                                        Nombre TEXT,
                                        Telefono TEXT)";

                string tablaMascotas = @"CREATE TABLE IF NOT EXISTS Mascotas (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Nombre TEXT,
                                        Especie TEXT,
                                        ClienteId INTEGER,
                                        FOREIGN KEY(ClienteId) REFERENCES Clientes(Id))";

                string tablaConsultas = @"CREATE TABLE IF NOT EXISTS Consultas (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Fecha TEXT,
                                        Diagnostico TEXT,
                                        Peso REAL,
                                        MascotaId INTEGER,
                                        FOREIGN KEY(MascotaId) REFERENCES Mascotas(Id))";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = tablaClientes;
                    command.ExecuteNonQuery();
                    
                    command.CommandText = tablaMascotas;
                    command.ExecuteNonQuery();
                    
                    command.CommandText = tablaConsultas;
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Tablas de soporte inicializadas correctamente en SQLite.");
        }
    }
}