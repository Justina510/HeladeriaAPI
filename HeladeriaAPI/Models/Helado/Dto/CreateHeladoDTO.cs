using System.ComponentModel.DataAnnotations;

namespace HeladeriaAPI.Models.Helado.Dto
{
    public class CreateHeladoDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres")]
        public string Descripcion { get; set; } = null!;

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public double Precio { get; set; }

        public bool IsArtesanal { get; set; }

        public List<string> Ingredientes { get; set; } = new();

        [StringLength(300, ErrorMessage = "La URL de la imagen no puede tener más de 300 caracteres")]
        public string? ImagenUrl { get; set; }
    }
}
