using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApi.DTO.Proveedor
{
    public class InsertProveedoreDTO
    {
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [MaxLength(255)]
        public string? Direccion { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }
    }

}
