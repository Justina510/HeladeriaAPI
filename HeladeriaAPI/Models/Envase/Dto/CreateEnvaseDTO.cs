using System.ComponentModel.DataAnnotations;

namespace HeladeriaAPI.Models.Envase.Dto
{
    public class CreateEnvaseDTO
    {
        [Required(ErrorMessage = "El tipo es obligatorio")]
        [StringLength(25, ErrorMessage = "El tipo no puede tener más de 25 caracteres")]
        public string Tipo { get; set; } = null!;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres")]
        public string Descripcion { get; set; } = null!;

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Precio { get; set; }

        public bool Comestible { get; set; }

        public bool Disponible { get; set; } = true;

        [StringLength(300, ErrorMessage = "La URL de la imagen no puede tener más de 300 caracteres")]
        public string? ImagenUrl { get; set; } 
    }
}
