namespace DatabaseFirstApi.DTO.Venta
{
    public class GetVentaDTO
    {
        public int IdVenta { get; set; }
        public int? IdFactura { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
    }

}
