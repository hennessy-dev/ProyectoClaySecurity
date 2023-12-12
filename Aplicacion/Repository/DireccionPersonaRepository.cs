using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class DireccionPersonaRepository : GenericRepo<DireccionPersona>, IDireccionPersona
    {
        private readonly ApiContext _context;

        public DireccionPersonaRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}