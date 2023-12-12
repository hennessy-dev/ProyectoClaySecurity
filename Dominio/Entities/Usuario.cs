using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    [NotMapped]
    public virtual ICollection<Rol> IdRolFks { get; set; } = new List<Rol>();
    public ICollection<RolUsuario>? RolesUsuarios {get;set;}
    public ICollection<Rol>? Roles {get; set;} = new HashSet<Rol>();
}
