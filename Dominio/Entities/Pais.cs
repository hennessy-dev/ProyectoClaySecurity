using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Pais
{
    public int Id { get; set; }

    public string NombrePais { get; set; } = null!;

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
