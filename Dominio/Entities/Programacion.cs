using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Programacion
{
    public int Id { get; set; }

    public int IdContratoFk { get; set; }

    public int IdTurnoFk { get; set; }

    public int IdEmpleadoFk { get; set; }

    public virtual Contrato IdContratoFkNavigation { get; set; } = null!;

    public virtual Persona IdEmpleadoFkNavigation { get; set; } = null!;

    public virtual Turno IdTurnoFkNavigation { get; set; } = null!;
}
