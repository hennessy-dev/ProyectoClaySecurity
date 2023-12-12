using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class PersonaRepository : GenericRepo<Persona>, IPersona
    {
        private readonly ApiContext _context;

        public PersonaRepository(ApiContext context) : base (context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> ListarEmpleadosEmpresa()
        {
            var enunciado = "Listar todos los empleados de la empresa de seguridad";

            var consulta = _context.Personas
                                    .Where(p => p.IdTipoPersonaFkNavigation.Descripcion.Contains("Vigilante"))
                                    .Select(e => new
                                    {
                                        e.Id,
                                        e.Nombre,
                                        e.Apellido,
                                    }).ToListAsync();

            var resultado = new List<object>
            {
                new { Enunciado = enunciado, Datos = await consulta }
            };

            return resultado;
        }

        public async Task<IEnumerable<object>> ListarContactosVigilantes()
        {
            var enunciado = "Listar todos los contactos de los vigilantes de la empresa";

            var consulta = _context.Personas
                                    .Where(p => p.IdTipoPersonaFkNavigation.Descripcion.Contains("Empleado") && p.IdCategoriaPersonaFkNavigation.NombreCategoria.Contains("Vigilante"))
                                    .Select(e => new
                                    {
                                        e.IdCategoriaPersonaFkNavigation.NombreCategoria,
                                        e.IdTipoPersonaFkNavigation.Descripcion,
                                        e.Nombre,
                                        e.Apellido,
                                    }).ToListAsync();

            var resultado = new List<object>
            {
                new { Enunciado = enunciado, Datos = await consulta }
            };

            return resultado;
        }

        public async Task<IEnumerable<object>> ListarClientesBucaramanga()
        {
            var enunciado = "Listar todos los clientes que vivan en la ciudad de Bucaramanga";

            var consulta = _context.Personas
                                    .Where(p => p.IdCiudaFkNavigation.NombreCiudad.Contains("Bucaramanga") && p.IdCategoriaPersonaFkNavigation.NombreCategoria.Contains("Cliente") || p.IdTipoPersonaFkNavigation.Descripcion.Contains("Cliente"))
                                    .Select(e => new
                                    {
                                        Id = e.Id,
                                        Nombre = e.Nombre,
                                        Apellido = e.Apellido,
                                        Categoria = e.IdCategoriaPersonaFkNavigation.NombreCategoria
                                    }).ToListAsync();

            var resultado = new List<object>
            {
                new { Enunciado = enunciado, Datos = await consulta }
            };

            return resultado;
        }

        public async Task<IEnumerable<object>> ListarEmpleadosGironPiedecuesta()
                {
                    var enunciado = "Listar todos los empleados que vivan en Girón o Piedecuesta";
        
                    var consulta = _context.Personas
                                            .Where(p => (p.IdCiudaFkNavigation.NombreCiudad.Contains("Giron") || p.IdCiudaFkNavigation.NombreCiudad.Contains("Piedecuesta")) && (p.IdCategoriaPersonaFkNavigation.NombreCategoria.Contains("Empleado") || p.IdTipoPersonaFkNavigation.Descripcion.Contains("Empleado")))
                                            .Select(e => new
                                            {
                                                Ciudad = e.IdCiudaFkNavigation.NombreCiudad,
                                                Nombre = e.Nombre,
                                                Apellido = e.Apellido,
                                                Categoria = e.IdCategoriaPersonaFkNavigation.NombreCategoria,
                                                TipoPersona = e.IdTipoPersonaFkNavigation.Descripcion

                                            }).ToListAsync();
        
                    var resultado = new List<object>
                    {
                        new { Enunciado = enunciado, Datos = await consulta }
                    };
        
                    return resultado;
                }

        public async Task<IEnumerable<object>> ClientesCon5AñosAntiguedad()
                {
                    var enunciado = "Listar todos los clientes que tengan más de 5 años de antigüedad";
        
                    var fechaLimite = DateTime.Now.AddYears(-5);

                    var consulta = _context.Personas
                        .Where(p => p.IdTipoPersonaFkNavigation.Descripcion == "Cliente" &&
                                    p.DateReg <= fechaLimite)
                        .Select(e => new
                        {
                            IdCliente = e.Id,
                            NombreCliente = e.Nombre,
                            ApellidoCliente = e.Apellido,
                            Antiguedad = DateTime.Now.Year - e.DateReg.Year
                        })
                        .ToListAsync();
        
                    var resultado = new List<object>
                    {
                        new { Enunciado = enunciado, Datos = await consulta }
                    };
        
                    return resultado;
                }

    }
}