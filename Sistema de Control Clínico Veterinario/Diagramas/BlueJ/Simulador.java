import java.util.Scanner;

public class Simulador {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        HistorialMedico historial = new HistorialMedico();
        
        // Variables temporales simulando una base de datos en memoria
        Cliente clienteActual = null;
        Mascota mascotaActual = null;
        
        boolean continuar = true;

        while (continuar) {
            System.out.println("\n=== SISTEMA CLÍNICO VETERINARIO ===");
            System.out.println("1. Registrar Cliente");
            System.out.println("2. Registrar Mascota");
            System.out.println("3. Registrar Consulta Médica");
            System.out.println("4. Ver Historial Médico");
            System.out.println("5. Salir");
            System.out.print("Elija una opción: ");
            
            String opcion = scanner.nextLine();

            switch (opcion) {
                case "1":
                    clienteActual = new Cliente("1001", "Ana Lopez", "555-1234");
                    System.out.println("Cliente " + clienteActual.getNombre() + " registrado.");
                    break;
                case "2":
                    if (clienteActual == null) {
                        System.out.println("Alerta: Debe registrar al dueño primero.");
                    } else {
                        mascotaActual = new Mascota("M01", "Firulais", "Perro", clienteActual);
                        System.out.println("Mascota " + mascotaActual.getNombre() + " registrada.");
                    }
                    break;
                case "3":
                    if (mascotaActual == null) {
                        System.out.println("Alerta: Registre la mascota primero.");
                    } else {
                        Consulta consulta = new Consulta("2026-09-19", "Vacunación anual", 12.5, mascotaActual);
                        historial.registrarConsulta(consulta);
                    }
                    break;
                case "4":
                    if (mascotaActual != null) {
                        historial.mostrarHistorial(mascotaActual.getIdMascota());
                    } else {
                        System.out.println("No hay mascota activa para consultar.");
                    }
                    break;
                case "5":
                    continuar = false;
                    System.out.println("Cerrando sistema...");
                    break;
                default:
                    System.out.println("Opción inválida.");
                    break;
            }
        }
        scanner.close();
    }
}