namespace SistemaVeterinario.Clases
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Diagnostico { get; set; }
        public double Peso { get; set; }
        public int MascotaId { get; set; }
    }
}