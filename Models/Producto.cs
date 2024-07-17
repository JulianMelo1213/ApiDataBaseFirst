using System;
using System.Collections.Generic;

namespace DatabaseFirstApi.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdProveedor { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Proveedore? IdProveedorNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
