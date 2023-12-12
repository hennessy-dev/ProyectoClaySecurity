using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Departamento
{
    public int Id { get; set; }

    public string NombreDep { get; set; } = null!;

    public int IdPaisFk { get; set; }

    public virtual ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();

    public virtual Pais IdPaisFkNavigation { get; set; } = null!;
}
