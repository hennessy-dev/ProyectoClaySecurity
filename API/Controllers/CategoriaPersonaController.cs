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
public class CategoriaPersonaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CategoriaPersonaController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoriaPersona>>> Get()
    {
        var resultado = await _unitOfWork.CategoriaPersonas.GetAllAsync();
        return Ok(resultado);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CategoriaPersonaDto>>> Get([FromQuery] Params entidadP)
    {
        var (totalRegistros, registros) = await _unitOfWork.CategoriaPersonas.GetAllAsync(entidadP.PageIndex, entidadP.PageSize, entidadP.Search);
        var lista = _mapper.Map<IQueryable<CategoriaPersonaDto>>(registros);
        return new Pager<CategoriaPersonaDto>(lista, totalRegistros, entidadP.PageIndex, entidadP.PageSize, entidadP.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoriaPersona>>> Post(CategoriaPersonaDto Dto)
    {
        var resultado = _mapper.Map<CategoriaPersona>(Dto);
        _unitOfWork.CategoriaPersonas.Add(resultado);
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
    public async Task<IActionResult> Update(int id, [FromBody] CategoriaPersonaDto Dto)
    {
        if (id != Dto.Id)
        {
            return BadRequest();
        }

        var existe = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);
        if (existe == null)
        {
            return NotFound();
        }


        _mapper.Map(Dto, existe);
        _unitOfWork.CategoriaPersonas.Update(existe);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var resultado = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);
        if (resultado == null)
        {
            return NotFound();
        }

        _unitOfWork.CategoriaPersonas.Remove(resultado);
        await _unitOfWork.SaveAsync();

        return Ok();
    }
}