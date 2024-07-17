using AutoMapper;
using DatabaseFirstApi.DTO.Categoria;
using DatabaseFirstApi.DTO.Cliente;
using DatabaseFirstApi.DTO.Factura;
using DatabaseFirstApi.DTO.Producto;
using DatabaseFirstApi.DTO.Proveedor;
using DatabaseFirstApi.DTO.Venta;

namespace DatabaseFirstApi.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Mapeos de Producto
            CreateMap<GetProductoDTO, Models.Producto>().ReverseMap();
            CreateMap<PutProductoDTO, Models.Producto>().ReverseMap();
            CreateMap<InsertProductoDTO, Models.Producto>().ReverseMap();

            // Mapeos de Proveedore
            CreateMap<GetProveedoreDTO, Models.Proveedore>().ReverseMap();
            CreateMap<PutProveedoreDTO, Models.Proveedore>().ReverseMap();
            CreateMap<InsertProveedoreDTO, Models.Proveedore>().ReverseMap();

            // Mapeos de Categoria
            CreateMap<GetCategoriaDTO, Models.Categoria>().ReverseMap();
            CreateMap<PutCategoriaDTO, Models.Categoria>().ReverseMap();
            CreateMap<InsertCategoriaDTO, Models.Categoria>().ReverseMap();

            // Mapeos de Cliente
            CreateMap<GetClienteDTO, Models.Cliente>().ReverseMap();
            CreateMap<PutClienteDTO, Models.Cliente>().ReverseMap();
            CreateMap<InsertClienteDTO, Models.Cliente>().ReverseMap();

            // Mapeos de Factura
            CreateMap<GetFacturaDTO, Models.Factura>().ReverseMap();
            CreateMap<PutFacturaDTO, Models.Factura>().ReverseMap();
            CreateMap<InsertFacturaDTO, Models.Factura>().ReverseMap();

            // Mapeos de Venta
            CreateMap<GetVentaDTO, Models.Venta>().ReverseMap();
            CreateMap<PutVentaDTO, Models.Venta>().ReverseMap();
            CreateMap<InsertVentaDTO, Models.Venta>().ReverseMap();

        }
    }
}
