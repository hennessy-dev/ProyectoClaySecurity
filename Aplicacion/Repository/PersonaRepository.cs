using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class PersonaRepository : GenericRepo<Persona>, IPersona
    {
        private readonly ApiContext _context;

        public PersonaRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}