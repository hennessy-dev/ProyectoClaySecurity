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
public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DepartamentoController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Departamento>>> Get()
    {
        var resultado = await _unitOfWork.Departamentos.GetAllAsync();
        return Ok(resultado);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DepartamentoDto>>> Get([FromQuery] Params entidadP)
    {
        var (totalRegistros, registros) = await _unitOfWork.Departamentos.GetAllAsync(entidadP.PageIndex, entidadP.PageSize, entidadP.Search);
        var lista = _mapper.Map<IQueryable<DepartamentoDto>>(registros);
        return new Pager<DepartamentoDto>(lista, totalRegistros, entidadP.PageIndex, entidadP.PageSize, entidadP.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Departamento>>> Post(DepartamentoDto Dto)
    {
        var resultado = _mapper.Map<Departamento>(Dto);
        _unitOfWork.Departamentos.Add(resultado);
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
    public async Task<IActionResult> Update(int id, [FromBody] DepartamentoDto Dto)
    {
        if (id != Dto.Id)
        {
            return BadRequest();
        }

        var existe = await _unitOfWork.Departamentos.GetByIdAsync(id);
        if (existe == null)
        {
            return NotFound();
        }


        _mapper.Map(Dto, existe);
        _unitOfWork.Departamentos.Update(existe);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var resultado = await _unitOfWork.Departamentos.GetByIdAsync(id);
        if (resultado == null)
        {
            return NotFound();
        }

        _unitOfWork.Departamentos.Remove(resultado);
        await _unitOfWork.SaveAsync();

        return Ok();
    }
}