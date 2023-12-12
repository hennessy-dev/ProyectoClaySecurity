using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class ContratoRepository : GenericRepo<Contrato>, IContrato
    {
        private readonly ApiContext _context;

        public ContratoRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}