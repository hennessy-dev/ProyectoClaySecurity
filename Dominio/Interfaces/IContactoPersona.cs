using Dominio.Entities;
namespace Dominio.Interfaces;
public interface IContactoPersona : IGenericRepo<ContactoPersona>
{
    Task<IEnumerable<object>> ListarContactosVigilantes();
}