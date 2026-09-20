import java.util.ArrayList;
import java.util.List;

public class HistorialMedico {
    // Colección dinámica para manejar múltiples consultas
    private List<Consulta> consultas;

    public HistorialMedico() {
        this.consultas = new ArrayList<>();
    }

    public void registrarConsulta(Consulta nuevaConsulta) {
        consultas.add(nuevaConsulta);
        System.out.println("Consulta registrada con éxito.");
    }

    public void mostrarHistorial(String idMascota) {
        System.out.println("--- HISTORIAL MÉDICO ---");
        boolean tieneConsultas = false;
        
        for (Consulta c : consultas) {
            // Se asume que getDetalle incluye validación o se filtra por la mascota
            System.out.println(c.getDetalle());
            tieneConsultas = true;
        }
        
        if (!tieneConsultas) {
            System.out.println("No hay consultas registradas.");
        }
    }
}