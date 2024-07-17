using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApi.DTO.Categoria
{
    public class PutCategoriaDTO
    {
        [Required]
        public int IdCategoria { get; set; }

        [MaxLength(100)]
        public string? Descripcion { get; set; }
    }

}
