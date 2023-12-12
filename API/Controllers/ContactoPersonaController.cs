using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize(Roles = "Empleado, Administrador, Gerente")]
public class ContactoPersonaController : BaseApiController
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public ContactoPersonaController(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  
  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<ActionResult<IEnumerable<ContactoPersona>>> Get()
  {
      var resultado = await _unitOfWork.ContactoPersonas.GetAllAsync();
      return Ok(resultado);
  }

  [HttpGet]
  [ApiVersion("1.1")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<ActionResult<Pager<ContactoPersonaDto>>> Get([FromQuery] Params entidadP)
  {
  var (totalRegistros, registros) = await _unitOfWork.ContactoPersonas.GetAllAsync(entidadP.PageIndex,entidadP.PageSize,entidadP.Search);
  var lista = _mapper.Map<IQueryable<ContactoPersonaDto>>(registros);
  return new Pager<ContactoPersonaDto>(lista, totalRegistros,entidadP.PageIndex,entidadP.PageSize,entidadP.Search);
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<ActionResult<IEnumerable<ContactoPersona>>> Post(ContactoPersonaDto Dto)
  {
  var resultado = _mapper.Map<ContactoPersona>(Dto);
      _unitOfWork.ContactoPersonas.Add(resultado);
      await _unitOfWork.SaveAsync();
      if (resultado == null)
      {
          return BadRequest();
      }
      return NoContent();
  }

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Update(int id, [FromBody] ContactoPersonaDto Dto)
  {
      if (id != Dto.Id)
      {
          return BadRequest();
      }
  
      var existe = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
      if (existe == null)
      {
          return NotFound();
      }
  
  
        _mapper.Map(Dto, existe);
      _unitOfWork.ContactoPersonas.Update(existe);
      await _unitOfWork.SaveAsync();
  
      return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Delete(int id)
  {
    var resultado = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
    if (resultado == null)
    {
      return NotFound();
    }
  
    _unitOfWork.ContactoPersonas.Remove(resultado);
    await _unitOfWork.SaveAsync();
  
    return Ok();
  }
}