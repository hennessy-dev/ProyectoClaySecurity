using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Contrato
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public DateTime FechaContrato { get; set; }

    public int IdEmpleadoFk { get; set; }

    public DateTime FechaFin { get; set; }

    public int IdEstadoFk { get; set; }

    public virtual Persona IdClienteNavigation { get; set; } = null!;

    public virtual Persona IdEmpleadoFkNavigation { get; set; } = null!;

    public virtual Estado IdEstadoFkNavigation { get; set; } = null!;

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
