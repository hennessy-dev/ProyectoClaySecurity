using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class DepartamentoRepository : GenericRepo<Departamento>, IDepartamento
    {
        private readonly ApiContext _context;

        public DepartamentoRepository(ApiContext context) : base (context)
        {
            _context = context;
        }
    }
}