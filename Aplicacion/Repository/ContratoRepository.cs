using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<object>> ContratosActivos()
                {
                    var enunciado = "Listar todos los contratos cuyo estado es Activo";
        
                    var consulta = _context.Contratos
                                            .Where(p => p.IdEstadoFkNavigation.Descripcion.Contains("Activo"))
                                            .Select(e => new
                                            {
                                                NombreCliente = e.IdClienteNavigation.Nombre,
                                                ApellidoCliente = e.IdClienteNavigation.Apellido,
                                                FechaContrato = e.FechaContrato,
                                                NombreEmpleado = e.IdEmpleadoFkNavigation.Nombre,
                                                ApellidoEmpleado = e.IdEmpleadoFkNavigation.Apellido
                                            }).ToListAsync();
        
                    var resultado = new List<object>
                    {
                        new { Enunciado = enunciado, Datos = await consulta }
                    };
        
                    return resultado;
                }
    }
}