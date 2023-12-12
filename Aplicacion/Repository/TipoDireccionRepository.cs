using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TipoDireccionRepository : GenericRepo<TipoDireccion>, ITipoDireccion
    {
        private readonly ApiContext _context;

        public TipoDireccionRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}