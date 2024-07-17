using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApi.DTO.Venta
{
    public class InsertVentaDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "El IdFactura debe ser un valor positivo.")]
        public int? IdFactura { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El IdProducto debe ser un valor positivo.")]
        public int? IdProducto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser un valor positivo.")]
        public int? Cantidad { get; set; }
    }

}
