using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TurnoDto
    {
    public int IdTurno { get; set; }
    public string NombreTurno { get; set; }
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFinal { get; set; }
    }
}