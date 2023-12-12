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
public class EstadoController : BaseApiController
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public EstadoController(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  
  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<ActionResult<IEnumerable<Estado>>> Get()
  {
      var resultado = await _unitOfWork.Estados.GetAllAsync();
      return Ok(resultado);
  }

  [HttpGet]
  [ApiVersion("1.1")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<ActionResult<Pager<EstadoDto>>> Get([FromQuery] Params entidadP)
  {
  var (totalRegistros, registros) = await _unitOfWork.Estados.GetAllAsync(entidadP.PageIndex,entidadP.PageSize,entidadP.Search);
  var lista = _mapper.Map<IQueryable<EstadoDto>>(registros);
  return new Pager<EstadoDto>(lista, totalRegistros,entidadP.PageIndex,entidadP.PageSize,entidadP.Search);
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<ActionResult<IEnumerable<Estado>>> Post(EstadoDto Dto)
  {
  var resultado = _mapper.Map<Estado>(Dto);
      _unitOfWork.Estados.Add(resultado);
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
  public async Task<IActionResult> Update(int id, [FromBody] EstadoDto Dto)
  {
      if (id != Dto.Id)
      {
          return BadRequest();
      }
  
      var existe = await _unitOfWork.Estados.GetByIdAsync(id);
      if (existe == null)
      {
          return NotFound();
      }
  
  
        _mapper.Map(Dto, existe);
      _unitOfWork.Estados.Update(existe);
      await _unitOfWork.SaveAsync();
  
      return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Delete(int id)
  {
    var resultado = await _unitOfWork.Estados.GetByIdAsync(id);
    if (resultado == null)
    {
      return NotFound();
    }
  
    _unitOfWork.Estados.Remove(resultado);
    await _unitOfWork.SaveAsync();
  
    return Ok();
  }
}