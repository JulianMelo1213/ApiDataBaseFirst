using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApi.DTO.Cliente
{
    public class PutClienteDTO
    {
        [Required]
        public int IdCliente { get; set; }

        [MaxLength(100)]
        public string? Nombre { get; set; }

        [MaxLength(255)]
        public string? Direccion { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }
    }


}
