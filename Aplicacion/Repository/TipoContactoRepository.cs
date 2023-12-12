using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TipoContactoRepository : GenericRepo<TipoContacto>, ITipoContacto
    {
        private readonly ApiContext _context;

        public TipoContactoRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}