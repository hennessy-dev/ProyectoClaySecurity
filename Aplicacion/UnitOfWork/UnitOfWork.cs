using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork  : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;

    private RolRepository _Rol;
    private UsuarioRepository _usuarios;

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
    
    public IRol Roles
    {
        get{
            if(_Rol== null)
            {
                _Rol= new RolRepository(_context);
            }
            return _Rol;
        }
    }
    
    public IUsuario Usuarios
    {
        get{
            if(_usuarios== null)
            {
                _usuarios= new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    private ICategoriaPersona _CategoriaPersona;
    public ICategoriaPersona CategoriaPersonas
    {
        get { 
            _CategoriaPersona ??= new CategoriaPersonaRepository(_context);
                return _CategoriaPersona;
            }
    }

    private ICiudad _Ciudad;
    public ICiudad Ciudades
    {
        get { 
            _Ciudad ??= new CiudadRepository(_context);
                return _Ciudad;
            }
    }

    private IContactoPersona _ContactoPersona;
    public IContactoPersona ContactoPersonas
    {
        get { 
            _ContactoPersona ??= new ContactoPersonaRepository(_context);
                return _ContactoPersona;
            }
    }

    private IContrato _Contrato;
    public IContrato Contratos
    {
        get { 
            _Contrato ??= new ContratoRepository(_context);
                return _Contrato;
            }
    }

    private IDepartamento _Departamento;
    public IDepartamento Departamentos
    {
        get { 
            _Departamento ??= new DepartamentoRepository(_context);
                return _Departamento;
            }
    }

    private IDireccionPersona _DireccionPersona;
    public IDireccionPersona DireccionPersonas
    {
        get { 
            _DireccionPersona ??= new DireccionPersonaRepository(_context);
                return _DireccionPersona;
            }
    }

    private IEstado _Estado;
    public IEstado Estados
    {
        get { 
            _Estado ??= new EstadoRepository(_context);
                return _Estado;
            }
    }

    private IPais _Pais;
    public IPais Paises
    {
        get { 
            _Pais ??= new PaisRepository(_context);
                return _Pais;
            }
    }

    private IPersona _Persona;
    public IPersona Personas
    {
        get { 
            _Persona ??= new PersonaRepository(_context);
                return _Persona;
            }
    }

    private IProgramacion _Programacion;
    public IProgramacion Programaciones
    {
        get { 
            _Programacion ??= new ProgramacionRepository(_context);
                return _Programacion;
            }
    }

    private ITipoContacto _TipoContacto;
    public ITipoContacto TipoContactos
    {
        get { 
            _TipoContacto ??= new TipoContactoRepository(_context);
                return _TipoContacto;
            }
    }

    private ITipoDireccion _TipoDireccion;
    public ITipoDireccion TipoDirecciones
    {
        get { 
            _TipoDireccion ??= new TipoDireccionRepository(_context);
                return _TipoDireccion;
            }
    }

    private ITipoPersona _TipoPersona;
    public ITipoPersona TipoPersonas
    {
        get { 
            _TipoPersona ??= new TipoPersonaRepository(_context);
                return _TipoPersona;
            }
    }

    private ITurno _Turno;
    public ITurno Turnos
    {
        get { 
            _Turno ??= new TurnoRepository(_context);
                return _Turno;
            }
    }

    private IRefreshToken _IRefreshToken;
    public IRefreshToken RefreshTokens
    {
        get { 
            _IRefreshToken ??= new RefreshTokenRepository(_context);
                return _IRefreshToken;
            }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
