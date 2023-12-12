using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<object>> ListarContactosVigilantes()
        {
            var enunciado = "Listar todos los contactos de los vigilantes de la empresa";

            var consulta = _context.ContactoPersonas
                                    .Where(p => p.IdPersonaFkNavigation.IdTipoPersonaFkNavigation.Descripcion.Contains("Empleado") && p.IdPersonaFkNavigation.IdCategoriaPersonaFkNavigation.NombreCategoria.Contains("Vigilante"))
                                    .Select(e => new
                                    {
                                        NombreCategoria = e.IdPersonaFkNavigation.IdCategoriaPersonaFkNavigation.NombreCategoria,
                                        TipoPersona = e.IdPersonaFkNavigation.IdTipoPersonaFkNavigation.Descripcion,
                                        Nombre = e.IdPersonaFkNavigation.Nombre,
                                        Apellido = e.IdPersonaFkNavigation.Apellido,
                                        DescripcionContacto = e.Descripcion,
                                        TipoContacto = e.IdTipoContactoFkNavigation.Descripcion
                                    }).ToListAsync();

            var resultado = new List<object>
            {
                new { Enunciado = enunciado, Datos = await consulta }
            };

            return resultado;
        }
    }
}