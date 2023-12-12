using Dominio.Entities;
namespace Dominio.Interfaces;
public interface IPersona : IGenericRepo<Persona>
{
    Task<IEnumerable<object>> ListarEmpleadosEmpresa();
    Task<IEnumerable<object>> ListarClientesBucaramanga();
    Task<IEnumerable<object>> ListarEmpleadosGironPiedecuesta();
    Task<IEnumerable<object>> ClientesCon5AñosAntiguedad();

}