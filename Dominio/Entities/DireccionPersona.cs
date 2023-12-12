using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class DireccionPersona
{
    public int Id { get; set; }

    public string Direccion { get; set; } = null!;

    public int IdPersonaFk { get; set; }

    public int IdTipoDireccionFk { get; set; }

    public virtual Persona IdPersonaFkNavigation { get; set; } = null!;

    public virtual TipoDireccion IdTipoDireccionFkNavigation { get; set; } = null!;
}
