namespace HeladeriaAPI.Models.Helado
{
    public class Helado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public double Precio { get; set; }
        public bool IsArtesanal { get; set; }
        public List<string> Ingredientes { get; set; } = new();
        public DateTime FechasCreacion { get; set; } = DateTime.Now;
        public string? ImagenUrl { get; set; }

    }
}
