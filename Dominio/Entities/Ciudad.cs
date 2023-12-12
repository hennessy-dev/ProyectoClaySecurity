using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Ciudad
{
    public int Id { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public int IdDepartamentoFk { get; set; }

    public virtual Departamento IdDepartamentoFkNavigation { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
