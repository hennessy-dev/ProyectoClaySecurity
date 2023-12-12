using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class RefreshTokenDto
    {
        public int Id { get; set; }
        public int IdUsuarioFk { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string Revoked { get; set; }
    }
}