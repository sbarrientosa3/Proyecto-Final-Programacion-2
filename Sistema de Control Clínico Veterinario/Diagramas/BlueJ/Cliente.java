public class Cliente {
    // Encapsulamiento: atributos privados
    private String documento;
    private String nombre;
    private String telefono;

    // Constructor
    public Cliente(String documento, String nombre, String telefono) {
        this.documento = documento;
        this.nombre = nombre;
        this.telefono = telefono;
    }

    // Métodos de acceso (Getters)
    public String getDocumento() { return documento; }
    public String getNombre() { return nombre; }
    public String getTelefono() { return telefono; }
}