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
public class ContratoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ContratoController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Contrato>>> Get()
    {
        var resultado = await _unitOfWork.Contratos.GetAllAsync();
        return Ok(resultado);
    }

    [HttpGet("ContratosActivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ContratosActivos()
        {
            var resultado = await _unitOfWork.Contratos.ContratosActivos();
            return Ok(resultado);
        }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ContratoDto>>> Get([FromQuery] Params entidadP)
    {
        var (totalRegistros, registros) = await _unitOfWork.Contratos.GetAllAsync(entidadP.PageIndex, entidadP.PageSize, entidadP.Search);
        var lista = _mapper.Map<IQueryable<ContratoDto>>(registros);
        return new Pager<ContratoDto>(lista, totalRegistros, entidadP.PageIndex, entidadP.PageSize, entidadP.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Contrato>>> Post(ContratoDto Dto)
    {
        var resultado = _mapper.Map<Contrato>(Dto);
        _unitOfWork.Contratos.Add(resultado);
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
    public async Task<IActionResult> Update(int id, [FromBody] ContratoDto Dto)
    {
        if (id != Dto.Id)
        {
            return BadRequest();
        }

        var existe = await _unitOfWork.Contratos.GetByIdAsync(id);
        if (existe == null)
        {
            return NotFound();
        }


        _mapper.Map(Dto, existe);
        _unitOfWork.Contratos.Update(existe);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var resultado = await _unitOfWork.Contratos.GetByIdAsync(id);
        if (resultado == null)
        {
            return NotFound();
        }

        _unitOfWork.Contratos.Remove(resultado);
        await _unitOfWork.SaveAsync();

        return Ok();
    }
}