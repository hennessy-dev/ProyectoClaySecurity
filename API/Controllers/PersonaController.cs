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
//[Authorize(Roles = "Empleado, Administrador, Gerente")]
public class PersonaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PersonaController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Persona>>> Get()
    {
        var resultado = await _unitOfWork.Personas.GetAllAsync();
        return Ok(resultado);
    }

    [HttpGet("ListarEmpleados")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListarEmpleadosEmpresa()
    {
        var resultado = await _unitOfWork.Personas.ListarEmpleadosEmpresa();
        return Ok(resultado);
    }

    [HttpGet("ListarClientesBucaramanga")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListarClientesBucaramanga()
    {
        var resultado = await _unitOfWork.Personas.ListarClientesBucaramanga();
        return Ok(resultado);
    }

    [HttpGet("ListarEmpleadosGironPiedecuesta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ListarEmpleadosGironPiedecuesta()
        {
            var resultado = await _unitOfWork.Personas.ListarEmpleadosGironPiedecuesta();
            return Ok(resultado);
        }

    [HttpGet("ClientesCon5AñosAntiguedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ClientesCon5AñosAntiguedad()
        {
            var resultado = await _unitOfWork.Personas.ClientesCon5AñosAntiguedad();
            return Ok(resultado);
        }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PersonaDto>>> Get([FromQuery] Params entidadP)
    {
        var (totalRegistros, registros) = await _unitOfWork.Personas.GetAllAsync(entidadP.PageIndex, entidadP.PageSize, entidadP.Search);
        var lista = _mapper.Map<IQueryable<PersonaDto>>(registros);
        return new Pager<PersonaDto>(lista, totalRegistros, entidadP.PageIndex, entidadP.PageSize, entidadP.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Persona>>> Post(PersonaDto Dto)
    {
        var resultado = _mapper.Map<Persona>(Dto);
        _unitOfWork.Personas.Add(resultado);
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
    public async Task<IActionResult> Update(int id, [FromBody] PersonaDto Dto)
    {
        if (id != Dto.Id)
        {
            return BadRequest();
        }

        var existe = await _unitOfWork.Personas.GetByIdAsync(id);
        if (existe == null)
        {
            return NotFound();
        }


        _mapper.Map(Dto, existe);
        _unitOfWork.Personas.Update(existe);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var resultado = await _unitOfWork.Personas.GetByIdAsync(id);
        if (resultado == null)
        {
            return NotFound();
        }

        _unitOfWork.Personas.Remove(resultado);
        await _unitOfWork.SaveAsync();

        return Ok();
    }
}