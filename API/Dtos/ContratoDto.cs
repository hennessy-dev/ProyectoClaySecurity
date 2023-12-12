using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ContratoDto
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public DateTime FechaContrato { get; set; }

        public int IdEmpleadoFk { get; set; }

        public DateTime FechaFin { get; set; }

        public int IdEstadoFk { get; set; }
    }
}