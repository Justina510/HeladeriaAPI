using System.ComponentModel.DataAnnotations;

namespace HeladeriaAPI.Models.Envase.Dto
{
    public class UpdateEnvaseDTO
    {
        [StringLength(25, ErrorMessage = "El tipo no puede tener mas de 25 caracteres")]
        public string? Tipo { get; set; }

        [StringLength(100, ErrorMessage = "La descripcion no puede tener mas de 100 caracteres")]
        public string? Descripcion { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal? Precio { get; set; }

        public bool? Comestible { get; set; }
    }
}
