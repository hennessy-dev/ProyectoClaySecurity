using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class EstadoRepository : GenericRepo<Estado>, IEstado
    {
        private readonly ApiContext _context;

        public EstadoRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}