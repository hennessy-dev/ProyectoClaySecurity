using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class TipoDireccion
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<DireccionPersona> DireccionPersonas { get; set; } = new List<DireccionPersona>();
}
