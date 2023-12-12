using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Turno
{
    public int Id { get; set; }

    public string NombreTurno { get; set; } = null!;

    public DateTime HoraInicio { get; set; }

    public DateTime HoraFinal { get; set; }

    public virtual ICollection<Programacion> Programaciones { get; set; } = new List<Programacion>();
}
