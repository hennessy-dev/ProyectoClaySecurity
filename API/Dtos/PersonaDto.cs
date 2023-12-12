using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }

        public int? IdPersonaU { get; set; }

        public string Nombre { get; set; } = null!;

        public string Nombre2 { get; set; }

        public string Apellido { get; set; } = null!;

        public string Apellido2 { get; set; }

        public int IdTipoPersonaFk { get; set; }

        public int IdCategoriaPersonaFk { get; set; }

        public int IdCiudaFk { get; set; }
    }
}