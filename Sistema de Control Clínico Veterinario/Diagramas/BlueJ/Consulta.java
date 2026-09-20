public class Consulta {
    private String fecha;
    private String diagnostico;
    private double peso;
    private Mascota paciente; // Relación de Asociación

    public Consulta(String fecha, String diagnostico, double peso, Mascota paciente) {
        this.fecha = fecha;
        this.diagnostico = diagnostico;
        this.peso = peso;
        this.paciente = paciente;
    }

    public String getDetalle() {
        return "Fecha: " + fecha + " | Paciente: " + paciente.getNombre() + 
               " | Peso: " + peso + "kg | Diagnóstico: " + diagnostico;
    }
}