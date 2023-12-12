using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TipoPersonaRepository : GenericRepo<TipoPersona>, ITipoPersona
    {
        private readonly ApiContext _context;

        public TipoPersonaRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}