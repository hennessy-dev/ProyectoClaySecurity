using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class RefreshToken
{
    public int Id { get; set; }

    public int IdUsuarioFk { get; set; }

    public string Token { get; set; } = null!;

    public DateTime Expires { get; set; }

    public DateTime Created { get; set; }

    public bool IsActive {get;set;}

    public string Revoked { get; set; } = "";

    public virtual Usuario IdUsuarioFkNavigation { get; set; } = null!;
}
