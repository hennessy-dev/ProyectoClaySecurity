using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities;

public partial class Rol
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    [NotMapped]
    public virtual ICollection<Usuario> IdUsuarioFks { get; set; } = new List<Usuario>();
    public ICollection<RolUsuario>? RolesUsuarios {get;set;}
    public ICollection<Usuario>? Usuarios {get;set;}
}
