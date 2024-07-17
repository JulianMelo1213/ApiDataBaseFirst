using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApi.DTO.Factura
{
    public class PutFacturaDTO
    {
        [Required]
        public int IdFactura { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? Fecha { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El IdCliente debe ser un valor positivo.")]
        public int? IdCliente { get; set; }
    }


}
