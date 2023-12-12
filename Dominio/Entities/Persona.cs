using System;
using System.Collections.Generic;

namespace Dominio.Entities;
public partial class Persona
{
    public int Id { get; set; }

    public int? IdPersonaU { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Nombre2 { get; set; }

    public string Apellido { get; set; } = null!;

    public string? Apellido2 { get; set; }

    public int IdTipoPersonaFk { get; set; }

    public int IdCategoriaPersonaFk { get; set; }

    public int IdCiudaFk { get; set; }

    public virtual ICollection<ContactoPersona> ContactoPersonas { get; set; } = new List<ContactoPersona>();

    public virtual ICollection<Contrato> ContratoIdClienteNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Contrato> ContratoIdEmpleadoFkNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<DireccionPersona> DireccionPersonas { get; set; } = new List<DireccionPersona>();

    public virtual CategoriaPersona IdCategoriaPersonaFkNavigation { get; set; } = null!;

    public virtual Ciudad IdCiudaFkNavigation { get; set; } = null!;

    public virtual TipoPersona IdTipoPersonaFkNavigation { get; set; } = null!;

    public virtual ICollection<Programacion> Programaciones { get; set; } = new List<Programacion>();
}
