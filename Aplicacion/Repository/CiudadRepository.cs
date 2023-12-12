using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class CiudadRepository : GenericRepo<Ciudad>, ICiudad
    {
        private readonly ApiContext _context;

        public CiudadRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}