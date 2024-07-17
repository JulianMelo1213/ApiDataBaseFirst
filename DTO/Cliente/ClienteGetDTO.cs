namespace DatabaseFirstApi.DTO.Cliente
{
    public class GetClienteDTO
    {
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
