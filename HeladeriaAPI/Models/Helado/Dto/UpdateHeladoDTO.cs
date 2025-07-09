using System.ComponentModel.DataAnnotations;

namespace HeladeriaAPI.Models.Helado.Dto
{
    public class UpdateHeladoDTO
    {
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres")]
        public string? Nombre { get; set; }

        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres")]
        public string? Descripcion { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public double? Precio { get; set; }

        public bool? IsArtesanal { get; set; }

        public List<string>? Ingredientes { get; set; }
    }
}
