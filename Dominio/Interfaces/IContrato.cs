using Dominio.Entities;
namespace Dominio.Interfaces;
public interface IContrato : IGenericRepo<Contrato>
{
    Task<IEnumerable<object>> ContratosActivos();
}