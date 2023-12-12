using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class CategoriaPersonaRepository : GenericRepo<CategoriaPersona>, ICategoriaPersona
    {
        private readonly ApiContext _context;

        public CategoriaPersonaRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}