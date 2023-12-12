using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TurnoRepository : GenericRepo<Turno>, ITurno
    {
        private readonly ApiContext _context;

        public TurnoRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}