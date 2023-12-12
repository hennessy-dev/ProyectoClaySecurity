using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class ContactoPersona
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdPersonaFk { get; set; }

    public int IdTipoContactoFk { get; set; }

    public virtual Persona IdPersonaFkNavigation { get; set; } = null!;

    public virtual TipoContacto IdTipoContactoFkNavigation { get; set; } = null!;
}
