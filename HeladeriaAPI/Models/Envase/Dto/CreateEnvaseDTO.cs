using System.ComponentModel.DataAnnotations;

namespace HeladeriaAPI.Models.Envase.Dto
{
    public class CreateEnvaseDTO
    {
        [Required(ErrorMessage = "El tipo es obligatorio")]
        [StringLength(100, ErrorMessage = "El tipo no puede tener mas de 25 caracteres")]
        public string Tipo { get; set; } = null!;

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripcion no puede tener mas de 100 caracteres")]
        public string Descripcion { get; set; } = null!;

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Precio { get; set; }

        public bool Comestible { get; set; }

        public bool Disponible { get; set; } = true;
    }
}
