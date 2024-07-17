using System;
using System.Collections.Generic;

namespace DatabaseFirstApi.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
