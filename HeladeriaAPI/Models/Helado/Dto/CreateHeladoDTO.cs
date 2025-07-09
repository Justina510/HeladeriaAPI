using System.ComponentModel.DataAnnotations;

namespace HeladeriaAPI.Models.Helado.Dto
{
    public class CreateHeladoDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener mas de 30 caracteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripcion no puede tener mas de 100 caracteres")]
        public string Descripcion { get; set; } = null!;

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public double Precio { get; set; }

        public bool IsArtesanal { get; set; }

        public List<string> Ingredientes { get; set; } = new();
    }
}
