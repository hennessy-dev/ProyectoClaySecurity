using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class ContactoPersonaRepository : GenericRepo<ContactoPersona>, IContactoPersona
    {
        private readonly ApiContext _context;

        public ContactoPersonaRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}