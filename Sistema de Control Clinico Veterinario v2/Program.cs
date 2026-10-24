using System;
using SistemaVeterinario.Clases;
using SistemaVeterinario.Datos;

namespace SistemaVeterinario
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.InicializarTablas();
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE CONTROL CLÍNICO VETERINARIO v2 ===");
                Console.WriteLine("1. Registrar Cliente (Dueño)");
                Console.WriteLine("2. Registrar Mascota (Paciente)");
                Console.WriteLine("3. Registrar Consulta Médica");
                Console.WriteLine("4. Ver Historial Médico");
                Console.WriteLine("5. Salir");
                Console.Write("Elija una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("\nDocumento (DPI/ID): ");
                        string doc = Console.ReadLine();
                        Console.Write("Nombre completo: ");
                        string nom = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        string tel = Console.ReadLine();
                        
                        CrudCliente.CrearCliente(new Cliente { Documento = doc, Nombre = nom, Telefono = tel });
                        Console.WriteLine("\n[ÉXITO] Cliente registrado correctamente.");
                        break;

                    case "2":
                        Console.Write("\nNombre de la mascota: ");
                        string nomMascota = Console.ReadLine();
                        Console.Write("Especie (Ej. Perro, Gato): ");
                        string especie = Console.ReadLine();
                        Console.Write("ID del Cliente (Dueño): ");
                        
                        if (int.TryParse(Console.ReadLine(), out int idCliente))
                        {
                            CrudMascota.CrearMascota(new Mascota { Nombre = nomMascota, Especie = especie, ClienteId = idCliente });
                            Console.WriteLine("\n[ÉXITO] Mascota registrada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("\n[ERROR] ID de cliente inválido.");
                        }
                        break;

                    case "3":
                        Console.Write("\nID de la Mascota: ");
                        if (int.TryParse(Console.ReadLine(), out int idMascota))
                        {
                            Console.Write("Fecha (YYYY-MM-DD): ");
                            string fecha = Console.ReadLine();
                            Console.Write("Diagnóstico: ");
                            string diagnostico = Console.ReadLine();
                            Console.Write("Peso (kg): ");
                            
                            if (double.TryParse(Console.ReadLine(), out double peso))
                            {
                                CrudConsulta.CrearConsulta(new Consulta { Fecha = fecha, Diagnostico = diagnostico, Peso = peso, MascotaId = idMascota });
                                Console.WriteLine("\n[ÉXITO] Consulta médica registrada.");
                            }
                            else
                            {
                                Console.WriteLine("\n[ERROR] Peso inválido.");
                            }
                        }
                        break;

                    case "4":
                        Console.Write("\nIngrese el ID de la Mascota para ver su historial: ");
                        if (int.TryParse(Console.ReadLine(), out int idMascotaHistorial))
                        {
                            var historial = CrudConsulta.LeerConsultasPorMascota(idMascotaHistorial);
                            Console.WriteLine("\n--- HISTORIAL MÉDICO ---");
                            if (historial.Count == 0)
                            {
                                Console.WriteLine("No hay consultas registradas para esta mascota.");
                            }
                            else
                            {
                                foreach (var consulta in historial)
                                {
                                    Console.WriteLine($"Fecha: {consulta.Fecha} | Peso: {consulta.Peso}kg | Diagnóstico: {consulta.Diagnostico}");
                                }
                            }
                        }
                        break;

                    case "5":
                        continuar = false;
                        Console.WriteLine("\nCerrando el sistema...");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}