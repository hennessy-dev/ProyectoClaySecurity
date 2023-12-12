using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class ProgramacionRepository : GenericRepo<Programacion>, IProgramacion
    {
        private readonly ApiContext _context;

        public ProgramacionRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}