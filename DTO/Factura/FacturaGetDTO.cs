namespace DatabaseFirstApi.DTO.Factura
{
    public class GetFacturaDTO
    {
        public int IdFactura { get; set; }
        public DateOnly? Fecha { get; set; }
        public int? IdCliente { get; set; }
    }

}
