using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApi.DTO.Producto
{
    public class PutProductoDTO
    {
        [Required]
        public int IdProducto { get; set; }

        [MaxLength(100)]
        public string? Descripcion { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public decimal? Precio { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El IdCategoria debe ser un valor positivo.")]
        public int? IdCategoria { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El IdProveedor debe ser un valor positivo.")]
        public int? IdProveedor { get; set; }
    }

}
