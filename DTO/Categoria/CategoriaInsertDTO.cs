using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApi.DTO.Categoria
{
    public class InsertCategoriaDTO
    {
        [MaxLength(100)]
        public string? Descripcion { get; set; }
    }

}
