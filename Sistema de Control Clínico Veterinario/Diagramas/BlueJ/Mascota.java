public class Mascota {
    private String idMascota;
    private String nombre;
    private String especie;
    private Cliente dueño; // Relación de Asociación

    public Mascota(String idMascota, String nombre, String especie, Cliente dueño) {
        this.idMascota = idMascota;
        this.nombre = nombre;
        this.especie = especie;
        this.dueño = dueño;
    }

    public String getIdMascota() { return idMascota; }
    public String getNombre() { return nombre; }
    public Cliente getDueño() { return dueño; }
}