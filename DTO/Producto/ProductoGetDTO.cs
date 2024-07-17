namespace DatabaseFirstApi.DTO.Producto
{
    public class GetProductoDTO
    {
        public int IdProducto { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdProveedor { get; set; }
    }

}
