using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class PaisRepository : GenericRepo<Pais>, IPais
    {
        private readonly ApiContext _context;

        public PaisRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}