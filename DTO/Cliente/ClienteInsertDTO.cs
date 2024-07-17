using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApi.DTO.Cliente
{
    public class InsertClienteDTO
    {
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [MaxLength(255)]
        public string? Direccion { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }
    }


}
