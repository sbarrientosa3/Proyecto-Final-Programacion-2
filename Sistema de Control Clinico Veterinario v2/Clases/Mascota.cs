namespace SistemaVeterinario.Clases
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public int ClienteId { get; set; }
    }
}